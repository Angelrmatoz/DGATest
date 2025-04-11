using Microsoft.AspNetCore.Identity;

namespace sDGAPrueba.Infrastructure.Identity.Model;

// Modelo custom de identity
public class ApplicationUser : IdentityUser
{
    public string name { get; set; }
    public string lastName { get; set; }
}