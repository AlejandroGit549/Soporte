
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Soporte.Application.Contracts.Persistence;
using Soporte.Infrastructure.Persistence;
using Soporte.Infrastructure.Repositories;

namespace Soporte.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AplicacionesContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
      );


        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

        return services;

    }
}
