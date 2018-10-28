using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class TypoRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvaibleTo",
                table: "ProductCategoryDiscounts",
                newName: "AvailableTo");

            migrationBuilder.RenameColumn(
                name: "AvaibleFrom",
                table: "ProductCategoryDiscounts",
                newName: "AvailableFrom");

            migrationBuilder.RenameColumn(
                name: "AvaibleTo",
                table: "OrderDiscounts",
                newName: "AvailableTo");

            migrationBuilder.RenameColumn(
                name: "AvaibleFrom",
                table: "OrderDiscounts",
                newName: "AvailableFrom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailableTo",
                table: "ProductCategoryDiscounts",
                newName: "AvaibleTo");

            migrationBuilder.RenameColumn(
                name: "AvailableFrom",
                table: "ProductCategoryDiscounts",
                newName: "AvaibleFrom");

            migrationBuilder.RenameColumn(
                name: "AvailableTo",
                table: "OrderDiscounts",
                newName: "AvaibleTo");

            migrationBuilder.RenameColumn(
                name: "AvailableFrom",
                table: "OrderDiscounts",
                newName: "AvaibleFrom");
        }
    }
}
