using MyInsurance.Models;
using Microsoft.EntityFrameworkCore;

namespace MyInsurance.DLA
{
    public class EnsuranceContext : DbContext
    {
        public DbSet<Policy> Policies { get; set; }

        public EnsuranceContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Policy>().HasData(
                new Policy { Name = "Pol0001", RiskType = "Alto", Percentage = 0.3m, InitDate = new DateTime(2009, 08, 28), Description = "Polizas para autos", CoverageTime = 12, Coverages = new List<string> { "Perdida", "Robo" }, Price = 500 },
                new Policy { Name = "Pol0002", RiskType = "Medio", Percentage = 0.7m, InitDate = new DateTime(2019, 03, 12), Description = "Polizas para tu casa", CoverageTime = 9, Coverages = new List<string> { "Robo", "Terremoto", "Secuestro" }, Price = 1500 },
                new Policy { Name = "Pol0003", RiskType = "Bajo", Percentage = 0.9m, InitDate = new DateTime(2018, 03, 17), Description = "Polizas mas caras para casa", CoverageTime = 12, Coverages = new List<string> { "Perdida", "Robo", "Incendio" }, Price = 800 }
                );
        }
    }
}
