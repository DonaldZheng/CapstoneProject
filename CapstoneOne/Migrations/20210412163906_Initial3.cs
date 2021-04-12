using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneOne.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c35424c-2fa4-4dae-9f09-d2e09d78ba07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "960e51f4-5bb8-4a94-a3a6-821c985bdeca");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4374cd3a-cb6f-40a9-a71d-46e03cb43dc6", "decedb3f-76e9-4ecd-ac6a-8f74556d6862", "Admin", "ADMIN" },
                    { "e63ca094-9838-4ab3-89c7-7ac6e4405a67", "a901cc59-cfb5-48f0-ad95-8f9871d0ad86", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "IdentityUserId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Let Us Do All The Planning For Your Date!", null, "Planner Package", 35.0 },
                    { 2, "Text/Email/Location Reminders", null, "Reminder Package", 25.0 },
                    { 3, "Too Lazy? We'll Pick You Up!", null, "Transport Package", 500.0 },
                    { 4, "Includes: Vacations, Hotels, Flights", null, "Deluxe Package", 1000.0 },
                    { 5, "Customize Your Own Package!", null, "Custom Package", 200.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4374cd3a-cb6f-40a9-a71d-46e03cb43dc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e63ca094-9838-4ab3-89c7-7ac6e4405a67");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "960e51f4-5bb8-4a94-a3a6-821c985bdeca", "ff94411b-17ca-46fc-90dc-7b6ab8910de8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c35424c-2fa4-4dae-9f09-d2e09d78ba07", "4f4adb04-784d-4ee7-b9dd-14f5963c1770", "Customer", "CUSTOMER" });
        }
    }
}
