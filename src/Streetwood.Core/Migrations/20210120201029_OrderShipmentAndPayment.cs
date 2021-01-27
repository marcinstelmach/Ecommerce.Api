using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class OrderShipmentAndPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_PaymentId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shipments_ShipmentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShipmentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PayedDateTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipmentDateTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationDateTime",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ClosedDateTime",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OrderPayment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PaymentId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    OrderPaymentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPayment_Orders_OrderPaymentId",
                        column: x => x.OrderPaymentId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPayment_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderShipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShipmentId = table.Column<Guid>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    TrackingUrl = table.Column<string>(nullable: true),
                    TrackingId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    OrderShipmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderShipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderShipment_Orders_OrderShipmentId",
                        column: x => x.OrderShipmentId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderShipment_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayment_OrderPaymentId",
                table: "OrderPayment",
                column: "OrderPaymentId",
                unique: true,
                filter: "[OrderPaymentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayment_PaymentId",
                table: "OrderPayment",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderShipment_OrderShipmentId",
                table: "OrderShipment",
                column: "OrderShipmentId",
                unique: true,
                filter: "[OrderShipmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderShipment_ShipmentId",
                table: "OrderShipment",
                column: "ShipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPayment");

            migrationBuilder.DropTable(
                name: "OrderShipment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClosedDateTime",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayedDateTime",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ShipmentDateTime",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipmentId",
                table: "Orders",
                column: "ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_PaymentId",
                table: "Orders",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shipments_ShipmentId",
                table: "Orders",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
