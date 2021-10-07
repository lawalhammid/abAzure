using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class createMigration25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WemaBankCode",
                table: "TempaWalletDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WemaCollectionAcct",
                table: "TempaWalletDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WemaCollectionAcctType",
                table: "TempaWalletDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WemaBankCode",
                table: "TempaWalletDetails");

            migrationBuilder.DropColumn(
                name: "WemaCollectionAcct",
                table: "TempaWalletDetails");

            migrationBuilder.DropColumn(
                name: "WemaCollectionAcctType",
                table: "TempaWalletDetails");
        }
    }
}
