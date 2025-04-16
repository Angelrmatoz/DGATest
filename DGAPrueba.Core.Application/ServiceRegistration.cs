using System.Reflection;
using DGAPrueba.Core.Application.Interfaces.Services;
using DGAPrueba.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DGAPrueba.Core.Application;

public static class ServiceRegistration
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        #region Mapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());        
        #endregion
        #region services
            services.AddTransient(typeof(IBaseService<,>), typeof(BaseServices<,>));
            services.AddTransient<IClientService, ClientServices>();
            services.AddTransient<ISalesServices, SaleServices>();
            services.AddTransient<ISaleProductServices, SaleProductServices>();
            services.AddTransient<IProductServices, ProductServices>();
        #endregion
    }
}