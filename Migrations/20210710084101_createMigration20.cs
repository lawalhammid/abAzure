using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class createMigration20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "WemaUsersAccount",
                newName: "RegistrationStatus");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "TempaUsers",
                newName: "RegistrationStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistrationStatus",
                table: "WemaUsersAccount",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "RegistrationStatus",
                table: "TempaUsers",
                newName: "Status");
        }
    }
}
