using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class InitialShopItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoppingClassItems_Ebooks_EbookId",
                table: "SchoppingClassItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoppingClassItems",
                table: "SchoppingClassItems");

            migrationBuilder.RenameTable(
                name: "SchoppingClassItems",
                newName: "ShoppingClassItems");

            migrationBuilder.RenameIndex(
                name: "IX_SchoppingClassItems_EbookId",
                table: "ShoppingClassItems",
                newName: "IX_ShoppingClassItems_EbookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingClassItems",
                table: "ShoppingClassItems",
                column: "ShoppingCartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingClassItems_Ebooks_EbookId",
                table: "ShoppingClassItems",
                column: "EbookId",
                principalTable: "Ebooks",
                principalColumn: "EbookId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingClassItems_Ebooks_EbookId",
                table: "ShoppingClassItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingClassItems",
                table: "ShoppingClassItems");

            migrationBuilder.RenameTable(
                name: "ShoppingClassItems",
                newName: "SchoppingClassItems");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingClassItems_EbookId",
                table: "SchoppingClassItems",
                newName: "IX_SchoppingClassItems_EbookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoppingClassItems",
                table: "SchoppingClassItems",
                column: "ShoppingCartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoppingClassItems_Ebooks_EbookId",
                table: "SchoppingClassItems",
                column: "EbookId",
                principalTable: "Ebooks",
                principalColumn: "EbookId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
