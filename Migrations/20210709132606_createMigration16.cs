using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class createMigration16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TodayDate",
                table: "WEMAVirtualAcctControl",
                newName: "TodaysDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TodaysDate",
                table: "WEMAVirtualAcctControl",
                newName: "TodayDate");
        }
    }
}
