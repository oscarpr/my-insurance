using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyInsurance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoverageType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverageType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RiskType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Percentage = table.Column<decimal>(nullable: false),
                    InitDate = table.Column<DateTime>(nullable: false),
                    CoverageTime = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    RiskTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Policies_RiskType_RiskTypeID",
                        column: x => x.RiskTypeID,
                        principalTable: "RiskType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyCoverage",
                columns: table => new
                {
                    PolicyID = table.Column<int>(nullable: false),
                    CoverageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyCoverage", x => new { x.CoverageID, x.PolicyID });
                    table.ForeignKey(
                        name: "FK_PolicyCoverage_CoverageType_CoverageID",
                        column: x => x.CoverageID,
                        principalTable: "CoverageType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyCoverage_Policies_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "Policies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CoverageType",
                columns: new[] { "ID", "Description" },
                values: new object[] { 1, "Terremoto" });

            migrationBuilder.InsertData(
                table: "CoverageType",
                columns: new[] { "ID", "Description" },
                values: new object[] { 2, "Incendio" });

            migrationBuilder.InsertData(
                table: "CoverageType",
                columns: new[] { "ID", "Description" },
                values: new object[] { 3, "Robo" });

            migrationBuilder.InsertData(
                table: "CoverageType",
                columns: new[] { "ID", "Description" },
                values: new object[] { 4, "Perdida" });

            migrationBuilder.InsertData(
                table: "RiskType",
                columns: new[] { "ID", "Description" },
                values: new object[] { 1, "Bajo" });

            migrationBuilder.InsertData(
                table: "RiskType",
                columns: new[] { "ID", "Description" },
                values: new object[] { 2, "Medio" });

            migrationBuilder.InsertData(
                table: "RiskType",
                columns: new[] { "ID", "Description" },
                values: new object[] { 3, "Medio-Alto" });

            migrationBuilder.InsertData(
                table: "RiskType",
                columns: new[] { "ID", "Description" },
                values: new object[] { 4, "Alto" });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "ID", "CoverageTime", "Description", "InitDate", "Name", "Percentage", "Price", "RiskTypeID" },
                values: new object[] { 1, 12.0, "Polizas para autos", new DateTime(1995, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pol0001", 90.3m, 500.0, 3 });

            migrationBuilder.InsertData(
                table: "PolicyCoverage",
                columns: new[] { "CoverageID", "PolicyID" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "PolicyCoverage",
                columns: new[] { "CoverageID", "PolicyID" },
                values: new object[] { 3, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Policies_RiskTypeID",
                table: "Policies",
                column: "RiskTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyCoverage_PolicyID",
                table: "PolicyCoverage",
                column: "PolicyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyCoverage");

            migrationBuilder.DropTable(
                name: "CoverageType");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "RiskType");
        }
    }
}
