using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Template.Infrastructure.Extension;

public static class EFExtension
{
    public static IQueryable<TEntity> IncludeVirtualProperties<TEntity>(this IQueryable<TEntity> query) where TEntity : class
    {
        var properties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => !p.IsDefined(typeof(NotMappedAttribute)) && p.GetGetMethod()?.IsVirtual == true && (typeof(IEnumerable<>).IsAssignableFrom(p.PropertyType) || p.PropertyType.IsClass));

        foreach (var property in properties)
            query = query.Include(property.Name);

        return query;
    }
}