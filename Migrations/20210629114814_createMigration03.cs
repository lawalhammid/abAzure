using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class createMigration03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tempaUsers",
                table: "tempaUsers");

            migrationBuilder.RenameTable(
                name: "tempaUsers",
                newName: "TempaUsers");

            migrationBuilder.AddColumn<string>(
                name: "BankAcctCreationResponse",
                table: "TempaUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAcctName",
                table: "TempaUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TempaUsers",
                table: "TempaUsers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TempaUsers",
                table: "TempaUsers");

            migrationBuilder.DropColumn(
                name: "BankAcctCreationResponse",
                table: "TempaUsers");

            migrationBuilder.DropColumn(
                name: "BankAcctName",
                table: "TempaUsers");

            migrationBuilder.RenameTable(
                name: "TempaUsers",
                newName: "tempaUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tempaUsers",
                table: "tempaUsers",
                column: "Id");
        }
    }
}
