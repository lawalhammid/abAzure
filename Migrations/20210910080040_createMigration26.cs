using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class createMigration26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempaUsers");

            migrationBuilder.DropTable(
                name: "TokenWEMA");

            migrationBuilder.RenameColumn(
                name: "WemaCollectionAcctType",
                table: "TempaWalletDetails",
                newName: "WalletAcct");

            migrationBuilder.RenameColumn(
                name: "WemaCollectionAcct",
                table: "TempaWalletDetails",
                newName: "Tag");

            migrationBuilder.RenameColumn(
                name: "WemaBankCode",
                table: "TempaWalletDetails",
                newName: "CollectionAcctType");

            migrationBuilder.RenameColumn(
                name: "TempaTag",
                table: "TempaWalletDetails",
                newName: "CollectionAcct");

            migrationBuilder.RenameColumn(
                name: "BankAcct",
                table: "TempaWalletDetails",
                newName: "CollectBankCode");

            migrationBuilder.RenameColumn(
                name: "TempaTag",
                table: "OnboardActivationDetails",
                newName: "Tag");

            migrationBuilder.RenameColumn(
                name: "TempaTag",
                table: "GroupUsers",
                newName: "Tag");

            migrationBuilder.RenameColumn(
                name: "TempaTag",
                table: "CorporateUsers",
                newName: "Tag");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Channel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempaTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CACRegNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessTINNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessCACDocImageCloudPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAcct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAcctName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAcctCreationResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferralCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiveLatestNews = table.Column<bool>(type: "bit", nullable: true),
                    GroupTag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "WalletAcct",
                table: "TempaWalletDetails",
                newName: "WemaCollectionAcctType");

            migrationBuilder.RenameColumn(
                name: "Tag",
                table: "TempaWalletDetails",
                newName: "WemaCollectionAcct");

            migrationBuilder.RenameColumn(
                name: "CollectionAcctType",
                table: "TempaWalletDetails",
                newName: "WemaBankCode");

            migrationBuilder.RenameColumn(
                name: "CollectionAcct",
                table: "TempaWalletDetails",
                newName: "TempaTag");

            migrationBuilder.RenameColumn(
                name: "CollectBankCode",
                table: "TempaWalletDetails",
                newName: "BankAcct");

            migrationBuilder.RenameColumn(
                name: "Tag",
                table: "OnboardActivationDetails",
                newName: "TempaTag");

            migrationBuilder.RenameColumn(
                name: "Tag",
                table: "GroupUsers",
                newName: "TempaTag");

            migrationBuilder.RenameColumn(
                name: "Tag",
                table: "CorporateUsers",
                newName: "TempaTag");

            migrationBuilder.CreateTable(
                name: "TempaUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankAcct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAcctCreationResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAcctName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessCACDocImageCloudPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessTINNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CACRegNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Channel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    ReceiveLatestNews = table.Column<bool>(type: "bit", nullable: true),
                    ReferralCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TempaTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempaUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TokenWEMA",
                columns: table => new
                {
                    Auth1 = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Auth2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenWEMA", x => x.Auth1);
                });

            migrationBuilder.InsertData(
                table: "TokenWEMA",
                columns: new[] { "Auth1", "Auth2" },
                values: new object[] { 987234100054211L, "GTUENNWEMAtyhae562hytevs" });
        }
    }
}
