using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class UpdatdProuctCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameEng",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductCategoryId",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductCategoryId",
                table: "ProductCategories",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ProductCategories_ProductCategoryId",
                table: "ProductCategories",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductCategories_ProductCategoryId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_ProductCategoryId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "NameEng",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "ProductCategories");
        }
    }
}
