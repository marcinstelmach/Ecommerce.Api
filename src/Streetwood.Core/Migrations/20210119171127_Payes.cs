using Microsoft.EntityFrameworkCore.Migrations;

namespace Streetwood.Core.Migrations
{
    public partial class Payes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountNumber",
                table: "Payments",
                nullable: true);

            migrationBuilder.Sql(
                "INSERT INTO [Payments] ([Id], [Name], [NameEng], [PaymentType], [AccountNumber]) VALUES(NEWID(), 'Przelew bankowy', 'Bank transfer', 1, 25487556)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Payments");
        }
    }
}
