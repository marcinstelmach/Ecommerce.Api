using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class ItemStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Charms",
                newName: "ImagePath");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProductCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameEng",
                table: "CharmCategories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CharmCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UniqueName",
                table: "CharmCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "NameEng",
                table: "CharmCategories");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CharmCategories");

            migrationBuilder.DropColumn(
                name: "UniqueName",
                table: "CharmCategories");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Charms",
                newName: "ImageUrl");
        }
    }
}
