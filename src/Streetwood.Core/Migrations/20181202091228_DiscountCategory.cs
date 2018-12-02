using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class DiscountCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductCategoryDiscounts_ProductCategoryDiscountId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_ProductCategoryDiscountId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ProductCategoryDiscountId",
                table: "ProductCategories");

            migrationBuilder.CreateTable(
                name: "DiscountCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductCategoryId = table.Column<Guid>(nullable: true),
                    ProductCategoryDiscountId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountCategories_ProductCategoryDiscounts_ProductCategoryDiscountId",
                        column: x => x.ProductCategoryDiscountId,
                        principalTable: "ProductCategoryDiscounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountCategories_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCategories_ProductCategoryDiscountId",
                table: "DiscountCategories",
                column: "ProductCategoryDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCategories_ProductCategoryId",
                table: "DiscountCategories",
                column: "ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountCategories");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductCategoryDiscountId",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductCategoryDiscountId",
                table: "ProductCategories",
                column: "ProductCategoryDiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ProductCategoryDiscounts_ProductCategoryDiscountId",
                table: "ProductCategories",
                column: "ProductCategoryDiscountId",
                principalTable: "ProductCategoryDiscounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
