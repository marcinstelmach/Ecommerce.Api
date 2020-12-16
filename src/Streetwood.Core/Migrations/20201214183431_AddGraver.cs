using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class AddGraver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ProductCategoryId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AcceptGraver",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Graver",
                table: "ProductOrders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptGraver",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Graver",
                table: "ProductOrders");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductCategoryId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(Guid));
        }
    }
}
