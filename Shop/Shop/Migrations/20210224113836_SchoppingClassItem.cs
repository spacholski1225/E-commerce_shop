using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class SchoppingClassItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoppingClassItems",
                columns: table => new
                {
                    SchoppingClassItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EbookId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ShoppingCardId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoppingClassItems", x => x.SchoppingClassItemId);
                    table.ForeignKey(
                        name: "FK_SchoppingClassItems_Ebooks_EbookId",
                        column: x => x.EbookId,
                        principalTable: "Ebooks",
                        principalColumn: "EbookId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoppingClassItems_EbookId",
                table: "SchoppingClassItems",
                column: "EbookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoppingClassItems");
        }
    }
}
