using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class KeepingDiscountValueInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountValue",
                table: "ProductOrders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountValue",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountValue",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "DiscountValue",
                table: "Orders");
        }
    }
}
