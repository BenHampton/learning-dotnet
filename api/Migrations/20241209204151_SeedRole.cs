using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0be15f12-e0cb-4400-8db9-23417f5869b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b33320a-6d5d-472a-a1e4-288d6ba5bf7c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f7090b7-467c-4c8c-88c0-f1928353cd39", null, "Admin", "ADMIN" },
                    { "949feee7-5ed2-4514-ab38-72d221f2ffb4", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f7090b7-467c-4c8c-88c0-f1928353cd39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "949feee7-5ed2-4514-ab38-72d221f2ffb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0be15f12-e0cb-4400-8db9-23417f5869b7", null, "User", "USER" },
                    { "1b33320a-6d5d-472a-a1e4-288d6ba5bf7c", null, "Admin", "ADMIN" }
                });
        }
    }
}
