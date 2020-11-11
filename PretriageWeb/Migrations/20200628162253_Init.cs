using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PretriageWeb.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PretriageModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pesel = table.Column<string>(nullable: true),
                    Kod_Produktu = table.Column<string>(nullable: true),
                    Nazwa_Produktu = table.Column<string>(nullable: true),
                    Data_Od = table.Column<DateTime>(nullable: false),
                    Data_Do = table.Column<DateTime>(nullable: false),
                    Liczba_Jednostek_Roz = table.Column<int>(nullable: false),
                    Wartosc_Jednostki = table.Column<double>(nullable: false),
                    Wartosc = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PretriageModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PretriageModels");
        }
    }
}
