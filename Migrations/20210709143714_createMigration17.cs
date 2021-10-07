using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class createMigration17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AmountPerDay",
                table: "WemaUsersAccount",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPerTransaction",
                table: "WemaUsersAccount",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPerDay",
                table: "WemaUsersAccount");

            migrationBuilder.DropColumn(
                name: "AmountPerTransaction",
                table: "WemaUsersAccount");
        }
    }
}
