using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector.Migrations
{
    public partial class ReseedRolesAndPickUpDayData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "803d2b02-ffb4-403b-921b-2020dc483af6", "66c75f45-38b3-4253-92aa-7f4c7fc7ffb8", "Customer", "CUSTOMER" },
                    { "dd7774ed-42bf-4150-9977-6940b0c05bc6", "8333afcf-d7b4-44eb-90c3-2a5d823b1458", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "PickUpDays",
                columns: new[] { "Id", "Date" },
                values: new object[,]
                {
                    { 1, "Monday" },
                    { 2, "Tuesday" },
                    { 3, "Wednesday" },
                    { 4, "Thursday" },
                    { 5, "Friday" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "803d2b02-ffb4-403b-921b-2020dc483af6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd7774ed-42bf-4150-9977-6940b0c05bc6");

            migrationBuilder.DeleteData(
                table: "PickUpDays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PickUpDays",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PickUpDays",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PickUpDays",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PickUpDays",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
