using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class createMigration07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaceId",
                table: "TempaUsers");

            migrationBuilder.DropColumn(
                name: "FingerPrint",
                table: "TempaUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FaceId",
                table: "TempaUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FingerPrint",
                table: "TempaUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
