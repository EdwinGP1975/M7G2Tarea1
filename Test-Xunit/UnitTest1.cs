using M7Tarea1.Server.Controllers;
using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;
using M7Tarea1.Server.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace Test_Xunit
{
    public class UnitTest1
    {
        [Fact]
        public async void GetAlmacenes()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "M7G2")
                .Options;
            using var context = new ApplicationDbContext(options);

            context.Add(new Almacen()
            {
                Id = 1,
                Codigo = "A1001",
                Nombre = "Almacen General",
                Direccion = "San Martin"
            });
            context.SaveChanges();

            var controller = new AlmacenesController(context);
            Almacen? almacenExistente = null;
            Almacen? almacenNoExistente = null;

            // Act
            almacenExistente = (await controller.GetAlmacen(1)).Value;
            almacenNoExistente = (await controller.GetAlmacen(2)).Value;

            // Assert
            Assert.NotNull(almacenExistente);
            Assert.Null(almacenNoExistente);
        }

        [Fact]
        public async void RegistrarGrupoProducto()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "M7G2")
                .Options;
            using var context = new ApplicationDbContext(options);
            var servicioGrupoProducto = new ServicioGrupoProducto(context);

            var controller = new GrupoProductosController(context, servicioGrupoProducto);
            GrupoProducto? grupoExistente = null;
            GrupoProducto grupoProducto = new GrupoProducto()
            {
                cCodGrupoProducto = "gp10001",
                cNombreGrupoProducto = "Impresoras"
            };

            // Act
            var result = (await controller.PostGrupoProducto(grupoProducto)).Result;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, grupoProducto.Id);
        }

        [Fact]
        public async void RegistrarVenta_1Item()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "M7G2")
                .Options;
            using var context = new ApplicationDbContext(options);

            var servicioProducto = new ServicioProducto(context);
            var controllerProducto = new ProductosController(context, servicioProducto);
            decimal precioListaProducto = 112.8m;
            Producto producto = new Producto()
            {
                cSku = "100021",
                cNombre = "Raton",
                cNombreExtrangero = "Mouse",
                nPeso = 150.6m,
                cUM = "gr",
                nPrecioBase = 105.0m,
                nPrecioLista = precioListaProducto,
                cCodBarra = "102310231023",
                cSkuFabricante = "M10010",
                cSkuAlternante = "1000101",
            };
            var resultRegistrarProducto = (await controllerProducto.PostProducto(producto)).Result;

            var servicioVenta = new ServicioVenta(context);
            var controllerVentas = new VentasController(context, servicioVenta);
            var venta = new Venta()
            {
                Codigo = "000001",
                Fecha = DateOnly.FromDateTime(DateTime.Today),
                NitFacturacion = 100100100,
                NombreFacturacion = "Empresa Consultora Tus Cuentas al día",
                ConIva = false,
                DescuentoGlobal = 0,
                PrecioTotal = 0,
                PrecioTotalDescuento = 0
            };
            var resultRegistrarVenta = controllerVentas.PostVenta(venta);

            var servicioVentaDetalle = new ServicioVentaDetalle(context);
            var controllerVentaDetalle = new VentaDetalleController(context, servicioVentaDetalle);
            int cantidadProducto = 1;
            decimal precioTotalProducto = producto.nPrecioLista * cantidadProducto;
            var ventaDetalle = new VentaDetalle()
            {
                VentaId = venta.Id,
                Producto = producto,
                Cantidad = cantidadProducto,
                UnidadMedida = "unidad",
                Precio = precioTotalProducto, 
                DescuentoItem = 0,
                PrecioDescuento = 0,
                Venta = venta
            };

            // Act
            var resultRegistrarVentaDetalle = controllerVentaDetalle.PostVentaDetalle(ventaDetalle);

            // Assert
            Assert.NotNull(resultRegistrarVentaDetalle);
            Assert.Equal(1, ventaDetalle.Id);
            Assert.Single(venta.VentaDetalle);
            Assert.Equal(1, venta.VentaDetalle.First().Id);
            Assert.NotNull(ventaDetalle.Venta);
            Assert.Equal(precioTotalProducto, ventaDetalle.Precio);
            Assert.Equal(precioTotalProducto, ventaDetalle.Venta.PrecioTotal);
        }

        
    }
}