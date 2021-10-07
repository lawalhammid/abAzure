using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class CreateMigration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditTrail",
                columns: table => new
                {
                    ItbId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailOrUserid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eventdateutc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eventtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tablename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recordid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Originalvalue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Newvalue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrail", x => x.ItbId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditTrail");
        }
    }
}
