using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class OrderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdressLine2",
                table: "Orders",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "AdressLine1",
                table: "Orders",
                newName: "AddressLine2");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Orders",
                newName: "AdressLine2");

            migrationBuilder.RenameColumn(
                name: "AddressLine2",
                table: "Orders",
                newName: "AdressLine1");
        }
    }
}
