using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector.Migrations
{
    public partial class ModifiedEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad688bb9-f440-4b5a-9167-f3aee9580d4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b093ce8e-caff-430a-80d6-6e2f1354ba1f");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Employees",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f68b1136-15a0-434a-93ef-d211db300fd1", "c852a839-d2b2-4a40-87ae-692d761c5399", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76f38816-4b1e-43ab-bc39-7c63f8ff94fb", "7ada1a2e-946e-495c-9bfd-904adf95e029", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdentityUserId",
                table: "Employees",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_IdentityUserId",
                table: "Employees",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_IdentityUserId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_IdentityUserId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76f38816-4b1e-43ab-bc39-7c63f8ff94fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f68b1136-15a0-434a-93ef-d211db300fd1");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad688bb9-f440-4b5a-9167-f3aee9580d4d", "287ce9dd-a819-4d53-812d-1639c9f9d031", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b093ce8e-caff-430a-80d6-6e2f1354ba1f", "3759f719-bfb6-46f5-83ad-77a243b6315c", "Employee", "EMPLOYEE" });
        }
    }
}
