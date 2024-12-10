using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LDBeauty.Infrastructure.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "IsDeleted", "TotalPrice", "UserId" },
                values: new object[] { 1, false, 42m, "71247a6c-ca6b-4cc8-9d5c-25b701e0f543" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Makeup" },
                    { 2, "Skincare" },
                    { 3, "Fragrance" }
                });

            migrationBuilder.InsertData(
                table: "ImgCategories",
                columns: new[] { "Id", "CategoryName", "ImgUrl" },
                values: new object[,]
                {
                    { 1, "Makeup-img", "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-1000w,f_auto,q_auto:best/rockcms/2024-06/240610-beauty-awards-2024-face-makeup-winners-vl-main-58813e.jpg" },
                    { 2, "Skincare-img", "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-1000w,f_auto,q_auto:best/rockcms/2024-06/240610-beauty-awards-2024-skincare-winners-vl-main-b0c976.jpg" },
                    { 3, "Fragrance-img", "https://ambadar.com/storage/2023/12/can-parfume-fragrance-be-protected-by-copyrights-law-in-indonesia-20230707214332.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "MakeName" },
                values: new object[,]
                {
                    { 1, "L'Oréal" },
                    { 2, "Estée Lauder" },
                    { 3, "Chanel" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "ApplicationUserId", "ClientFirstName", "ClientLastName", "Email", "OrderDate", "Phone", "TotalPrice" },
                values: new object[] { 1, "123 Main St", "71247a6c-ca6b-4cc8-9d5c-25b701e0f543", "John", "Doe", "john.doe@example.com", new DateTime(2024, 12, 8, 21, 8, 1, 614, DateTimeKind.Local).AddTicks(4176), "1234567890", 79.98m });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ApplicationUserId", "CategoruId", "Description", "ImageUrl" },
                values: new object[,]
                {
                    { 1, null, 1, "Makeup", "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-1000w,f_auto,q_auto:best/rockcms/2024-06/240610-beauty-awards-2024-face-makeup-winners-vl-main-58813e.jpg" },
                    { 2, null, 2, "Skincare", "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-1000w,f_auto,q_auto:best/rockcms/2024-06/240610-beauty-awards-2024-skincare-winners-vl-main-b0c976.jpg" },
                    { 3, null, 3, "Fragrance", "https://ambadar.com/storage/2023/12/can-parfume-fragrance-be-protected-by-copyrights-law-in-indonesia-20230707214332.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "Description", "MakeId", "Price", "ProductName", "ProductUrl", "Quantity" },
                values: new object[,]
                {
                    { 1, null, 1, "Long-lasting foundation", 1, 29.99m, "Foundation", "url1", 100 },
                    { 2, null, 2, "Hydrating moisturizer", 2, 19.99m, "Moisturizer", "url2", 200 },
                    { 3, null, 3, "Elegant fragrance", 3, 49.99m, "Perfume", "url3", 150 }
                });

            migrationBuilder.InsertData(
                table: "AddedProducts",
                columns: new[] { "Id", "CartId", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 2 },
                    { 2, 1, 1, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "UsersImages",
                columns: new[] { "ApplicationUserId", "ImageId" },
                values: new object[,]
                {
                    { "71247a6c-ca6b-4cc8-9d5c-25b701e0f543", 1 },
                    { "71247a6c-ca6b-4cc8-9d5c-25b701e0f543", 2 },
                    { "71247a6c-ca6b-4cc8-9d5c-25b701e0f543", 3 }
                });

            migrationBuilder.InsertData(
                table: "UsersProducts",
                columns: new[] { "ApplicationUserId", "ProductId" },
                values: new object[,]
                {
                    { "71247a6c-ca6b-4cc8-9d5c-25b701e0f543", 1 },
                    { "71247a6c-ca6b-4cc8-9d5c-25b701e0f543", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AddedProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AddedProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UsersImages",
                keyColumns: new[] { "ApplicationUserId", "ImageId" },
                keyValues: new object[] { "71247a6c-ca6b-4cc8-9d5c-25b701e0f543", 1 });

            migrationBuilder.DeleteData(
                table: "UsersImages",
                keyColumns: new[] { "ApplicationUserId", "ImageId" },
                keyValues: new object[] { "71247a6c-ca6b-4cc8-9d5c-25b701e0f543", 2 });

            migrationBuilder.DeleteData(
                table: "UsersImages",
                keyColumns: new[] { "ApplicationUserId", "ImageId" },
                keyValues: new object[] { "71247a6c-ca6b-4cc8-9d5c-25b701e0f543", 3 });

            migrationBuilder.DeleteData(
                table: "UsersProducts",
                keyColumns: new[] { "ApplicationUserId", "ProductId" },
                keyValues: new object[] { "71247a6c-ca6b-4cc8-9d5c-25b701e0f543", 1 });

            migrationBuilder.DeleteData(
                table: "UsersProducts",
                keyColumns: new[] { "ApplicationUserId", "ProductId" },
                keyValues: new object[] { "71247a6c-ca6b-4cc8-9d5c-25b701e0f543", 2 });

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ImgCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ImgCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ImgCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
