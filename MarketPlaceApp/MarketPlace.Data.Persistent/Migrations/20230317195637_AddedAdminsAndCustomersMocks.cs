using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarketPlace.Data.Persistent.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdminsAndCustomersMocks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Email", "FirstName", "IsActive", "LastModified", "LastName", "Login", "PasswordHash", "PasswordSalt", "RoleId" },
                values: new object[,]
                {
                    { 111L, new DateTime(2023, 3, 17, 19, 56, 37, 806, DateTimeKind.Utc).AddTicks(2741), "admin@mail.ru", "admin", true, new DateTime(2023, 3, 17, 19, 56, 37, 806, DateTimeKind.Utc).AddTicks(2744), "admin", "admin", new byte[] { 105, 114, 158, 37, 144, 254, 152, 44, 93, 8, 87, 226, 18, 231, 191, 140, 154, 103, 234, 106, 200, 146, 14, 228, 223, 51, 113, 50, 237, 211, 207, 237, 110, 45, 76, 50, 155, 219, 2, 23, 241, 205, 156, 243, 144, 254, 153, 237, 197, 140, 134, 200, 94, 154, 134, 121, 174, 118, 85, 88, 114, 70, 48, 195 }, new byte[] { 107, 89, 207, 14, 220, 42, 76, 43, 110, 116, 155, 162, 135, 249, 168, 175, 203, 193, 113, 116, 54, 142, 46, 231, 49, 58, 127, 51, 62, 50, 145, 27, 147, 196, 95, 12, 110, 154, 147, 143, 56, 185, 7, 46, 222, 243, 81, 86, 97, 124, 241, 175, 218, 109, 28, 114, 47, 74, 164, 200, 83, 212, 17, 118, 83, 30, 43, 66, 45, 125, 112, 240, 77, 252, 65, 49, 17, 222, 17, 253, 229, 181, 253, 163, 251, 98, 248, 55, 215, 148, 199, 64, 226, 170, 214, 22, 111, 149, 166, 71, 15, 10, 235, 16, 221, 239, 218, 182, 96, 107, 197, 111, 210, 63, 156, 230, 21, 124, 109, 20, 188, 115, 126, 237, 4, 149, 55, 60 }, 1L },
                    { 222L, new DateTime(2023, 3, 17, 19, 56, 37, 806, DateTimeKind.Utc).AddTicks(2758), "customer@mail.ru", "customer", true, new DateTime(2023, 3, 17, 19, 56, 37, 806, DateTimeKind.Utc).AddTicks(2759), "customer", "customer", new byte[] { 45, 12, 5, 247, 224, 60, 149, 54, 106, 159, 22, 45, 106, 61, 83, 137, 17, 100, 94, 138, 234, 84, 36, 159, 7, 39, 29, 16, 5, 242, 74, 237, 191, 194, 123, 228, 37, 10, 184, 113, 237, 117, 148, 78, 59, 123, 236, 170, 253, 141, 19, 86, 74, 230, 7, 42, 176, 255, 26, 189, 37, 89, 202, 87 }, new byte[] { 107, 89, 207, 14, 220, 42, 76, 43, 110, 116, 155, 162, 135, 249, 168, 175, 203, 193, 113, 116, 54, 142, 46, 231, 49, 58, 127, 51, 62, 50, 145, 27, 147, 196, 95, 12, 110, 154, 147, 143, 56, 185, 7, 46, 222, 243, 81, 86, 97, 124, 241, 175, 218, 109, 28, 114, 47, 74, 164, 200, 83, 212, 17, 118, 83, 30, 43, 66, 45, 125, 112, 240, 77, 252, 65, 49, 17, 222, 17, 253, 229, 181, 253, 163, 251, 98, 248, 55, 215, 148, 199, 64, 226, 170, 214, 22, 111, 149, 166, 71, 15, 10, 235, 16, 221, 239, 218, 182, 96, 107, 197, 111, 210, 63, 156, 230, 21, 124, 109, 20, 188, 115, 126, 237, 4, 149, 55, 60 }, 2L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 222L);
        }
    }
}
