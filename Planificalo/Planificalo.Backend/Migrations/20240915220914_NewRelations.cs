using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planificalo.Backend.Migrations
{
    /// <inheritdoc />
    public partial class NewRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotizaciones_Eventos_EventoId",
                table: "Cotizaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Cotizaciones_Proveedores_ProveedorId",
                table: "Cotizaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_CotizacionProductos_Cotizaciones_CotizacionId",
                table: "CotizacionProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_CotizacionProductos_Productos_ProductoId",
                table: "CotizacionProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_CotizacionServicios_Cotizaciones_CotizacionId",
                table: "CotizacionServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_CotizacionServicios_Servicios_ServicioId",
                table: "CotizacionServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedorProductos_Productos_ProductoId",
                table: "ProveedorProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedorProductos_Proveedores_ProveedorId",
                table: "ProveedorProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedorServicios_Proveedores_ProveedorId",
                table: "ProveedorServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedorServicios_Servicios_ServicioId",
                table: "ProveedorServicios");

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cotizaciones_Eventos_EventoId",
                table: "Cotizaciones",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cotizaciones_Proveedores_ProveedorId",
                table: "Cotizaciones",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CotizacionProductos_Cotizaciones_CotizacionId",
                table: "CotizacionProductos",
                column: "CotizacionId",
                principalTable: "Cotizaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CotizacionProductos_Productos_ProductoId",
                table: "CotizacionProductos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CotizacionServicios_Cotizaciones_CotizacionId",
                table: "CotizacionServicios",
                column: "CotizacionId",
                principalTable: "Cotizaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CotizacionServicios_Servicios_ServicioId",
                table: "CotizacionServicios",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedorProductos_Productos_ProductoId",
                table: "ProveedorProductos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedorProductos_Proveedores_ProveedorId",
                table: "ProveedorProductos",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedorServicios_Proveedores_ProveedorId",
                table: "ProveedorServicios",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedorServicios_Servicios_ServicioId",
                table: "ProveedorServicios",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotizaciones_Eventos_EventoId",
                table: "Cotizaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Cotizaciones_Proveedores_ProveedorId",
                table: "Cotizaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_CotizacionProductos_Cotizaciones_CotizacionId",
                table: "CotizacionProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_CotizacionProductos_Productos_ProductoId",
                table: "CotizacionProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_CotizacionServicios_Cotizaciones_CotizacionId",
                table: "CotizacionServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_CotizacionServicios_Servicios_ServicioId",
                table: "CotizacionServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedorProductos_Productos_ProductoId",
                table: "ProveedorProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedorProductos_Proveedores_ProveedorId",
                table: "ProveedorProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedorServicios_Proveedores_ProveedorId",
                table: "ProveedorServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedorServicios_Servicios_ServicioId",
                table: "ProveedorServicios");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Productos");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotizaciones_Eventos_EventoId",
                table: "Cotizaciones",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cotizaciones_Proveedores_ProveedorId",
                table: "Cotizaciones",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CotizacionProductos_Cotizaciones_CotizacionId",
                table: "CotizacionProductos",
                column: "CotizacionId",
                principalTable: "Cotizaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CotizacionProductos_Productos_ProductoId",
                table: "CotizacionProductos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CotizacionServicios_Cotizaciones_CotizacionId",
                table: "CotizacionServicios",
                column: "CotizacionId",
                principalTable: "Cotizaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CotizacionServicios_Servicios_ServicioId",
                table: "CotizacionServicios",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedorProductos_Productos_ProductoId",
                table: "ProveedorProductos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedorProductos_Proveedores_ProveedorId",
                table: "ProveedorProductos",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedorServicios_Proveedores_ProveedorId",
                table: "ProveedorServicios",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedorServicios_Servicios_ServicioId",
                table: "ProveedorServicios",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
