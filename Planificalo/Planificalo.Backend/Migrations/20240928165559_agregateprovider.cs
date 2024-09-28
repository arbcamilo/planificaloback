using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planificalo.Backend.Migrations
{
    /// <inheritdoc />
    public partial class agregateprovider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 28, 11, 55, 59, 172, DateTimeKind.Local).AddTicks(7277));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 29, 11, 55, 59, 172, DateTimeKind.Local).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 1,
                column: "SendDate",
                value: new DateTime(2024, 9, 28, 11, 55, 59, 172, DateTimeKind.Local).AddTicks(7514));

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 2,
                column: "SendDate",
                value: new DateTime(2024, 9, 29, 11, 55, 59, 172, DateTimeKind.Local).AddTicks(7515));

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "Address", "City", "ContactPhone", "Country", "Department", "DocumentType", "Email", "IdentityDocument", "IsNaturalPerson", "Name", "Status" },
                values: new object[] { 3, "Address three", "City three", "09875465465", "Country three", "Department three", "Cedula", "providerthree@example.com", 5456465456L, false, "Provider three", "Inactive" });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "QuoteDate",
                value: new DateTime(2024, 9, 28, 11, 55, 59, 172, DateTimeKind.Local).AddTicks(7403));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "QuoteDate",
                value: new DateTime(2024, 9, 28, 11, 55, 59, 172, DateTimeKind.Local).AddTicks(7407));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountCreationDate",
                value: new DateTime(2024, 9, 28, 11, 55, 59, 172, DateTimeKind.Local).AddTicks(7193));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccountCreationDate",
                value: new DateTime(2024, 9, 28, 11, 55, 59, 172, DateTimeKind.Local).AddTicks(7208));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 28, 11, 51, 28, 16, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 29, 11, 51, 28, 16, DateTimeKind.Local).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 1,
                column: "SendDate",
                value: new DateTime(2024, 9, 28, 11, 51, 28, 16, DateTimeKind.Local).AddTicks(8613));

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 2,
                column: "SendDate",
                value: new DateTime(2024, 9, 29, 11, 51, 28, 16, DateTimeKind.Local).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "QuoteDate",
                value: new DateTime(2024, 9, 28, 11, 51, 28, 16, DateTimeKind.Local).AddTicks(8522));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "QuoteDate",
                value: new DateTime(2024, 9, 28, 11, 51, 28, 16, DateTimeKind.Local).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountCreationDate",
                value: new DateTime(2024, 9, 28, 11, 51, 28, 16, DateTimeKind.Local).AddTicks(8362));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccountCreationDate",
                value: new DateTime(2024, 9, 28, 11, 51, 28, 16, DateTimeKind.Local).AddTicks(8377));
        }
    }
}
