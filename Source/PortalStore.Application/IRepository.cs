using System.Linq.Expressions;

namespace PortalStore.Application
{
    public interface IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        /// <summary>
        /// This readonly property gets the Entity Table query
        /// </summary>
        IQueryable<TEntity> Entities {get;} 
        Task<TEntity> GetByIdAsync(TId id); 
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeParams);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}