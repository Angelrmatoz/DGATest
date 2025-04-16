using DGAPrueba.Core.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace DGAPrueba.Infrastructure.Persistence.Context;

//contexto de la base de datos 
//se encarga de la comunicacion entre la base de datos y el sistema
public class DGAContext : DbContext
{
    public DGAContext(DbContextOptions<DGAContext> options) : base(options)
    {
    }
    
    //DbSet para las entidades
    public DbSet<Product> Products { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Sales> Sales { get; set; }
    public DbSet<SaleProduct> SaleProduct { get; set; }
    
    //configuracion de la base de datos

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //configuracion de las entidades

        #region Tables
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<Client>().ToTable("Clients");
        modelBuilder.Entity<Sales>().ToTable("Sales");
        modelBuilder.Entity<SaleProduct>().ToTable("SaleProduct");
        #endregion

        #region PK
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Client>().HasKey(c => c.Id);
        modelBuilder.Entity<Sales>().HasKey(s => s.Id);
        modelBuilder.Entity<SaleProduct>().HasKey(s => s.Id);
        #endregion

        #region FK

        modelBuilder.Entity<Sales>()
            .HasOne(x => x.Client)
            .WithMany(x => x.Sales)
            .HasForeignKey(s => s.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<SaleProduct>()
            .HasOne(sp => sp.Sales)
            .WithMany(sp => sp.SaleProducts)
            .HasForeignKey(sp => sp.SalesId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<SaleProduct>()
            .HasOne(sp => sp.Product)
            .WithMany(sp => sp.SaleProducts)
            .HasForeignKey(sp => sp.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        
        #endregion
    }
}