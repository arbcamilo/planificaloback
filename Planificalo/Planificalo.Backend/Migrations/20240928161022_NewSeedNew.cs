using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planificalo.Backend.Migrations
{
    /// <inheritdoc />
    public partial class NewSeedNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 28, 11, 10, 21, 797, DateTimeKind.Local).AddTicks(4477));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 29, 11, 10, 21, 797, DateTimeKind.Local).AddTicks(4480));

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 1,
                column: "SendDate",
                value: new DateTime(2024, 9, 28, 11, 10, 21, 797, DateTimeKind.Local).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 2,
                column: "SendDate",
                value: new DateTime(2024, 9, 29, 11, 10, 21, 797, DateTimeKind.Local).AddTicks(5043));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "QuoteDate",
                value: new DateTime(2024, 9, 28, 11, 10, 21, 797, DateTimeKind.Local).AddTicks(4778));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "QuoteDate",
                value: new DateTime(2024, 9, 28, 11, 10, 21, 797, DateTimeKind.Local).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountCreationDate",
                value: new DateTime(2024, 9, 28, 11, 10, 21, 797, DateTimeKind.Local).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccountCreationDate",
                value: new DateTime(2024, 9, 28, 11, 10, 21, 797, DateTimeKind.Local).AddTicks(4392));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 28, 11, 5, 33, 454, DateTimeKind.Local).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 29, 11, 5, 33, 454, DateTimeKind.Local).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 1,
                column: "SendDate",
                value: new DateTime(2024, 9, 28, 11, 5, 33, 454, DateTimeKind.Local).AddTicks(8651));

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 2,
                column: "SendDate",
                value: new DateTime(2024, 9, 29, 11, 5, 33, 454, DateTimeKind.Local).AddTicks(8681));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "QuoteDate",
                value: new DateTime(2024, 9, 28, 11, 5, 33, 454, DateTimeKind.Local).AddTicks(8451));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "QuoteDate",
                value: new DateTime(2024, 9, 28, 11, 5, 33, 454, DateTimeKind.Local).AddTicks(8456));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountCreationDate",
                value: new DateTime(2024, 9, 28, 11, 5, 33, 454, DateTimeKind.Local).AddTicks(8108));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccountCreationDate",
                value: new DateTime(2024, 9, 28, 11, 5, 33, 454, DateTimeKind.Local).AddTicks(8126));
        }
    }
}
