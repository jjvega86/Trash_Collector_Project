using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector.Migrations
{
    public partial class ChangedSuspendDatesToDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07107200-dec0-44ac-b95a-c0fedb1981ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "578b8594-1cdf-4e17-a745-dc1aef29b808");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SuspendStartDate",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SuspendEndDate",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad688bb9-f440-4b5a-9167-f3aee9580d4d", "287ce9dd-a819-4d53-812d-1639c9f9d031", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b093ce8e-caff-430a-80d6-6e2f1354ba1f", "3759f719-bfb6-46f5-83ad-77a243b6315c", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad688bb9-f440-4b5a-9167-f3aee9580d4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b093ce8e-caff-430a-80d6-6e2f1354ba1f");

            migrationBuilder.AlterColumn<string>(
                name: "SuspendStartDate",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SuspendEndDate",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "578b8594-1cdf-4e17-a745-dc1aef29b808", "70b0d04a-2d93-4862-8ce6-e95385da6048", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07107200-dec0-44ac-b95a-c0fedb1981ac", "e5f35554-5672-49c5-9a32-5219021088a6", "Employee", "EMPLOYEE" });
        }
    }
}
