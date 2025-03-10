using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Managment.Application._Data.Migrations
{
    /// <inheritdoc />
    public partial class product_description_adjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(Max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "NVARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(Max)");
        }
    }
}
