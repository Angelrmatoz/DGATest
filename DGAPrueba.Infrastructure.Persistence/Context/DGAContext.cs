using Microsoft.EntityFrameworkCore;

namespace DGAPrueba.Infrastructure.Persistence.Context;

//contexto de la base de datos 
//se encarga de la comunicacion entre la base de datos y el sistema
public class DGAContext : DbContext
{
    public DGAContext(DbContextOptions options) : base(options)
    {
    }
    
}