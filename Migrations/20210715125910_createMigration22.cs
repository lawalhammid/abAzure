using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class createMigration22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Chanel",
                table: "GroupUsers",
                newName: "Channel");

            migrationBuilder.RenameColumn(
                name: "Chanel",
                table: "CorporateUsers",
                newName: "Channel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Channel",
                table: "GroupUsers",
                newName: "Chanel");

            migrationBuilder.RenameColumn(
                name: "Channel",
                table: "CorporateUsers",
                newName: "Chanel");
        }
    }
}
