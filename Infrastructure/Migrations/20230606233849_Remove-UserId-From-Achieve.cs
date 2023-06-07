using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserIdFromAchieve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserAchievements");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a92589c-7415-4f0a-b98r-ad4d0d6iu174",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6548c3e-fff9-4865-9a58-9639b5aa615c", "AQAAAAIAAYagAAAAEJzAf0oOOsJws70NwE+VZvuRk27/mX2P1qpYUHw24VyBZv/fkRWdfVXwJsilhRxR5A==", "ec1c3f8d-0bc7-4ce9-8e81-dabf941a5c1b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserAchievements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a92589c-7415-4f0a-b98r-ad4d0d6iu174",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "debe4d7c-8634-4fd5-ad23-8e01139b6b74", "AQAAAAIAAYagAAAAEKm15JMpImVv5az63MsIDY68qZRmapLNZwOKGvGcICRzolEcqRTgrOGkWjlaz6EgXA==", "291d0918-22f8-4e68-8239-3a48d62c51d3" });
        }
    }
}
