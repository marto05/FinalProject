using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LDBeauty.Infrastructure.Migrations
{
    public partial class UpdateProductURLInProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 8, 21, 40, 26, 530, DateTimeKind.Local).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductUrl",
                value: "https://www.sephora.com/productimages/sku/s2514586-main-zoom.jpg?imwidth=315");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductUrl",
                value: "https://cloudinary.images-iherb.com/image/upload/f_auto,q_auto:eco/images/cet/cet92804/l/24.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductUrl",
                value: "https://www.sbdiscounter.bg/wp-content/uploads/2021/04/new-oud-lavender-box-and-bottle-2.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 8, 21, 8, 1, 614, DateTimeKind.Local).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductUrl",
                value: "url1");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductUrl",
                value: "url2");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductUrl",
                value: "url3");
        }
    }
}
