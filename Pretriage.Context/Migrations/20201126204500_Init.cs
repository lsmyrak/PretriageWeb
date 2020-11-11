using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pretriage.Context.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    ProductCode = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    NumberOfUnits = table.Column<int>(nullable: false),
                    UnitValue = table.Column<double>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pretriage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pesel = table.Column<string>(nullable: true),
                    InnyDokument = table.Column<string>(nullable: true),
                    NumerSeria = table.Column<string>(nullable: true),
                    Kod_Produktu = table.Column<string>(nullable: true),
                    Nazwa_Produktu = table.Column<string>(nullable: true),
                    Data_Od = table.Column<DateTime>(nullable: false),
                    Data_Do = table.Column<DateTime>(nullable: false),
                    Liczba_Jednostek_Roz = table.Column<int>(nullable: false),
                    Wartosc_Jednostki = table.Column<double>(nullable: false),
                    Wartosc = table.Column<double>(nullable: false),
                    Miejsce = table.Column<string>(nullable: true),
                    DataWpisu = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Export = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pretriage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: true),
                    HashPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Config");

            migrationBuilder.DropTable(
                name: "Pretriage");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
