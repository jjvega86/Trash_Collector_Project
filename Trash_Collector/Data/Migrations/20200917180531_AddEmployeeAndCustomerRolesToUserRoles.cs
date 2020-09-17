using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector.Data.Migrations
{
    public partial class AddEmployeeAndCustomerRolesToUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3db06c0a-23af-446b-a3b6-26177d79c27d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03d3f57c-8087-47f1-ab1e-c1158b03f0fe", "176a4895-2950-48b9-befd-8bd12712644c", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba573863-6ae3-4755-9d0b-2e98ca64fb0f", "9ea0dd98-4140-4390-a29a-58834a060b01", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03d3f57c-8087-47f1-ab1e-c1158b03f0fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba573863-6ae3-4755-9d0b-2e98ca64fb0f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3db06c0a-23af-446b-a3b6-26177d79c27d", "c7f251f0-17d1-4ba9-adf7-95f21e2e3cc4", "Customer", "CUSTOMER" });
        }
    }
}
