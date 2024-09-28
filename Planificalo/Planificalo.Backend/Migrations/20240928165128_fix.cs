using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planificalo.Backend.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Date", "IsPrivate" },
                values: new object[] { new DateTime(2024, 9, 29, 11, 51, 28, 16, DateTimeKind.Local).AddTicks(8432), true });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Date", "IsPrivate" },
                values: new object[] { new DateTime(2024, 9, 29, 11, 10, 21, 797, DateTimeKind.Local).AddTicks(4480), false });

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
    }
}
