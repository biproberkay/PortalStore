global using PortalStore.Domain.Contracts;

namespace PortalStore.Application
{
    public interface IUnitOfWork:IDisposable
    {
        /// <summary>
        /// this method initiates a new repository with the given entity model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TId"></typeparam>
        /// <returns></returns>
        IRepository<T,TId> GetRepository<T,TId>() where T : class, IBaseEntity<TId>;

        Task<int> CommitAsync(CancellationToken cancellationToken);

        Task Rollback();

    }
}