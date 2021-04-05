using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace Global.Core.ComponentModel
{
   public  interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Table { get; }

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] navigationExpressions);

        TEntity GetById<K>(K Id, params Expression<Func<TEntity, object>>[] navigationExpressions);

        Task<TEntity> GetByIdAsync<K>(K Id, params Expression<Func<TEntity, object>>[] navigationExpressions);

        IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);
    }
}
