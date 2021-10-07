using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class createMigration27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAcct",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "BankAcctName",
                table: "Users",
                newName: "WalletAcctName");

            migrationBuilder.RenameColumn(
                name: "BankAcctCreationResponse",
                table: "Users",
                newName: "WalletAcct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WalletAcctName",
                table: "Users",
                newName: "BankAcctName");

            migrationBuilder.RenameColumn(
                name: "WalletAcct",
                table: "Users",
                newName: "BankAcctCreationResponse");

            migrationBuilder.AddColumn<string>(
                name: "BankAcct",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
