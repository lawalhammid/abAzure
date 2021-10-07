using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class createMigration33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceId",
                table: "DataSetUp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanId",
                table: "DataSetUp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestType",
                table: "DataSetUp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SimSlot",
                table: "DataSetUp",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "DataSetUp");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "DataSetUp");

            migrationBuilder.DropColumn(
                name: "RequestType",
                table: "DataSetUp");

            migrationBuilder.DropColumn(
                name: "SimSlot",
                table: "DataSetUp");
        }
    }
}
