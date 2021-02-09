using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class Rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPayment_Orders_OrderPaymentId",
                table: "OrderPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderShipment_Orders_OrderShipmentId",
                table: "OrderShipment");

            migrationBuilder.DropIndex(
                name: "IX_OrderShipment_OrderShipmentId",
                table: "OrderShipment");

            migrationBuilder.DropIndex(
                name: "IX_OrderPayment_OrderPaymentId",
                table: "OrderPayment");

            migrationBuilder.RenameColumn(
                name: "OrderShipmentId",
                table: "OrderShipment",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "OrderPaymentId",
                table: "OrderPayment",
                newName: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderShipment_OrderId",
                table: "OrderShipment",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayment_OrderId",
                table: "OrderPayment",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPayment_Orders_OrderId",
                table: "OrderPayment",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderShipment_Orders_OrderId",
                table: "OrderShipment",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPayment_Orders_OrderId",
                table: "OrderPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderShipment_Orders_OrderId",
                table: "OrderShipment");

            migrationBuilder.DropIndex(
                name: "IX_OrderShipment_OrderId",
                table: "OrderShipment");

            migrationBuilder.DropIndex(
                name: "IX_OrderPayment_OrderId",
                table: "OrderPayment");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderShipment",
                newName: "OrderShipmentId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderPayment",
                newName: "OrderPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderShipment_OrderShipmentId",
                table: "OrderShipment",
                column: "OrderShipmentId",
                unique: true,
                filter: "[OrderShipmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayment_OrderPaymentId",
                table: "OrderPayment",
                column: "OrderPaymentId",
                unique: true,
                filter: "[OrderPaymentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPayment_Orders_OrderPaymentId",
                table: "OrderPayment",
                column: "OrderPaymentId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderShipment_Orders_OrderShipmentId",
                table: "OrderShipment",
                column: "OrderShipmentId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
