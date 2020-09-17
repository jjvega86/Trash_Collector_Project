using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector.Data.Migrations
{
    public partial class AddCustomerModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03d3f57c-8087-47f1-ab1e-c1158b03f0fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba573863-6ae3-4755-9d0b-2e98ca64fb0f");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    CurrentBalance = table.Column<double>(nullable: false),
                    PickupDay = table.Column<string>(nullable: true),
                    IsSuspended = table.Column<bool>(nullable: false),
                    SuspendStartDate = table.Column<string>(nullable: true),
                    SuspendEndDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5db0850f-636d-4d52-930f-cf163ad6f0d4", "5b560919-f31a-4489-a826-14965b91577d", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88210483-388e-4ab2-91a9-b8d765e2bfa6", "5e3af1b9-b14e-4dbd-9662-7615de6f2e11", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5db0850f-636d-4d52-930f-cf163ad6f0d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88210483-388e-4ab2-91a9-b8d765e2bfa6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03d3f57c-8087-47f1-ab1e-c1158b03f0fe", "176a4895-2950-48b9-befd-8bd12712644c", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba573863-6ae3-4755-9d0b-2e98ca64fb0f", "9ea0dd98-4140-4390-a29a-58834a060b01", "Employee", "EMPLOYEE" });
        }
    }
}
