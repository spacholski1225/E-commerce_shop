using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class ShoppingCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SchoppingClassItemId",
                table: "SchoppingClassItems",
                newName: "ShoppingCartItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingCartItemId",
                table: "SchoppingClassItems",
                newName: "SchoppingClassItemId");
        }
    }
}
