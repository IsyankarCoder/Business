using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace Global.Core.Data.CustomExtensions
{
    /// <summary>
    ///  Apply Eager Loadings...
    /// </summary>
    public static class QueryExtension
    {
        public static IQueryable<TEntity> GetEntitiesWithRelations<TEntity>(this IQueryable<TEntity> query,
                                                                            params Expression<Func<TEntity, object>>[] navigationProperties)
            where TEntity : class
        {
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);
            return query;
        }
    }
}
