using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42567b4b-33et-384r-5778-cg215d990e3c", null, "User", "USER" },
                    { "94522b4b-23eb-344a-2278-cg215d880e3c", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9a92589c-7415-4f0a-b98r-ad4d0d6iu174", 0, "debe4d7c-8634-4fd5-ad23-8e01139b6b74", null, false, false, null, null, null, "AQAAAAIAAYagAAAAEKm15JMpImVv5az63MsIDY68qZRmapLNZwOKGvGcICRzolEcqRTgrOGkWjlaz6EgXA==", null, false, "291d0918-22f8-4e68-8239-3a48d62c51d3", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "94522b4b-23eb-344a-2278-cg215d880e3c", "9a92589c-7415-4f0a-b98r-ad4d0d6iu174" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42567b4b-33et-384r-5778-cg215d990e3c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94522b4b-23eb-344a-2278-cg215d880e3c", "9a92589c-7415-4f0a-b98r-ad4d0d6iu174" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94522b4b-23eb-344a-2278-cg215d880e3c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a92589c-7415-4f0a-b98r-ad4d0d6iu174");
        }
    }
}
