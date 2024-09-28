using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Template.Arguments.Arguments.Module.Base;
using Template.Arguments.General.Session;
using Template.Domain.DTO.Module.Base;
using Template.Domain.Interface.Repository.Module.Base;
using Template.Infrastructure.Extension;
using Template.Infrastructure.Persistence.Entry.Module.Base;

namespace Template.Infrastructure.Persistence.Repository.Module.Base;

public abstract class BaseRepository_0<TContext, TEntry, TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>(TContext context) : IBaseRepository_0<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>
    where TContext : DbContext
    where TEntry : BaseEntry<TEntry>
    where TOutput : BaseOutput<TOutput>
    where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
    where TInputCreate : BaseInputCreate<TInputCreate>
    where TInputUpdate : BaseInputUpdate<TInputUpdate>
    where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
    where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
    where TDTO : BaseDTO_0<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>, new()
    where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
    where TExternalPropertiesDTO : BaseExternalPropertiesDTO<TExternalPropertiesDTO>, new()
    where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>, new()
{
    protected readonly TContext _context = context;
    protected DbSet<TEntry> _dbSet = context.Set<TEntry>();

    public long Create(TDTO dto)
    {
        return Create([dto]).FirstOrDefault();
    }

    public List<long> Create(List<TDTO> listDTO)
    {
        List<TEntry> listEntry = FromDTOToEntry(listDTO);
        _dbSet.AddRange(listEntry);
        _context.SaveChanges();

        return (from i in listEntry select i.Id).ToList();
    }

    public bool Delete(TDTO dto)
    {
        return Delete([dto]);
    }

    public bool Delete(List<TDTO> listDTO)
    {
        List<TEntry> listEntry = FromDTOToEntry(listDTO);
        _dbSet.RemoveRange(listEntry);
        _context.SaveChanges();

        return true;
    }

    public TDTO Get(long id, bool getOnlyPrincipal = false)
    {
        var query = _dbSet.AsNoTracking().Where(x => x.Id == id);

        if (!getOnlyPrincipal)
            query = query.IncludeVirtualProperties();

        return FromEntryToDTO(query.FirstOrDefault()!);
    }

    public List<TDTO> GetAll(bool getOnlyPrincipal = false)
    {
        var query = _dbSet.AsNoTracking();

        if (!getOnlyPrincipal)
            query = query.IncludeVirtualProperties();

        return FromEntryToDTO([.. query]);
    }

    public List<TDTO> GetListByListId(List<long> listId, bool getOnlyPrincipal = false)
    {
        var query = _dbSet.Where(x => listId.Contains(x.Id)).AsNoTracking();

        if (!getOnlyPrincipal)
            query = query.IncludeVirtualProperties();

        return FromEntryToDTO([.. query]);
    }

    public TDTO GetByIdentifier(TInputIdentifier inputIdentifier, bool getOnlyPrincipal = false)
    {
        return GetListByListIdentifier([inputIdentifier], getOnlyPrincipal).FirstOrDefault()!;
    }

    public List<TDTO> GetListByListIdentifier(List<TInputIdentifier> listInputIdentifier, bool getOnlyPrincipal = false)
    {
        IQueryable<TEntry> query = _dbSet.AsNoTracking();

        if (listInputIdentifier == null || listInputIdentifier.Count == 0)
            return [];

        Expression<Func<TEntry, bool>>? combinedExpression = null;

        foreach (var inputIdentifier in listInputIdentifier)
        {
            Expression<Func<TEntry, bool>>? individualExpression = null;

            foreach (var property in typeof(TInputIdentifier).GetProperties())
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(inputIdentifier);

                if (propertyValue != null)
                {
                    var parameter = Expression.Parameter(typeof(TEntry), "x");
                    var member = Expression.Property(parameter, propertyName);
                    var constant = Expression.Constant(propertyValue, member.Type);

                    var body = Expression.Equal(member, constant);
                    var lambda = Expression.Lambda<Func<TEntry, bool>>(body, parameter);

                    individualExpression = individualExpression == null ? lambda : CombineExpressions(individualExpression, lambda);
                }
            }

            combinedExpression = combinedExpression == null ? individualExpression! : CombineExpressions(combinedExpression, individualExpression!, Expression.OrElse)!;
        }

        query = query.Where(combinedExpression!);

        if (!getOnlyPrincipal)
            query = query.IncludeVirtualProperties();

        return FromEntryToDTO([.. query]);
    }

    private static Expression<Func<T, bool>> CombineExpressions<T>(
    Expression<Func<T, bool>> expr1,
    Expression<Func<T, bool>> expr2,
    Func<Expression, Expression, BinaryExpression>? combiner = null)
    {
        combiner = combiner ?? Expression.AndAlso;

        var parameter = Expression.Parameter(typeof(T), "x");

        var leftVisitor = new ReplaceParameterVisitor(expr1.Parameters[0], parameter);
        var left = leftVisitor.Visit(expr1.Body);

        var rightVisitor = new ReplaceParameterVisitor(expr2.Parameters[0], parameter);
        var right = rightVisitor.Visit(expr2.Body);

        return Expression.Lambda<Func<T, bool>>(combiner(left, right), parameter);
    }

    private class ReplaceParameterVisitor(ParameterExpression oldParameter, ParameterExpression newParameter) : ExpressionVisitor
    {
        private readonly ParameterExpression _oldParameter = oldParameter;
        private readonly ParameterExpression _newParameter = newParameter;

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == _oldParameter ? _newParameter : base.VisitParameter(node);
        }
    }

    public long Update(TDTO dto)
    {
        return Update([dto]).FirstOrDefault();
    }

    public List<long> Update(List<TDTO> listDTO)
    {
        List<TEntry> listEntry = FromDTOToEntry(listDTO);
        _dbSet.UpdateRange(listEntry);
        _context.SaveChanges();

        return (from i in listEntry select i.Id).ToList();
    }

    internal TEntry FromDTOToEntry(TDTO dto)
    {
        return SessionData.Mapper!.MapperEntryDTO.Map<TDTO, TEntry>(dto);
    }

    internal TDTO FromEntryToDTO(TEntry entry)
    {
        return SessionData.Mapper!.MapperEntryDTO.Map<TEntry, TDTO>(entry);
    }

    internal List<TEntry> FromDTOToEntry(List<TDTO> listDTO)
    {
        return SessionData.Mapper!.MapperEntryDTO.Map<List<TDTO>, List<TEntry>>(listDTO);
    }

    internal List<TDTO> FromEntryToDTO(List<TEntry> listEntry)
    {
        return SessionData.Mapper!.MapperEntryDTO.Map<List<TEntry>, List<TDTO>>(listEntry);
    }
}

public abstract class BaseRepository_1<TContext, TEntry, TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertyDTO>(TContext context) : BaseRepository_0<TContext, TEntry, TOutput, TInputIdentifier, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, TDTO, TInternalPropertiesDTO, BaseExternalPropertiesDTO_0, TAuxiliaryPropertyDTO>(context), IBaseRepository_1<TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertyDTO>
    where TContext : DbContext
    where TEntry : BaseEntry<TEntry>
    where TOutput : BaseOutput<TOutput>
    where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
    where TDTO : BaseDTO_1<TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertyDTO>, new()
    where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
    where TAuxiliaryPropertyDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertyDTO>, new()
{ }