using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class AddedPhoneNumberToAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "ProductOrderCharms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "OrderDiscounts",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_OrderDiscounts_Code",
                table: "OrderDiscounts",
                column: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_OrderDiscounts_Code",
                table: "OrderDiscounts");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "ProductOrderCharms");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "OrderDiscounts",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
