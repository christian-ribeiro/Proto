using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Proto.Arguments.Arguments.Module.Base;
using Proto.Arguments.General.Session;
using Proto.Domain.DTO.Module.Base;
using Proto.Domain.Interface.Repository.Module.Base;
using Proto.Infrastructure.Extension;
using Proto.Infrastructure.Persistence.Entity.Module.Base;

namespace Proto.Infrastructure.Persistence.Repository.Module.Base;

public abstract class BaseRepository_0<TContext, TEntity, TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>(TContext context) : IBaseRepository_0<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>
    where TContext : DbContext
    where TEntity : BaseEntity<TEntity>
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
    protected DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public long Create(TDTO dto)
    {
        return Create([dto]).FirstOrDefault();
    }

    public List<long> Create(List<TDTO> listDTO)
    {
        List<TEntity> listEntity = FromDTOToEntity(listDTO);
        _dbSet.AddRange(listEntity);
        _context.SaveChanges();

        return (from i in listEntity select i.Id).ToList();
    }

    public bool Delete(TDTO dto)
    {
        return Delete([dto]);
    }

    public bool Delete(List<TDTO> listDTO)
    {
        List<TEntity> listEntity = FromDTOToEntity(listDTO);
        _dbSet.RemoveRange(listEntity);
        _context.SaveChanges();

        return true;
    }

    public TDTO Get(long id, bool getOnlyPrincipal = false)
    {
        var query = _dbSet.AsNoTracking().Where(x => x.Id == id);

        if (!getOnlyPrincipal)
            query = query.IncludeVirtualProperties();

        return BaseRepository_0<TContext, TEntity, TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>.FromEntityToDTO(query.FirstOrDefault()!);
    }

    public List<TDTO> GetAll(bool getOnlyPrincipal = false)
    {
        var query = _dbSet.AsNoTracking();

        if (!getOnlyPrincipal)
            query = query.IncludeVirtualProperties();

        return FromEntityToDTO([.. query]);
    }

    public List<TDTO> GetListByListId(List<long> listId, bool getOnlyPrincipal = false)
    {
        var query = _dbSet.Where(x => listId.Contains(x.Id)).AsNoTracking();

        if (!getOnlyPrincipal)
            query = query.IncludeVirtualProperties();

        return FromEntityToDTO([.. query]);
    }

    public TDTO GetByIdentifier(TInputIdentifier inputIdentifier, bool getOnlyPrincipal = false)
    {
        return GetListByListIdentifier([inputIdentifier], getOnlyPrincipal).FirstOrDefault()!;
    }

    public List<TDTO> GetListByListIdentifier(List<TInputIdentifier> listInputIdentifier, bool getOnlyPrincipal = false)
    {
        if (listInputIdentifier == null || listInputIdentifier.Count == 0)
            return [];

        Expression<Func<TEntity, bool>>? combinedExpression = null;

        foreach (var inputIdentifier in listInputIdentifier)
        {
            Expression<Func<TEntity, bool>>? individualExpression = null;

            foreach (var property in typeof(TInputIdentifier).GetProperties())
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(inputIdentifier);

                if (propertyValue != null)
                {
                    var parameter = Expression.Parameter(typeof(TEntity), "x");
                    var member = Expression.Property(parameter, propertyName);
                    var constant = Expression.Constant(propertyValue, member.Type);

                    var body = Expression.Equal(member, constant);
                    var lambda = Expression.Lambda<Func<TEntity, bool>>(body, parameter);

                    individualExpression = individualExpression == null ? lambda : CombineExpressions(individualExpression, lambda);
                }
            }

            combinedExpression = combinedExpression == null ? individualExpression! : CombineExpressions(combinedExpression, individualExpression!, Expression.OrElse)!;
        }

        IQueryable<TEntity> query = _dbSet.AsNoTracking().Where(combinedExpression!);

        if (!getOnlyPrincipal)
            query = query.IncludeVirtualProperties();

        return FromEntityToDTO([.. query]);
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
        List<TEntity> listEntity = FromDTOToEntity(listDTO);
        _dbSet.UpdateRange(listEntity);
        _context.SaveChanges();

        return (from i in listEntity select i.Id).ToList();
    }

    internal static TEntity FromDTOToEntity(TDTO dto)
    {
        return SessionData.Mapper!.MapperEntityDTO.Map<TDTO, TEntity>(dto);
    }

    internal static TDTO FromEntityToDTO(TEntity Entity)
    {
        return SessionData.Mapper!.MapperEntityDTO.Map<TEntity, TDTO>(Entity);
    }

    internal static List<TEntity> FromDTOToEntity(List<TDTO> listDTO)
    {
        return SessionData.Mapper!.MapperEntityDTO.Map<List<TDTO>, List<TEntity>>(listDTO);
    }

    internal static List<TDTO> FromEntityToDTO(List<TEntity> listEntity)
    {
        return SessionData.Mapper!.MapperEntityDTO.Map<List<TEntity>, List<TDTO>>(listEntity);
    }
}

public abstract class BaseRepository_1<TContext, TEntity, TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertyDTO>(TContext context) : BaseRepository_0<TContext, TEntity, TOutput, TInputIdentifier, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, TDTO, TInternalPropertiesDTO, BaseExternalPropertiesDTO_0, TAuxiliaryPropertyDTO>(context), IBaseRepository_1<TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertyDTO>
    where TContext : DbContext
    where TEntity : BaseEntity<TEntity>
    where TOutput : BaseOutput<TOutput>
    where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
    where TDTO : BaseDTO_1<TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertyDTO>, new()
    where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
    where TAuxiliaryPropertyDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertyDTO>, new()
{ }