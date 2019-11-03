using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMart.DAL.Migrations
{
    public partial class seedermigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "Firstname", "Lastname", "PhoneNumber", "RowVersion" },
                values: new object[] { 1L, null, null, "austin_ovia@vatebra.com", "Austin", "Ovia", "08022334567", null });

            migrationBuilder.InsertData(
                table: "Racks",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "Name", "RowVersion" },
                values: new object[] { 1L, null, null, "For mobile gadgets", "Phones and Accessories", null });

            migrationBuilder.InsertData(
                table: "Racks",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "Name", "RowVersion" },
                values: new object[] { 2L, null, null, "Get your Laptops and accessories", "Laptops and Accessories", null });

            migrationBuilder.InsertData(
                table: "PaymentDetails",
                columns: new[] { "Id", "CardHolder", "CardNumber", "CardType", "CustomerId", "Cvv", "DateCreated", "DateUpdated", "ExpiryDate", "RowVersion" },
                values: new object[] { 1L, "Austin Ovia", "123456789101112", 1, 1L, "123", null, null, new DateTime(2021, 10, 26, 14, 46, 38, 190, DateTimeKind.Local), null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "Name", "Price", "RackId", "RowVersion" },
                values: new object[] { 1L, null, null, "This is Samsung's latest phone", "Samsung Galaxy S10", 300000.00m, 1L, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "Name", "Price", "RackId", "RowVersion" },
                values: new object[] { 2L, null, null, "This is the latest macbook pro", "MacBook Pro 2019", 1000000m, 2L, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentDetails",
                keyColumns: new[] { "Id", "RowVersion" },
                keyValues: new object[] { 1L, null });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumns: new[] { "Id", "RowVersion" },
                keyValues: new object[] { 1L, null });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumns: new[] { "Id", "RowVersion" },
                keyValues: new object[] { 2L, null });

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumns: new[] { "Id", "RowVersion" },
                keyValues: new object[] { 1L, null });

            migrationBuilder.DeleteData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
