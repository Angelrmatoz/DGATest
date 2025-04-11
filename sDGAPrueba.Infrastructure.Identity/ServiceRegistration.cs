using DGAPrueba.Core.Domain.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using sDGAPrueba.Infrastructure.Identity.Context;

namespace sDGAPrueba.Infrastructure.Identity;

public static class ServiceRegistration
{
    /// AddIdentityLayer
    public static void AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Configuracion de la base de datos
        #region Context
        ContextConfiguration(configuration, services);
        #endregion
        
        // Configuracion de los servicios
        #region Services
        ServiceConfiguration(services);
        #endregion
    }
    private static void ContextConfiguration(IConfiguration configuration, IServiceCollection services)
    {
            // configuracion de la base de datos
            services.AddDbContext<IdentityContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"),
                    m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
            });
    }
    // Configuracion de los servicios
    private static void ServiceConfiguration(IServiceCollection services)
    {
        #region Services
        /*services.AddTransient<IAccountService, AccountService>();*/
        #endregion
    }
}