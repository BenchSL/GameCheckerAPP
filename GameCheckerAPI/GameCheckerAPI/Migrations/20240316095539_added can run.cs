using Microsoft.EntityFrameworkCore.Migrations;

namespace GameCheckerAPI.Migrations
{
    public partial class addedcanrun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "canRun",
                table: "gameModel",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "canRun",
                table: "gameModel");
        }
    }
}
