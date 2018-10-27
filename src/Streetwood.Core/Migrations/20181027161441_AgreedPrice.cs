using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class AgreedPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippmentDateTime",
                table: "Orders",
                newName: "ShipmentDateTime");

            migrationBuilder.RenameColumn(
                name: "PriceWithShippment",
                table: "Orders",
                newName: "ShipmentPrice");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Orders",
                newName: "BasePrice");

            migrationBuilder.AddColumn<decimal>(
                name: "AgreedPrice",
                table: "ProductOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AgreedPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgreedPrice",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "AgreedPrice",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShipmentPrice",
                table: "Orders",
                newName: "PriceWithShippment");

            migrationBuilder.RenameColumn(
                name: "ShipmentDateTime",
                table: "Orders",
                newName: "ShippmentDateTime");

            migrationBuilder.RenameColumn(
                name: "BasePrice",
                table: "Orders",
                newName: "Price");
        }
    }
}
