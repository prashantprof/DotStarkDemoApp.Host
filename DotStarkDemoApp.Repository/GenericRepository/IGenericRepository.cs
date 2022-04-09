using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DotStarkDemoApp.Repository.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();

        IEnumerable<TEntity> GetAll();

        TEntity GetByID(object id);

        IEnumerable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
    }
}
