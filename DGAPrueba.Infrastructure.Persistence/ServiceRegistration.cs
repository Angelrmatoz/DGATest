using DGAPrueba.Core.Application.Interfaces.Repositories;
using DGAPrueba.Infrastructure.Persistence.Context;
using DGAPrueba.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DGAPrueba.Infrastructure.Persistence;

public static class ServiceRegistration
{
    // Extension de metodo para registrar el contexto de la base de datos 
    public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        #region Context
            services.AddDbContext<DGAContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(DGAContext).Assembly.FullName)));
        #endregion
        
        // Repositories

        #region Repositories
            services.AddTransient<IClientRepository, ClientRepository>();   
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISalesProductRepository, SalesProductRepository>();
            services.AddTransient<ISaleRepository, SalesRepository>();
        #endregion
    }
}