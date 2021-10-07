using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class CreateMigration40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AmountToPay",
                table: "TransactionLog",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountToPay",
                table: "TransactionLog");
        }
    }
}
