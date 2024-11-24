using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planificalo.Backend.Migrations
{
    /// <inheritdoc />
    public partial class deletequote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductQuotes");

            migrationBuilder.DropTable(
                name: "ServiceQuotes");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "ServiceProviders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "ProductProviders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventStatus",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageEvent",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_EventId",
                table: "ServiceProviders",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProviders_EventId",
                table: "ProductProviders",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProviders_Events_EventId",
                table: "ProductProviders",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_Events_EventId",
                table: "ServiceProviders",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProviders_Events_EventId",
                table: "ProductProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_Events_EventId",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_EventId",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ProductProviders_EventId",
                table: "ProductProviders");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "ProductProviders");

            migrationBuilder.DropColumn(
                name: "EventStatus",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ImageEvent",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    QuoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuoteStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotes_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductQuotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductQuotes", x => new { x.QuoteId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductQuotes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductQuotes_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceQuotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceQuotes", x => new { x.QuoteId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ServiceQuotes_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceQuotes_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuotes_ProductId",
                table: "ProductQuotes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_EventId",
                table: "Quotes",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceQuotes_ServiceId",
                table: "ServiceQuotes",
                column: "ServiceId");
        }
    }
}
