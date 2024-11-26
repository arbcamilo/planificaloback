using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planificalo.Backend.Migrations
{
    /// <inheritdoc />
    public partial class fixdatacontextserv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceProviders",
                table: "ServiceProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductProviders",
                table: "ProductProviders");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ServiceProviders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductProviders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceProviders",
                table: "ServiceProviders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductProviders",
                table: "ProductProviders",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceProviders",
                table: "ServiceProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductProviders",
                table: "ProductProviders");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ServiceProviders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductProviders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceProviders",
                table: "ServiceProviders",
                columns: new[] { "ProviderId", "ServiceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductProviders",
                table: "ProductProviders",
                columns: new[] { "ProviderId", "ProductId" });
        }
    }
}
