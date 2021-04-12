using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneOne.Migrations
{
    public partial class AdminFolder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0619b2ad-17e0-4fde-aa95-ef844a201989");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6dbb239-9871-456f-84bf-6804768a2e0e");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Admins");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Admins",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "AdminId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4726af2a-3487-46b3-9bd4-62395e6ad336", "b13c9499-971b-48fc-9a76-92f1c15a71c8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9881072-845e-4ea9-bb52-8439474d8d18", "e8e3a544-dd4c-43ee-a295-720efbc99611", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4726af2a-3487-46b3-9bd4-62395e6ad336");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9881072-845e-4ea9-bb52-8439474d8d18");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Admins");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0619b2ad-17e0-4fde-aa95-ef844a201989", "aeb2af4a-ed58-4e27-97c1-81a6277524d2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c6dbb239-9871-456f-84bf-6804768a2e0e", "2c51ff97-675e-4fc7-98a9-259e83b9b171", "Customer", "CUSTOMER" });
        }
    }
}
