using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Global.Core.Data.Context;

namespace Global.Core.Data.Repository
{
    public class GenericRepository<TEntity> 
        : BaseRepository<TEntity> where TEntity:class
    {
        public GenericRepository(BaseDbContext baseDbContext)
            : base(baseDbContext)
        {

        }

        public override TEntity GetById<K>(K Id, params Expression<Func<TEntity, object>>[] navigationExpressions)
        {
            return base.GetById(Id, navigationExpressions);
        }
    }
}
