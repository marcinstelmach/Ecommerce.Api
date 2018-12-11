using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class TyposAndOrderDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shipments_ShippmentdId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShippmentdId",
                table: "Orders",
                newName: "ShipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ShippmentdId",
                table: "Orders",
                newName: "IX_Orders_ShipmentId");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "OrderDiscounts",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shipments_ShipmentId",
                table: "Orders",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shipments_ShipmentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "OrderDiscounts");

            migrationBuilder.RenameColumn(
                name: "ShipmentId",
                table: "Orders",
                newName: "ShippmentdId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ShipmentId",
                table: "Orders",
                newName: "IX_Orders_ShippmentdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shipments_ShippmentdId",
                table: "Orders",
                column: "ShippmentdId",
                principalTable: "Shipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
