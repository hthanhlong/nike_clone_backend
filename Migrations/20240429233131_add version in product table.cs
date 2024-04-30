using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reformation.Migrations
{
    /// <inheritdoc />
    public partial class addversioninproducttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "ProductModel",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "ProductModel");
        }
    }
}
