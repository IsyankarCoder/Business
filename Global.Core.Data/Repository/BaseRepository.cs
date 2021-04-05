using System;
using System.Collections.Generic;
using System.Text;
using Global.Core.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Global.Core.Data.Context;
using Microsoft.EntityFrameworkCore;
using Global.Core.Data.CustomExtensions;

namespace Global.Core.Data.Repository
{
    public abstract class BaseRepository<TEntity>
        : IRepository<TEntity> where TEntity:class
    {
        
        private readonly BaseDbContext _baseDbContext;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(BaseDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;
            _dbSet = _baseDbContext.Set<TEntity>();

        }

        public IQueryable<TEntity> Table => _dbSet.AsQueryable();

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] navigationExpressions)
        {

            var query = _dbSet.GetEntitiesWithRelations(navigationExpressions);
            if (filter != null)
                query = query.Where(filter);

            return query;
        }

        public virtual TEntity GetById<K>(K Id, params Expression<Func<TEntity, object>>[] navigationExpressions)
        {

            var query = _dbSet.AsQueryable().GetEntitiesWithRelations();
            var keyName = _baseDbContext.Model.FindEntityType(nameof(TEntity)).FindPrimaryKey().ToString();
            var filter = GetKeyFilter(keyName, Id);
            //var keys =  qye
            return query.SingleOrDefault();
        }

        public Task<TEntity> GetByIdAsync<K>(K Id, params  Expression<Func<TEntity, object>>[] navigationExpressions)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }


        protected static Expression<Func<TEntity, bool>> GetKeyFilter(string keyName, object KeyValue)
        {
            var source = typeof(TEntity);
            var param = Expression.Parameter(source, "param");
            var property = source.GetProperty(keyName);
            if (property == null)
                throw new InvalidOperationException($"Property {keyName} not found in entity {KeyValue}");

            var sourceKey = Expression.MakeMemberAccess(param, property);
            var equal = Expression.Equal(sourceKey, Expression.Constant(KeyValue));
            return (Expression<Func<TEntity, bool>>)Expression.Lambda(equal, param);

        }
    }
}
