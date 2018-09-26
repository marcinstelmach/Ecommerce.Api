using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharmCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharmCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDiscounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    NameEng = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionEng = table.Column<string>(nullable: true),
                    PercentValue = table.Column<decimal>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AvaibleFrom = table.Column<DateTime>(nullable: false),
                    AvaibleTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDiscounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryDiscounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    NameEng = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionEng = table.Column<string>(nullable: true),
                    PercentValue = table.Column<decimal>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AvaibleFrom = table.Column<DateTime>(nullable: false),
                    AvaibleTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryDiscounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shippments",
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
                    table.PrimaryKey("PK_Shippments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 30, nullable: true),
                    LastName = table.Column<string>(maxLength: 40, nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    ChangePasswordToken = table.Column<string>(nullable: true),
                    UserStatus = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Charms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameEng = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CharmCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charms_CharmCategories_CharmCategoryId",
                        column: x => x.CharmCategoryId,
                        principalTable: "CharmCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    ProductCategoryDiscountId = table.Column<Guid>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategoryDiscounts_ProductCategoryDiscountId",
                        column: x => x.ProductCategoryDiscountId,
                        principalTable: "ProductCategoryDiscounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(maxLength: 8, nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsShipped = table.Column<bool>(nullable: false),
                    IsPayed = table.Column<bool>(nullable: false),
                    IsClosed = table.Column<bool>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PriceWithShippment = table.Column<decimal>(nullable: false),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    PayedDateTime = table.Column<DateTime>(nullable: true),
                    ShippmentDateTime = table.Column<DateTime>(nullable: true),
                    ClosedDateTime = table.Column<DateTime>(nullable: true),
                    ShippmentdId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    OrderDiscountId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderDiscounts_OrderDiscountId",
                        column: x => x.OrderDiscountId,
                        principalTable: "OrderDiscounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Shippments_ShippmentdId",
                        column: x => x.ShippmentdId,
                        principalTable: "Shippments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    NameEng = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DescriptionEng = table.Column<string>(nullable: true),
                    AcceptCharms = table.Column<bool>(nullable: false),
                    Sizes = table.Column<string>(maxLength: 50, nullable: true),
                    ProductCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsMain = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    CurrentProductPrice = table.Column<decimal>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ProductCategoryDiscountId = table.Column<Guid>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrders_ProductCategoryDiscounts_ProductCategoryDiscountId",
                        column: x => x.ProductCategoryDiscountId,
                        principalTable: "ProductCategoryDiscounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrderCharms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CurrentPrice = table.Column<decimal>(nullable: false),
                    CharmId = table.Column<Guid>(nullable: true),
                    ProductOrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrderCharms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOrderCharms_Charms_CharmId",
                        column: x => x.CharmId,
                        principalTable: "Charms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOrderCharms_ProductOrders_ProductOrderId",
                        column: x => x.ProductOrderId,
                        principalTable: "ProductOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Charms_CharmCategoryId",
                table: "Charms",
                column: "CharmCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderDiscountId",
                table: "Orders",
                column: "OrderDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippmentdId",
                table: "Orders",
                column: "ShippmentdId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductCategoryDiscountId",
                table: "ProductCategories",
                column: "ProductCategoryDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderCharms_CharmId",
                table: "ProductOrderCharms",
                column: "CharmId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderCharms_ProductOrderId",
                table: "ProductOrderCharms",
                column: "ProductOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_OrderId",
                table: "ProductOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ProductCategoryDiscountId",
                table: "ProductOrders",
                column: "ProductCategoryDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ProductId",
                table: "ProductOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ProductOrderCharms");

            migrationBuilder.DropTable(
                name: "Charms");

            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "CharmCategories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "OrderDiscounts");

            migrationBuilder.DropTable(
                name: "Shippments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ProductCategoryDiscounts");
        }
    }
}
