using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planificalo.Backend.Migrations
{
    /// <inheritdoc />
    public partial class NewDataRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Servicios",
                newName: "cantidad");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Productos",
                newName: "TipoProducto");

            migrationBuilder.RenameColumn(
                name: "Inventario",
                table: "Productos",
                newName: "Cantidad");

            migrationBuilder.RenameColumn(
                name: "Confirmado",
                table: "Invitados",
                newName: "EstadoInventario");

            migrationBuilder.RenameColumn(
                name: "Confirmado",
                table: "Invitaciones",
                newName: "EstadoInvitacion");

            migrationBuilder.RenameColumn(
                name: "FechaVencimiento",
                table: "Cotizaciones",
                newName: "FechaRespuesta");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Servicios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoServicio",
                table: "Servicios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "TipoServicio",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Eventos");

            migrationBuilder.RenameColumn(
                name: "cantidad",
                table: "Servicios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "TipoProducto",
                table: "Productos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "Productos",
                newName: "Inventario");

            migrationBuilder.RenameColumn(
                name: "EstadoInventario",
                table: "Invitados",
                newName: "Confirmado");

            migrationBuilder.RenameColumn(
                name: "EstadoInvitacion",
                table: "Invitaciones",
                newName: "Confirmado");

            migrationBuilder.RenameColumn(
                name: "FechaRespuesta",
                table: "Cotizaciones",
                newName: "FechaVencimiento");

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
