using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M7Tarea1.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Api2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ClienteSequence");

            migrationBuilder.AddColumn<int>(
                name: "VentaDetalleId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Almacenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlmacenProducto",
                columns: table => new
                {
                    AlmacenesId = table.Column<int>(type: "int", nullable: false),
                    ProductosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlmacenProducto", x => new { x.AlmacenesId, x.ProductosId });
                    table.ForeignKey(
                        name: "FK_AlmacenProducto_Almacenes_AlmacenesId",
                        column: x => x.AlmacenesId,
                        principalTable: "Almacenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlmacenProducto_Productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ClienteSequence]"),
                    Codigo = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    GrupoClienteId = table.Column<int>(type: "int", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Nit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_GrupoCliente_GrupoClienteId",
                        column: x => x.GrupoClienteId,
                        principalTable: "GrupoCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ClienteSequence]"),
                    Codigo = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    GrupoClienteId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Ci = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_GrupoCliente_GrupoClienteId",
                        column: x => x.GrupoClienteId,
                        principalTable: "GrupoCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "Date", nullable: false),
                    NitFacturacion = table.Column<int>(type: "int", nullable: false),
                    NombreFacturacion = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ConIva = table.Column<bool>(type: "bit", nullable: false),
                    DescuentoGlobal = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    PrecioTotal = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PrecioTotalDescuento = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ventas_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VentaDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    UnidadMedida = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    DescuentoItem = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    PrecioDescuento = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentaDetalle_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    UnidadVenta = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    VentaDetalleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_VentaDetalle_VentaDetalleId",
                        column: x => x.VentaDetalleId,
                        principalTable: "VentaDetalle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_VentaDetalleId",
                table: "Productos",
                column: "VentaDetalleId");

            migrationBuilder.CreateIndex(
                name: "IX_AlmacenProducto_ProductosId",
                table: "AlmacenProducto",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_GrupoClienteId",
                table: "Empresas",
                column: "GrupoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_GrupoClienteId",
                table: "Personas",
                column: "GrupoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_VentaDetalleId",
                table: "Servicios",
                column: "VentaDetalleId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDetalle_VentaId",
                table: "VentaDetalle",
                column: "VentaId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_VentaDetalle_VentaDetalleId",
                table: "Productos",
                column: "VentaDetalleId",
                principalTable: "VentaDetalle",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_VentaDetalle_VentaDetalleId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "AlmacenProducto");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Almacenes");

            migrationBuilder.DropTable(
                name: "VentaDetalle");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "GrupoCliente");

            migrationBuilder.DropIndex(
                name: "IX_Productos_VentaDetalleId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "VentaDetalleId",
                table: "Productos");

            migrationBuilder.DropSequence(
                name: "ClienteSequence");
        }
    }
}
