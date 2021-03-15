using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class PaymentOnDelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipmentPrice",
                table: "Orders");

            migrationBuilder.AlterColumn<long>(
                name: "AccountNumber",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.Sql("INSERT INTO [Payments] ([Id], [Name], [NameEng], [PaymentType]) VALUES (NEWID(), 'Za pobraniem', 'Payment on delivery', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccountNumber",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ShipmentPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
