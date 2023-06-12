using Microsoft.EntityFrameworkCore.Migrations;

namespace GameCheckerAPI.Migrations
{
    public partial class nnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hardware2Users_computerHardware_computerHardwareid",
                table: "hardware2Users");

            migrationBuilder.DropForeignKey(
                name: "FK_hardware2Users_userModel_userId",
                table: "hardware2Users");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "hardware2Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "computerHardwareid",
                table: "hardware2Users",
                newName: "ComputerHardwareId");

            migrationBuilder.RenameIndex(
                name: "IX_hardware2Users_userId",
                table: "hardware2Users",
                newName: "IX_hardware2Users_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_hardware2Users_computerHardwareid",
                table: "hardware2Users",
                newName: "IX_hardware2Users_ComputerHardwareId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "hardware2Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComputerHardwareId",
                table: "hardware2Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_hardware2Users_computerHardware_ComputerHardwareId",
                table: "hardware2Users",
                column: "ComputerHardwareId",
                principalTable: "computerHardware",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hardware2Users_userModel_UserId",
                table: "hardware2Users",
                column: "UserId",
                principalTable: "userModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hardware2Users_computerHardware_ComputerHardwareId",
                table: "hardware2Users");

            migrationBuilder.DropForeignKey(
                name: "FK_hardware2Users_userModel_UserId",
                table: "hardware2Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "hardware2Users",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "ComputerHardwareId",
                table: "hardware2Users",
                newName: "computerHardwareid");

            migrationBuilder.RenameIndex(
                name: "IX_hardware2Users_UserId",
                table: "hardware2Users",
                newName: "IX_hardware2Users_userId");

            migrationBuilder.RenameIndex(
                name: "IX_hardware2Users_ComputerHardwareId",
                table: "hardware2Users",
                newName: "IX_hardware2Users_computerHardwareid");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "hardware2Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "computerHardwareid",
                table: "hardware2Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_hardware2Users_computerHardware_computerHardwareid",
                table: "hardware2Users",
                column: "computerHardwareid",
                principalTable: "computerHardware",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_hardware2Users_userModel_userId",
                table: "hardware2Users",
                column: "userId",
                principalTable: "userModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
