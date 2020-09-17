using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector.Data.Migrations
{
    public partial class AddCustomerRoletoUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a029c68-ac0e-413a-a693-2e0adb2c19bd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3db06c0a-23af-446b-a3b6-26177d79c27d", "c7f251f0-17d1-4ba9-adf7-95f21e2e3cc4", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3db06c0a-23af-446b-a3b6-26177d79c27d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9a029c68-ac0e-413a-a693-2e0adb2c19bd", "157ed471-49b0-4aad-8574-653de50c4e2f", "Admin", "ADMIN" });
        }
    }
}
