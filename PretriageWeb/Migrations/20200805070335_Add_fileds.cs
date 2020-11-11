using Microsoft.EntityFrameworkCore.Migrations;

namespace PretriageWeb.Migrations
{
    public partial class Add_fileds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Miejsce",
                table: "Pretriage",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Pretriage",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Miejsce",
                table: "Pretriage");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pretriage");
        }
    }
}
