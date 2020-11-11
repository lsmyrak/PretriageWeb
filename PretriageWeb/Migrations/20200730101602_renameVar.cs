using Microsoft.EntityFrameworkCore.Migrations;

namespace PretriageWeb.Migrations
{
    public partial class renameVar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PretriageModels",
                table: "PretriageModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigModels",
                table: "ConfigModels");

            migrationBuilder.RenameTable(
                name: "PretriageModels",
                newName: "Pretriage");

            migrationBuilder.RenameTable(
                name: "ConfigModels",
                newName: "Config");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pretriage",
                table: "Pretriage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Config",
                table: "Config",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pretriage",
                table: "Pretriage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Config",
                table: "Config");

            migrationBuilder.RenameTable(
                name: "Pretriage",
                newName: "PretriageModels");

            migrationBuilder.RenameTable(
                name: "Config",
                newName: "ConfigModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PretriageModels",
                table: "PretriageModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigModels",
                table: "ConfigModels",
                column: "Id");
        }
    }
}
