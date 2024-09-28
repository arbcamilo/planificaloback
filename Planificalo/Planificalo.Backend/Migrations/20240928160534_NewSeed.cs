using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planificalo.Backend.Migrations
{
    /// <inheritdoc />
    public partial class NewSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 28, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 29, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(2746));

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 1,
                column: "SendDate",
                value: new DateTime(2024, 9, 28, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(3233));

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 2,
                column: "SendDate",
                value: new DateTime(2024, 9, 29, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(3237));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "QuoteDate",
                value: new DateTime(2024, 9, 28, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(2979));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "QuoteDate",
                value: new DateTime(2024, 9, 28, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(2984));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountCreationDate",
                value: new DateTime(2024, 9, 28, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(2289));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccountCreationDate",
                value: new DateTime(2024, 9, 28, 10, 32, 0, 271, DateTimeKind.Local).AddTicks(2308));
        }
    }
}
