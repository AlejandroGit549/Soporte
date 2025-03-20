

namespace Soporte.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
         IEstadoRespository EstadoRespository { get};
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class;

        Task<int> Complete();
    }
}
