using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarketPlace.Data.Persistent.Migrations
{
    /// <inheritdoc />
    public partial class AddedMocksForProductsAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "In this category will be only cars", "Cars" },
                    { 2, "In this category will be only food", "Food" },
                    { 3, "In this category will be only technologies", "Technologies" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 111L,
                columns: new[] { "CreationDate", "LastModified", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 19, 10, 10, 29, 717, DateTimeKind.Utc).AddTicks(906), new DateTime(2023, 3, 19, 10, 10, 29, 717, DateTimeKind.Utc).AddTicks(909), new byte[] { 255, 104, 160, 53, 169, 181, 187, 237, 57, 105, 106, 198, 184, 77, 48, 103, 149, 234, 32, 229, 151, 101, 31, 193, 146, 193, 99, 101, 37, 158, 28, 133, 149, 136, 165, 178, 45, 21, 143, 28, 97, 175, 148, 95, 131, 163, 90, 142, 159, 0, 169, 104, 124, 215, 142, 98, 239, 116, 71, 150, 29, 72, 55, 19 }, new byte[] { 20, 150, 132, 62, 208, 255, 190, 202, 231, 95, 82, 1, 43, 109, 219, 246, 114, 35, 240, 7, 124, 45, 229, 130, 161, 100, 147, 174, 54, 240, 176, 253, 60, 121, 64, 186, 100, 192, 161, 1, 64, 50, 61, 115, 100, 84, 189, 255, 35, 254, 48, 15, 100, 249, 248, 93, 100, 249, 157, 174, 181, 185, 105, 86, 107, 47, 7, 78, 178, 161, 92, 141, 4, 42, 189, 253, 65, 68, 103, 9, 115, 182, 90, 75, 231, 250, 129, 230, 204, 244, 5, 142, 11, 114, 116, 95, 24, 224, 83, 135, 35, 81, 106, 135, 45, 249, 61, 35, 119, 99, 245, 67, 23, 48, 93, 15, 242, 174, 171, 177, 67, 126, 213, 199, 166, 232, 178, 10 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 222L,
                columns: new[] { "CreationDate", "LastModified", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 19, 10, 10, 29, 717, DateTimeKind.Utc).AddTicks(923), new DateTime(2023, 3, 19, 10, 10, 29, 717, DateTimeKind.Utc).AddTicks(923), new byte[] { 172, 29, 197, 221, 97, 76, 234, 156, 124, 214, 229, 182, 208, 88, 121, 92, 192, 245, 86, 146, 186, 63, 149, 157, 154, 136, 134, 117, 203, 92, 170, 25, 143, 120, 121, 229, 62, 25, 127, 194, 34, 14, 14, 202, 215, 247, 252, 1, 55, 82, 182, 150, 10, 187, 59, 214, 112, 201, 7, 135, 150, 245, 188, 243 }, new byte[] { 20, 150, 132, 62, 208, 255, 190, 202, 231, 95, 82, 1, 43, 109, 219, 246, 114, 35, 240, 7, 124, 45, 229, 130, 161, 100, 147, 174, 54, 240, 176, 253, 60, 121, 64, 186, 100, 192, 161, 1, 64, 50, 61, 115, 100, 84, 189, 255, 35, 254, 48, 15, 100, 249, 248, 93, 100, 249, 157, 174, 181, 185, 105, 86, 107, 47, 7, 78, 178, 161, 92, 141, 4, 42, 189, 253, 65, 68, 103, 9, 115, 182, 90, 75, 231, 250, 129, 230, 204, 244, 5, 142, 11, 114, 116, 95, 24, 224, 83, 135, 35, 81, 106, 135, 45, 249, 61, 35, 119, 99, 245, 67, 23, 48, 93, 15, 242, 174, 171, 177, 67, 126, 213, 199, 166, 232, 178, 10 } });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Description for Volkswagen Polo", "Volkswagen Polo", 10000m, 7 },
                    { 2, 1, "Description for BMW M3", "BMW M3", 15000m, 3 },
                    { 3, 2, "Description for Apple", "Apple", 10m, 120 },
                    { 4, 2, "Description for Potato", "Potato", 7m, 40 },
                    { 5, 2, "Description for Carrot", "Carrot", 8m, 73 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 111L,
                columns: new[] { "CreationDate", "LastModified", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 17, 19, 56, 37, 806, DateTimeKind.Utc).AddTicks(2741), new DateTime(2023, 3, 17, 19, 56, 37, 806, DateTimeKind.Utc).AddTicks(2744), new byte[] { 105, 114, 158, 37, 144, 254, 152, 44, 93, 8, 87, 226, 18, 231, 191, 140, 154, 103, 234, 106, 200, 146, 14, 228, 223, 51, 113, 50, 237, 211, 207, 237, 110, 45, 76, 50, 155, 219, 2, 23, 241, 205, 156, 243, 144, 254, 153, 237, 197, 140, 134, 200, 94, 154, 134, 121, 174, 118, 85, 88, 114, 70, 48, 195 }, new byte[] { 107, 89, 207, 14, 220, 42, 76, 43, 110, 116, 155, 162, 135, 249, 168, 175, 203, 193, 113, 116, 54, 142, 46, 231, 49, 58, 127, 51, 62, 50, 145, 27, 147, 196, 95, 12, 110, 154, 147, 143, 56, 185, 7, 46, 222, 243, 81, 86, 97, 124, 241, 175, 218, 109, 28, 114, 47, 74, 164, 200, 83, 212, 17, 118, 83, 30, 43, 66, 45, 125, 112, 240, 77, 252, 65, 49, 17, 222, 17, 253, 229, 181, 253, 163, 251, 98, 248, 55, 215, 148, 199, 64, 226, 170, 214, 22, 111, 149, 166, 71, 15, 10, 235, 16, 221, 239, 218, 182, 96, 107, 197, 111, 210, 63, 156, 230, 21, 124, 109, 20, 188, 115, 126, 237, 4, 149, 55, 60 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 222L,
                columns: new[] { "CreationDate", "LastModified", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 17, 19, 56, 37, 806, DateTimeKind.Utc).AddTicks(2758), new DateTime(2023, 3, 17, 19, 56, 37, 806, DateTimeKind.Utc).AddTicks(2759), new byte[] { 45, 12, 5, 247, 224, 60, 149, 54, 106, 159, 22, 45, 106, 61, 83, 137, 17, 100, 94, 138, 234, 84, 36, 159, 7, 39, 29, 16, 5, 242, 74, 237, 191, 194, 123, 228, 37, 10, 184, 113, 237, 117, 148, 78, 59, 123, 236, 170, 253, 141, 19, 86, 74, 230, 7, 42, 176, 255, 26, 189, 37, 89, 202, 87 }, new byte[] { 107, 89, 207, 14, 220, 42, 76, 43, 110, 116, 155, 162, 135, 249, 168, 175, 203, 193, 113, 116, 54, 142, 46, 231, 49, 58, 127, 51, 62, 50, 145, 27, 147, 196, 95, 12, 110, 154, 147, 143, 56, 185, 7, 46, 222, 243, 81, 86, 97, 124, 241, 175, 218, 109, 28, 114, 47, 74, 164, 200, 83, 212, 17, 118, 83, 30, 43, 66, 45, 125, 112, 240, 77, 252, 65, 49, 17, 222, 17, 253, 229, 181, 253, 163, 251, 98, 248, 55, 215, 148, 199, 64, 226, 170, 214, 22, 111, 149, 166, 71, 15, 10, 235, 16, 221, 239, 218, 182, 96, 107, 197, 111, 210, 63, 156, 230, 21, 124, 109, 20, 188, 115, 126, 237, 4, 149, 55, 60 } });
        }
    }
}
