using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class createMigration14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupTag",
                table: "TempaUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupTag",
                table: "TempaUsers");
        }
    }
}
