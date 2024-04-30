using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reformation.Migrations
{
    /// <inheritdoc />
    public partial class updateUsermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone_1",
                table: "UserModel");

            migrationBuilder.RenameColumn(
                name: "Phone_2",
                table: "UserModel",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserModel",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserModel",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                table: "ProductModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserModel");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "UserModel",
                newName: "Phone_2");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "UserModel",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Phone_1",
                table: "UserModel",
                type: "nvarchar(160)",
                maxLength: 160,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Version",
                table: "ProductModel",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
