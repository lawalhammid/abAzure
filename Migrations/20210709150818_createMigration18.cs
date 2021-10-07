using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationApi.Migrations
{
    public partial class createMigration18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TokenWEMA");
        }
    }
}
