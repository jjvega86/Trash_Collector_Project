using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector.Migrations
{
    public partial class DeletedPropertyFromCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76f38816-4b1e-43ab-bc39-7c63f8ff94fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f68b1136-15a0-434a-93ef-d211db300fd1");

            migrationBuilder.DropColumn(
                name: "ExtraPickUpDayRequested",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aedbd054-6596-455f-a270-d8f013891662", "0f691407-d158-4a91-acc1-d2ba26aab1c7", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c8a8465f-2688-4d93-8c8d-16aac624efe4", "70c41e6d-163a-4566-8361-dea08052d737", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aedbd054-6596-455f-a270-d8f013891662");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8a8465f-2688-4d93-8c8d-16aac624efe4");

            migrationBuilder.AddColumn<bool>(
                name: "ExtraPickUpDayRequested",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f68b1136-15a0-434a-93ef-d211db300fd1", "c852a839-d2b2-4a40-87ae-692d761c5399", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76f38816-4b1e-43ab-bc39-7c63f8ff94fb", "7ada1a2e-946e-495c-9bfd-904adf95e029", "Employee", "EMPLOYEE" });
        }
    }
}
