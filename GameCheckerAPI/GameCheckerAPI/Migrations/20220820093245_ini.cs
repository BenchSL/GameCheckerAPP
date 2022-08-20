using Microsoft.EntityFrameworkCore.Migrations;

namespace GameCheckerAPI.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicsCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiskSpaceRequired = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specification", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Specifications2Games",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gameId = table.Column<int>(type: "int", nullable: true),
                    specificationid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications2Games", x => x.id);
                    table.ForeignKey(
                        name: "FK_Specifications2Games_gameModel_gameId",
                        column: x => x.gameId,
                        principalTable: "gameModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specifications2Games_Specification_specificationid",
                        column: x => x.specificationid,
                        principalTable: "Specification",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specifications2Games_gameId",
                table: "Specifications2Games",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications2Games_specificationid",
                table: "Specifications2Games",
                column: "specificationid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specifications2Games");

            migrationBuilder.DropTable(
                name: "Specification");
        }
    }
}
