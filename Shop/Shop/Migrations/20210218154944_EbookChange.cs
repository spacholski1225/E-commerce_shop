using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class EbookChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ebooks_Category_CategoryId",
                table: "Ebooks");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Ebooks_CategoryId",
                table: "Ebooks");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Ebooks",
                newName: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Ebooks",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Ebooks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Ebooks");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Ebooks",
                newName: "CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Ebooks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ebooks_CategoryId",
                table: "Ebooks",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ebooks_Category_CategoryId",
                table: "Ebooks",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
