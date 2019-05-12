﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyInsurance.DLA;

namespace MyInsurance.Migrations
{
    [DbContext(typeof(EnsuranceContext))]
    [Migration("20190512205419_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("MyInsurance.Models.CoverageType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("CoverageType");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "Terremoto"
                        },
                        new
                        {
                            ID = 2,
                            Description = "Incendio"
                        },
                        new
                        {
                            ID = 3,
                            Description = "Robo"
                        },
                        new
                        {
                            ID = 4,
                            Description = "Perdida"
                        });
                });

            modelBuilder.Entity("MyInsurance.Models.Policy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("CoverageTime");

                    b.Property<string>("Description");

                    b.Property<DateTime>("InitDate");

                    b.Property<string>("Name");

                    b.Property<decimal>("Percentage");

                    b.Property<double>("Price");

                    b.Property<int>("RiskTypeID");

                    b.HasKey("ID");

                    b.HasIndex("RiskTypeID");

                    b.ToTable("Policies");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CoverageTime = 12.0,
                            Description = "Polizas para autos",
                            InitDate = new DateTime(1995, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Pol0001",
                            Percentage = 90.3m,
                            Price = 500.0,
                            RiskTypeID = 3
                        });
                });

            modelBuilder.Entity("MyInsurance.Models.PolicyCoverage", b =>
                {
                    b.Property<int>("CoverageID");

                    b.Property<int>("PolicyID");

                    b.HasKey("CoverageID", "PolicyID");

                    b.HasIndex("PolicyID");

                    b.ToTable("PolicyCoverage");

                    b.HasData(
                        new
                        {
                            CoverageID = 2,
                            PolicyID = 1
                        },
                        new
                        {
                            CoverageID = 3,
                            PolicyID = 1
                        });
                });

            modelBuilder.Entity("MyInsurance.Models.RiskType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("RiskType");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "Bajo"
                        },
                        new
                        {
                            ID = 2,
                            Description = "Medio"
                        },
                        new
                        {
                            ID = 3,
                            Description = "Medio-Alto"
                        },
                        new
                        {
                            ID = 4,
                            Description = "Alto"
                        });
                });

            modelBuilder.Entity("MyInsurance.Models.Policy", b =>
                {
                    b.HasOne("MyInsurance.Models.RiskType", "RiskType")
                        .WithMany()
                        .HasForeignKey("RiskTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyInsurance.Models.PolicyCoverage", b =>
                {
                    b.HasOne("MyInsurance.Models.CoverageType", "Coverage")
                        .WithMany("PolicyCoverages")
                        .HasForeignKey("CoverageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyInsurance.Models.Policy", "Policy")
                        .WithMany("PolicyCoverage")
                        .HasForeignKey("PolicyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
