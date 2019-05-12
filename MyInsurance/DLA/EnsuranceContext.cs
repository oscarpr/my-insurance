using MyInsurance.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MyInsurance.DLA
{
    public class EnsuranceContext : DbContext
    {
        public DbSet<Policy> Policies { get; set; }
        public DbSet<RiskType> RiskType { get; set; }
        public DbSet<CoverageType> CoverageType { get; set; }
        public DbSet<PolicyCoverage> PolicyCoverage { get; set; }

        public EnsuranceContext(DbContextOptions<EnsuranceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PolicyCoverage>()
                .HasKey(pc => new { pc.CoverageID, pc.PolicyID });

            modelBuilder.Entity<PolicyCoverage>()
                .HasOne(pc => pc.Coverage)
                .WithMany(c => c.PolicyCoverages)
                .HasForeignKey(pc => pc.CoverageID);

            modelBuilder.Entity<PolicyCoverage>()
                .HasOne(pc => pc.Policy)
                .WithMany(c => c.PolicyCoverage)
                .HasForeignKey(pc => pc.PolicyID);

            modelBuilder.Entity<PolicyCoverage>().HasData(
                    new PolicyCoverage { PolicyID = 1, CoverageID = 2 },
                    new PolicyCoverage { PolicyID = 1, CoverageID = 3 }
                );

            modelBuilder.Entity<CoverageType>().HasData(
                new CoverageType { ID = 1, Description = "Terremoto" },
                new CoverageType { ID = 2, Description = "Incendio" },
                new CoverageType { ID = 3, Description = "Robo" },
                new CoverageType { ID = 4, Description = "Perdida" }
                );

            modelBuilder.Entity<RiskType>().HasData(
                new RiskType { ID = 1, Description = "Bajo" },
                new RiskType { ID = 2, Description = "Medio" },
                new RiskType { ID = 3, Description = "Medio-Alto" },
                new RiskType { ID = 4, Description = "Alto" }
                );

            modelBuilder.Entity<Policy>().HasData(
               new Policy
               {
                   ID = 1,
                   Name = "Pol0001",
                   RiskTypeID = 3,
                   Percentage = 90.3m,
                   InitDate = new DateTime(1995,08,12),
                   Description = "Polizas para autos",
                   CoverageTime = 12,
                   Price = 500
               });
        }
    }
}
