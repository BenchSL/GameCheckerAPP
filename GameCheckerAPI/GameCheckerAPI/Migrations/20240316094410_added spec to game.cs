using Microsoft.EntityFrameworkCore.Migrations;

namespace GameCheckerAPI.Migrations
{
    public partial class addedspectogame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cpu",
                table: "gameModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gpu",
                table: "gameModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ram",
                table: "gameModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cpu",
                table: "gameModel");

            migrationBuilder.DropColumn(
                name: "gpu",
                table: "gameModel");

            migrationBuilder.DropColumn(
                name: "ram",
                table: "gameModel");
        }
    }
}
