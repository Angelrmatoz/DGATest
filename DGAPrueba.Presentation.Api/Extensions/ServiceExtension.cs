using Microsoft.OpenApi.Models;

namespace DGAPrueba.Presentation.Api.Extensions;

public static class ServiceExtension
{
    public static void AddSwaggerExtension(this IServiceCollection services)
    {
        //Swagger Documentation
        services.AddSwaggerGen(op =>
        {
            op.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "DGAPrueba API",
                Description = "Test para la prueba de la DGA",
                Contact = new OpenApiContact
                {
                    Name = "Hansel Rodriguez"
                }
            });
        });

        services.AddSwaggerGen(c =>
        {
            //Definicion de seguridad para el token JWT
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Input your Bearer token in this format - Bearer {your token here}"
            });
            
            //requerimiento de seguridad para el token JWT
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "Bearer",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });
        
        
    } 
}