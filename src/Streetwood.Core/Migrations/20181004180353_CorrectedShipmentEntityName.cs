using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class CorrectedShipmentEntityName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippments_ShippmentdId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Shippments");

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    NameEng = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionEng = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shipments_ShippmentdId",
                table: "Orders",
                column: "ShippmentdId",
                principalTable: "Shipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shipments_ShippmentdId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.CreateTable(
                name: "Shippments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DescriptionEng = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    NameEng = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippments", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shippments_ShippmentdId",
                table: "Orders",
                column: "ShippmentdId",
                principalTable: "Shippments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
