using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPocketAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPassword_User_IdUser",
                table: "UserPassword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPassword",
                table: "UserPassword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "UserPassword",
                newName: "UsersPassword");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_UserPassword_IdUser",
                table: "UsersPassword",
                newName: "IX_UsersPassword_IdUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersPassword",
                table: "UsersPassword",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersPassword_Users_IdUser",
                table: "UsersPassword",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersPassword_Users_IdUser",
                table: "UsersPassword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersPassword",
                table: "UsersPassword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "UsersPassword",
                newName: "UserPassword");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_UsersPassword_IdUser",
                table: "UserPassword",
                newName: "IX_UserPassword_IdUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPassword",
                table: "UserPassword",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPassword_User_IdUser",
                table: "UserPassword",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
