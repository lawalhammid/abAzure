using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class createMigration05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "TempaUsers",
                newName: "CACRegNo");

            migrationBuilder.AddColumn<string>(
                name: "BusinessCACDocImageCloudPath",
                table: "TempaUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessName",
                table: "TempaUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessTINNumber",
                table: "TempaUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessType",
                table: "TempaUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessCACDocImageCloudPath",
                table: "TempaUsers");

            migrationBuilder.DropColumn(
                name: "BusinessName",
                table: "TempaUsers");

            migrationBuilder.DropColumn(
                name: "BusinessTINNumber",
                table: "TempaUsers");

            migrationBuilder.DropColumn(
                name: "BusinessType",
                table: "TempaUsers");

            migrationBuilder.RenameColumn(
                name: "CACRegNo",
                table: "TempaUsers",
                newName: "CompanyName");
        }
    }
}
