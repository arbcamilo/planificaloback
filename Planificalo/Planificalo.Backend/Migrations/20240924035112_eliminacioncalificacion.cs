using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planificalo.Backend.Migrations
{
    /// <inheritdoc />
    public partial class eliminacioncalificacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calificacion",
                table: "Proveedores");

            migrationBuilder.RenameColumn(
                name: "cantidad",
                table: "Servicios",
                newName: "Cantidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "Servicios",
                newName: "cantidad");

            migrationBuilder.AddColumn<double>(
                name: "Calificacion",
                table: "Proveedores",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
