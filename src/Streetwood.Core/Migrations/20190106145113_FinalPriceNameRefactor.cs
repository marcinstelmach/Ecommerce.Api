using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class FinalPriceNameRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AgreedPrice",
                table: "ProductOrders",
                newName: "FinalPrice");

            migrationBuilder.RenameColumn(
                name: "AgreedPrice",
                table: "Orders",
                newName: "FinalPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "CharmsPrice",
                table: "ProductOrders",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharmsPrice",
                table: "ProductOrders");

            migrationBuilder.RenameColumn(
                name: "FinalPrice",
                table: "ProductOrders",
                newName: "AgreedPrice");

            migrationBuilder.RenameColumn(
                name: "FinalPrice",
                table: "Orders",
                newName: "AgreedPrice");
        }
    }
}
