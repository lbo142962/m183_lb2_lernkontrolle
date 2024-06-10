using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmsammlung.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noten_Users_userId",
                table: "Noten");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "Upn");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Noten",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Noten",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Noten",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Noten_Users_UserId",
                table: "Noten",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noten_Users_UserId",
                table: "Noten");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Noten");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Noten");

            migrationBuilder.RenameColumn(
                name: "Upn",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Noten",
                newName: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Noten_Users_userId",
                table: "Noten",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
