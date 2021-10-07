using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class createMigration35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionLog",
                columns: table => new
                {
                    TId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TempaTransRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankTransRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIPTransRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempaTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransCompleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceBeforePosting = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BalanceAfterPosting = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChargeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrAcct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrAcctName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrAcct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrAcctName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrBankCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrBankCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrBankBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrBankBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrAcctBBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrAcctBBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransResponsecode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransResponseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Naration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrAcctEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrAcctPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrAcctEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrAcctPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Channel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrAcctStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrAcctStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateVerified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateAuthorised = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateRejected = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SequenceNo = table.Column<int>(type: "int", nullable: false),
                    IsBulkTransfer = table.Column<bool>(type: "bit", nullable: true),
                    TranCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Reversal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReversalResponseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReversalResponseText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTransResponseText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGroupTrans = table.Column<bool>(type: "bit", nullable: true),
                    ApproveBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GroupTag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLog", x => x.TId);
                });

            migrationBuilder.CreateTable(
                name: "UsersPin",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Channel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempaTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPin", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionLog");

            migrationBuilder.DropTable(
                name: "UsersPin");
        }
    }
}
