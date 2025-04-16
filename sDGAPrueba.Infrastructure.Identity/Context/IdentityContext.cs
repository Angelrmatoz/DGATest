using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sDGAPrueba.Infrastructure.Identity.Model;

namespace sDGAPrueba.Infrastructure.Identity.Context;

public class IdentityContext : IdentityDbContext<ApplicationUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Fluent API
        
        base.OnModelCreating(builder); 

        // Shema por defecto
        builder.HasDefaultSchema("Identity");

        // Cambiar el nombre de las tablas
        builder.Entity<ApplicationUser>().ToTable("Users");
        
        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.ToTable("UserLogins");
            entity.HasKey(l => new { l.LoginProvider, l.ProviderKey }); // CLAVE PRIMARIA
        });

        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");

        builder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.ToTable("UserTokens");
            entity.HasKey(t => new { t.UserId, t.LoginProvider, t.Name }); //Otra clave compuesta
        });

        //Ignorar lo que no se va a usar
        builder.Ignore<IdentityRole>();
        builder.Ignore<IdentityUserRole<string>>();
        builder.Ignore<IdentityRoleClaim<string>>();

    }
    
}