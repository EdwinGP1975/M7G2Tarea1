using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M7Tarea1.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Api5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ventas_EmpresaId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_PersonaId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_VentaDetalle_ProductoId",
                table: "VentaDetalle");

            migrationBuilder.DropIndex(
                name: "IX_VentaDetalle_ServicioId",
                table: "VentaDetalle");

            migrationBuilder.DropIndex(
                name: "IX_Descuentos_GrupoClienteId",
                table: "Descuentos");

            migrationBuilder.DropIndex(
                name: "IX_Descuentos_ProductoId",
                table: "Descuentos");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_EmpresaId",
                table: "Ventas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_PersonaId",
                table: "Ventas",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDetalle_ProductoId",
                table: "VentaDetalle",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDetalle_ServicioId",
                table: "VentaDetalle",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Descuentos_GrupoClienteId",
                table: "Descuentos",
                column: "GrupoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Descuentos_ProductoId",
                table: "Descuentos",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ventas_EmpresaId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_PersonaId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_VentaDetalle_ProductoId",
                table: "VentaDetalle");

            migrationBuilder.DropIndex(
                name: "IX_VentaDetalle_ServicioId",
                table: "VentaDetalle");

            migrationBuilder.DropIndex(
                name: "IX_Descuentos_GrupoClienteId",
                table: "Descuentos");

            migrationBuilder.DropIndex(
                name: "IX_Descuentos_ProductoId",
                table: "Descuentos");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_EmpresaId",
                table: "Ventas",
                column: "EmpresaId",
                unique: true,
                filter: "[EmpresaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_PersonaId",
                table: "Ventas",
                column: "PersonaId",
                unique: true,
                filter: "[PersonaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDetalle_ProductoId",
                table: "VentaDetalle",
                column: "ProductoId",
                unique: true,
                filter: "[ProductoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDetalle_ServicioId",
                table: "VentaDetalle",
                column: "ServicioId",
                unique: true,
                filter: "[ServicioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Descuentos_GrupoClienteId",
                table: "Descuentos",
                column: "GrupoClienteId",
                unique: true,
                filter: "[GrupoClienteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Descuentos_ProductoId",
                table: "Descuentos",
                column: "ProductoId",
                unique: true,
                filter: "[ProductoId] IS NOT NULL");
        }
    }
}
