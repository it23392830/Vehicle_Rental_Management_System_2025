using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VehicleRentalSystem.Data
{
    // IdentityDbContext gives you all ASP.NET Identity tables
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Add your domain entities later, e.g.:
        // public DbSet<Vehicle> Vehicles { get; set; }
    }
}
