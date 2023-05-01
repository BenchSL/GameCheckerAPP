using Microsoft.EntityFrameworkCore.Migrations;

namespace GameCheckerAPI.Migrations
{
    public partial class fffffffffff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hardware2Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: true),
                    computerHardwareid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hardware2Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_hardware2Users_computerHardware_computerHardwareid",
                        column: x => x.computerHardwareid,
                        principalTable: "computerHardware",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hardware2Users_userModel_userId",
                        column: x => x.userId,
                        principalTable: "userModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hardware2Users_computerHardwareid",
                table: "hardware2Users",
                column: "computerHardwareid");

            migrationBuilder.CreateIndex(
                name: "IX_hardware2Users_userId",
                table: "hardware2Users",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hardware2Users");
        }
    }
}
