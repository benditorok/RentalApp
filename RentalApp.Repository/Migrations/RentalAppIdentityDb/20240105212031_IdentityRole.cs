using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalApp.Repository.Migrations.RentalAppIdentityDb
{
    /// <inheritdoc />
    public partial class IdentityRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3038C8A9-E8D1-4A4E-A6A8-46A8EA38AD89", null, "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "69CA1A13-F868-42D2-8F5F-C6650B9BE577", 0, "57e96da2-cf8d-4caf-984c-901d323e6491", null, false, false, null, null, "MAINMANAGER", "AQAAAAIAAYagAAAAEH0n03wr/QMYr9///8IpKxzprWLiKPiNrkLz64oshuuTVogTzOYwCy6FdYvyYeVH+g==", null, false, "9bf4f125-1058-4c14-a750-35d5638a3a50", false, "mainManager" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3038C8A9-E8D1-4A4E-A6A8-46A8EA38AD89", "69CA1A13-F868-42D2-8F5F-C6650B9BE577" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3038C8A9-E8D1-4A4E-A6A8-46A8EA38AD89", "69CA1A13-F868-42D2-8F5F-C6650B9BE577" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3038C8A9-E8D1-4A4E-A6A8-46A8EA38AD89");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69CA1A13-F868-42D2-8F5F-C6650B9BE577");
        }
    }
}
