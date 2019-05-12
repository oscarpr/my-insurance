using MyInsurance.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MyInsurance.DLA
{
    public class EnsuranceContext : DbContext
    {
        public DbSet<Policy> Policies { get; set; }

        public EnsuranceContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("EnsuranceContext");
        }

        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Policy>().HasData(
                new Policy { ID = 1, Name = "Pol0001", RiskType = "Alto", Percentage = 0.3m, InitDate = "12/08/1098", Description = "Polizas para autos", CoverageTime = 12, Price = 500 }
                );

            modelBuilder.Entity<Policy>().HasData(
               new Policy { ID = 2, Name = "Pol0002", RiskType = "Medio", Percentage = 0.7m, InitDate = "12/06/1996", Description = "Polizas para tu casa", CoverageTime = 9, Price = 1500 }
               );

            modelBuilder.Entity<Policy>().HasData(
              new Policy { ID = 3, Name = "Pol0003", RiskType = "Bajo", Percentage = 0.9m, InitDate = "1/01/2012", Description = "Polizas mas caras para casa", CoverageTime = 12, Price = 800 }
               );
        }*/
    }
}
