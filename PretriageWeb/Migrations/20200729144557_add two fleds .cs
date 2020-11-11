using Microsoft.EntityFrameworkCore.Migrations;

namespace PretriageWeb.Migrations
{
    public partial class addtwofleds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HaslPassword",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "HashPassword",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InnyDokument",
                table: "PretriageModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumerSeria",
                table: "PretriageModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashPassword",
                table: "User");

            migrationBuilder.DropColumn(
                name: "InnyDokument",
                table: "PretriageModels");

            migrationBuilder.DropColumn(
                name: "NumerSeria",
                table: "PretriageModels");

            migrationBuilder.AddColumn<string>(
                name: "HaslPassword",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
