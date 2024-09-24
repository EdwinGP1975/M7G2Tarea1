using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M7Tarea1.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Api4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_VentaDetalle_VentaDetalleId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_VentaDetalle_VentaDetalleId",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Productos_VentaDetalleId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "VentaDetalleId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Descuento",
                table: "GrupoCliente");

            migrationBuilder.RenameColumn(
                name: "VentaDetalleId",
                table: "Servicios",
                newName: "DescuentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Servicios_VentaDetalleId",
                table: "Servicios",
                newName: "IX_Servicios_DescuentoId");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "VentaDetalle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicioId",
                table: "VentaDetalle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Descuentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PorcentajeDescuento = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "Date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "Date", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: true),
                    GrupoClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descuentos_GrupoCliente_GrupoClienteId",
                        column: x => x.GrupoClienteId,
                        principalTable: "GrupoCliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Descuentos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id");
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Descuentos_DescuentoId",
                table: "Servicios",
                column: "DescuentoId",
                principalTable: "Descuentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaDetalle_Productos_ProductoId",
                table: "VentaDetalle",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaDetalle_Servicios_ServicioId",
                table: "VentaDetalle",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Descuentos_DescuentoId",
                table: "Servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalle_Productos_ProductoId",
                table: "VentaDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalle_Servicios_ServicioId",
                table: "VentaDetalle");

            migrationBuilder.DropTable(
                name: "Descuentos");

            migrationBuilder.DropIndex(
                name: "IX_VentaDetalle_ProductoId",
                table: "VentaDetalle");

            migrationBuilder.DropIndex(
                name: "IX_VentaDetalle_ServicioId",
                table: "VentaDetalle");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "VentaDetalle");

            migrationBuilder.DropColumn(
                name: "ServicioId",
                table: "VentaDetalle");

            migrationBuilder.RenameColumn(
                name: "DescuentoId",
                table: "Servicios",
                newName: "VentaDetalleId");

            migrationBuilder.RenameIndex(
                name: "IX_Servicios_DescuentoId",
                table: "Servicios",
                newName: "IX_Servicios_VentaDetalleId");

            migrationBuilder.AddColumn<int>(
                name: "VentaDetalleId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Descuento",
                table: "GrupoCliente",
                type: "decimal(4,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_VentaDetalleId",
                table: "Productos",
                column: "VentaDetalleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_VentaDetalle_VentaDetalleId",
                table: "Productos",
                column: "VentaDetalleId",
                principalTable: "VentaDetalle",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_VentaDetalle_VentaDetalleId",
                table: "Servicios",
                column: "VentaDetalleId",
                principalTable: "VentaDetalle",
                principalColumn: "Id");
        }
    }
}
