using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planificalo.Backend.Migrations
{
    /// <inheritdoc />
    public partial class newevent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProviders_Events_EventId",
                table: "ProductProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProviders_Products_ProductId",
                table: "ProductProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_Events_EventId",
                table: "ServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_Services_ServiceId",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_EventId",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_ServiceId",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ProductProviders_EventId",
                table: "ProductProviders");

            migrationBuilder.DropIndex(
                name: "IX_ProductProviders_ProductId",
                table: "ProductProviders");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "ProductProviders");

            migrationBuilder.CreateTable(
                name: "ProductEvent",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEvent", x => new { x.EventId, x.ProductId, x.ProviderId });
                    table.ForeignKey(
                        name: "FK_ProductEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceEvent",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceEvent", x => new { x.EventId, x.ServiceId, x.ProviderId });
                    table.ForeignKey(
                        name: "FK_ServiceEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductEvent");

            migrationBuilder.DropTable(
                name: "ServiceEvent");

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

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_EventId",
                table: "ServiceProviders",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_ServiceId",
                table: "ServiceProviders",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProviders_EventId",
                table: "ProductProviders",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProviders_ProductId",
                table: "ProductProviders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProviders_Events_EventId",
                table: "ProductProviders",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProviders_Products_ProductId",
                table: "ProductProviders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_Events_EventId",
                table: "ServiceProviders",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_Services_ServiceId",
                table: "ServiceProviders",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
