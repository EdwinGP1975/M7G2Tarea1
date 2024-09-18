using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M7Tarea1.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cNmbFabricante = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cCodGrupoProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cNombreGrupoProducto = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoProductos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cSku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cNombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cNombreExtrangero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nPeso = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    cUM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nPrecioLista = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    nPrecioBase = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    cCodBarra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cSkuFabricante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cSkuAlternante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrupoProductoId = table.Column<int>(type: "int", nullable: false),
                    FabricanteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Fabricantes_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_GrupoProductos_GrupoProductoId",
                        column: x => x.GrupoProductoId,
                        principalTable: "GrupoProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cNmbProveedor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedores_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fabricantes_cNmbFabricante",
                table: "Fabricantes",
                column: "cNmbFabricante");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoProductos_cNombreGrupoProducto",
                table: "GrupoProductos",
                column: "cNombreGrupoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_cNombre",
                table: "Productos",
                column: "cNombre");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FabricanteId",
                table: "Productos",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_GrupoProductoId",
                table: "Productos",
                column: "GrupoProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_cNmbProveedor",
                table: "Proveedores",
                column: "cNmbProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_ProductoId",
                table: "Proveedores",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropTable(
                name: "GrupoProductos");
        }
    }
}
