using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planificalo.Backend.Migrations
{
    /// <inheritdoc />
    public partial class deleteprovider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProviders_Providers_ProviderId",
                table: "ProductProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Providers_ProviderId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_Providers_ProviderId",
                table: "ServiceProviders");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_ProviderId",
                table: "Quotes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdentityDocument = table.Column<long>(type: "bigint", nullable: false),
                    IsNaturalPerson = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_ProviderId",
                table: "Quotes",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_DocumentType_IdentityDocument",
                table: "Providers",
                columns: new[] { "DocumentType", "IdentityDocument" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProviders_Providers_ProviderId",
                table: "ProductProviders",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Providers_ProviderId",
                table: "Quotes",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_Providers_ProviderId",
                table: "ServiceProviders",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
