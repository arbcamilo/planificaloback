using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planificalo.Backend.Migrations
{
    /// <inheritdoc />
    public partial class actualizacionTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Usuarios",
                newName: "EstadoUsuario");

            migrationBuilder.RenameColumn(
                name: "Celular",
                table: "Usuarios",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Cotizaciones",
                newName: "FechaCotizacion");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Cotizaciones",
                newName: "EstadoCotizacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Usuarios",
                newName: "Celular");

            migrationBuilder.RenameColumn(
                name: "EstadoUsuario",
                table: "Usuarios",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "FechaCotizacion",
                table: "Cotizaciones",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "EstadoCotizacion",
                table: "Cotizaciones",
                newName: "Estado");
        }
    }
}
