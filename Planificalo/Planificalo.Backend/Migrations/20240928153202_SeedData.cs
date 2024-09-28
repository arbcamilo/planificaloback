using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Planificalo.Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Conference" },
                    { 2, "Workshop" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "EventTypeId", "Image", "Location", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 28, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(2742), 1, "image1.jpg", "Location One", "Event One", 1 },
                    { 2, new DateTime(2024, 9, 29, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(2746), 2, "image2.jpg", "Location Two", "Event Two", 2 }
                });

            migrationBuilder.InsertData(
                table: "GuestEvents",
                columns: new[] { "EventId", "GuestId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Email", "GuestStatus", "Name" },
                values: new object[,]
                {
                    { 1, "guestone@example.com", true, "Guest One" },
                    { 2, "guesttwo@example.com", false, "Guest Two" }
                });

            migrationBuilder.InsertData(
                table: "Invitations",
                columns: new[] { "Id", "EventId", "GuestId", "InvitationStatus", "SendDate" },
                values: new object[,]
                {
                    { 1, 1, 1, true, new DateTime(2024, 9, 28, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(3233) },
                    { 2, 2, 2, false, new DateTime(2024, 9, 29, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(3237) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Description", "Price", "ProductType" },
                values: new object[,]
                {
                    { 1, 100, "Plastic Chair", 10.00m, "Chair" },
                    { 2, 50, "Wooden Table", 20.00m, "Table" }
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "Address", "City", "ContactPhone", "Country", "Department", "DocumentType", "Email", "IdentityDocument", "IsNaturalPerson", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Address One", "City One", "1234567890", "Country One", "Department One", "Cedula", "providerone@example.com", 123456789L, true, "Provider One", "Active" },
                    { 2, "Address Two", "City Two", "0987654321", "Country Two", "Department Two", "Cedula", "providertwo@example.com", 987654321L, false, "Provider Two", "Inactive" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Price", "Quantity", "ServiceType" },
                values: new object[,]
                {
                    { 1, "Catering Service", 100.00m, "10", "Catering" },
                    { 2, "Photography Service", 200.00m, "5", "Photography" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountCreationDate", "BirthDate", "Discriminator", "DocumentType", "Email", "IdentityDocument", "Name", "Phone", "UserStatus" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 28, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(2289), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "Cedula", "johndoe@example.com", 123456789L, "John Doe", "1234567890", "Active" },
                    { 2, new DateTime(2024, 9, 28, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(2308), new DateTime(1992, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "Cedula", "janesmith@example.com", 987654321L, "Jane Smith", "0987654321", "Inactive" }
                });

            migrationBuilder.InsertData(
                table: "ProductProviders",
                columns: new[] { "ProductId", "ProviderId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "EventId", "Notes", "ProviderId", "Quantity", "QuoteDate", "QuoteStatus", "ResponseDate", "Total" },
                values: new object[,]
                {
                    { 1, 1, "Initial quote for Event One", 1, 10, new DateTime(2024, 9, 28, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(2979), "Pending", null, 1000.00m },
                    { 2, 2, "Initial quote for Event Two", 2, 5, new DateTime(2024, 9, 28, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(2984), "Confirmed", null, 500.00m }
                });

            migrationBuilder.InsertData(
                table: "ServiceProviders",
                columns: new[] { "ProviderId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductQuotes",
                columns: new[] { "ProductId", "QuoteId", "Amount", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 10, 0m },
                    { 2, 2, 5, 0m }
                });

            migrationBuilder.InsertData(
                table: "ServiceQuotes",
                columns: new[] { "QuoteId", "ServiceId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 10, 0m },
                    { 2, 2, 5, 0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GuestEvents",
                keyColumns: new[] { "EventId", "GuestId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GuestEvents",
                keyColumns: new[] { "EventId", "GuestId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductProviders",
                keyColumns: new[] { "ProductId", "ProviderId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductProviders",
                keyColumns: new[] { "ProductId", "ProviderId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductQuotes",
                keyColumns: new[] { "ProductId", "QuoteId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductQuotes",
                keyColumns: new[] { "ProductId", "QuoteId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ServiceProviders",
                keyColumns: new[] { "ProviderId", "ServiceId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ServiceProviders",
                keyColumns: new[] { "ProviderId", "ServiceId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ServiceQuotes",
                keyColumns: new[] { "QuoteId", "ServiceId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ServiceQuotes",
                keyColumns: new[] { "QuoteId", "ServiceId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
