using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector.Migrations
{
    public partial class AddedPropertyToCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58aff708-347b-4550-935b-5f0534956e51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d67d6f3a-2429-415e-b7f9-6be0ca3bed90");

            migrationBuilder.AddColumn<string>(
                name: "ExtraPickUpDay",
                table: "Customers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "696d5e81-8fac-407e-88a7-c74ae2c1b180", "d1e5d70f-b869-42e6-8c8c-9c1520d8eced", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edd9b00a-8b5f-47e1-a582-3d756c50f522", "4a3cc3ec-fc80-461d-bf2a-6807779d605c", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "696d5e81-8fac-407e-88a7-c74ae2c1b180");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edd9b00a-8b5f-47e1-a582-3d756c50f522");

            migrationBuilder.DropColumn(
                name: "ExtraPickUpDay",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58aff708-347b-4550-935b-5f0534956e51", "d9e49098-2045-4223-b4f5-4c0c22b0ef6e", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d67d6f3a-2429-415e-b7f9-6be0ca3bed90", "52c81032-a2e7-4fda-8c82-40ada4b34e8b", "Employee", "EMPLOYEE" });
        }
    }
}
