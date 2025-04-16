using System.Text;
using DGAPrueba.Core.application.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using sDGAPrueba.Infrastructure.Identity.Context;
using sDGAPrueba.Infrastructure.Identity.Model;
using sDGAPrueba.Infrastructure.Identity.service;

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
        
        // Configuracion de Identity
        #region Identity

        services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                // Otras configuraciones de contraseña
            })
            .AddEntityFrameworkStores<IdentityContext>()
            .AddUserManager<UserManager<ApplicationUser>>()
            .AddSignInManager<SignInManager<ApplicationUser>>()
            .AddDefaultTokenProviders();

        // Configura autenticación JWT
        var key = Encoding.ASCII.GetBytes(configuration["JWTSettings:SecretKey"]); 

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false, 
                    ValidateAudience = false, 
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero 
                };
            });

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
        services.AddTransient<IAccountService, AccountService>();
        #endregion
    }
}