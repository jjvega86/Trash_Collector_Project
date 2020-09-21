using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector.Migrations
{
    public partial class AddExtraPickUpDayRequestedPropertyToCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "696d5e81-8fac-407e-88a7-c74ae2c1b180");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edd9b00a-8b5f-47e1-a582-3d756c50f522");

            migrationBuilder.AddColumn<bool>(
                name: "ExtraPickUpDayRequested",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "188710a9-9408-4a69-9a33-1d3229410cda", "c263fc70-05da-49ad-9f08-4986571f7427", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00eec23a-c298-495c-ad77-d79d03133aaf", "f5f1ee6d-52c0-41cf-a31d-fe98fa72e5bf", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00eec23a-c298-495c-ad77-d79d03133aaf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "188710a9-9408-4a69-9a33-1d3229410cda");

            migrationBuilder.DropColumn(
                name: "ExtraPickUpDayRequested",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "696d5e81-8fac-407e-88a7-c74ae2c1b180", "d1e5d70f-b869-42e6-8c8c-9c1520d8eced", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edd9b00a-8b5f-47e1-a582-3d756c50f522", "4a3cc3ec-fc80-461d-bf2a-6807779d605c", "Employee", "EMPLOYEE" });
        }
    }
}
