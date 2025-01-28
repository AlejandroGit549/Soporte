using Soporte.Application.Contracts.Persistence;
using Soporte.Infrastructure.Persistence;
using System.Collections;

namespace Soporte.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private Hashtable _repositories;
    private readonly AplicacionesContext _context;


    public UnitOfWork(AplicacionesContext context)
    {
        _context = context;
    }

    public AplicacionesContext AplicacionesContext => _context;

    public async Task<int> Complete()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Err: {ex.Message}");
        }

    }
    public void Dispose()
    {
        _context.Dispose();
    }

    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        if (_repositories == null)
        {
            _repositories = new Hashtable();
        }

        var type = typeof(TEntity).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(RepositoryBase<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
            _repositories.Add(type, repositoryInstance);
        }

        return (IAsyncRepository<TEntity>)_repositories[type];
    }
}
