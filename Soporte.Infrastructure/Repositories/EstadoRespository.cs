

using Soporte.Application.Contracts.Persistence;
using Soporte.Domain;
using Soporte.Infrastructure.Persistence;

namespace Soporte.Infrastructure.Repositories;

public class EstadoRespository : RepositoryBase<Estado>,IEstadoRespository>
{
    public EstadoRespository( AplicacionesContext context ) : base(context)
    {
        
    }
}
