using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class createMigration31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirTimeSetUp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountToDisplay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountToSendToServiceProvider = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirTimeSetUp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataSetUp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountToDisplay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountToSendToServiceProvider = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSetUp", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirTimeSetUp");

            migrationBuilder.DropTable(
                name: "DataSetUp");
        }
    }
}
