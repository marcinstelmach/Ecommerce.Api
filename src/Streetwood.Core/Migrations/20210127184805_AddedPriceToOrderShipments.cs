using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class AddedPriceToOrderShipments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderShipment",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderShipment");
        }
    }
}
