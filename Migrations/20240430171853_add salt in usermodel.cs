using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nike_clone_Backend.Migrations
{
    /// <inheritdoc />
    public partial class addsaltinusermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "UserModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "UserModel");
        }
    }
}
