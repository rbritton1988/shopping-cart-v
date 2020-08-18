using Microsoft.EntityFrameworkCore.Migrations;

namespace VeygoShoppingCart.Domain.Migrations
{
    public partial class removeredundantidfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CartDiscounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CartItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CartDiscounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
