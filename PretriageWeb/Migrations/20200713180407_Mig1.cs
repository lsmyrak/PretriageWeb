using Microsoft.EntityFrameworkCore.Migrations;

namespace PretriageWeb.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(nullable: true),
                    Kod_Produktu = table.Column<string>(nullable: true),
                    Nazwa_Produktu = table.Column<string>(nullable: true),
                    Liczba_Jednostek_Roz = table.Column<int>(nullable: false),
                    Wartosc_Jednostki = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigModels");
        }
    }
}
