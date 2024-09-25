using M7Tarea1.Server.Controllers;
using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;
using M7Tarea1.Server.Services;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace Test_Xunit
{
    public class VentaServiceTest
    {

        [Fact]
        public async Task registrarVentaConImpuesto()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "VentasDB")
                .Options;
            using var context = new ApplicationDbContext(options);

            // Registrar productos
            var servicioDescuento = new ServicioDescuento(context);
            var servicioProducto = new ServicioProducto(context, servicioDescuento);
            var controllerProducto = new ProductosController(context, servicioProducto);

            decimal precioListaProducto = 112.8m;

            Producto producto1 = new Producto()
            {
                cSku = "100025",
                cNombre = "Audifonos",
                cNombreExtrangero = "Auriculares",
                nPeso = 180.1m,
                cUM = "gr",
                nPrecioBase = 168.0m,
                nPrecioLista = precioListaProducto,
                cCodBarra = "2236541384",
                cSkuFabricante = "MT56013",
                cSkuAlternante = "13921012",
            };

            Producto producto2 = new Producto()
            {
                cSku = "100026",
                cNombre = "Pantalla pc",
                cNombreExtrangero = "Monitor",
                nPeso = 280.1m,
                cUM = "Kg",
                nPrecioBase = 142.0m,
                nPrecioLista = precioListaProducto,
                cCodBarra = "2236541171",
                cSkuFabricante = "MT50011",
                cSkuAlternante = "13604023",
            };

            await controllerProducto.PostProducto(producto1);
            await controllerProducto.PostProducto(producto2);

            // Registrar la venta
            var servicioPersona = new ServicioPersona(context, new  ServicioGrupoCliente(context, servicioDescuento));
            var servicioVenta = new ServicioVenta(context, servicioPersona);
            var controllerVenta = new VentasController(context, servicioVenta);

            var venta = new Venta
            {
                Codigo = "V123",
                Fecha = DateOnly.FromDateTime(DateTime.Now),
                NitFacturacion = 12345678,
                NombreFacturacion = "Cliente con IVA",
                ConIva = true,
                PrecioTotal = 0, // Se recalculará más adelante
                DescuentoGlobal = 0,
                PrecioTotalDescuento = 0
            };

            var result = await controllerVenta.PostVenta(venta);

            // Registrar detalles de la venta
            var servicioVentaDetalle = new ServicioVentaDetalle(context, servicioProducto, servicioVenta);
            var controllerVentaDetalle = new VentaDetalleController(context, servicioVentaDetalle);

            var ventaDetalle1 = new VentaDetalle
            {
                VentaId = venta.Id,
                ProductoId = producto1.Id,
                Cantidad = 1,
                UnidadMedida = "unidad",
                Precio = 0,
                DescuentoItem = 0,
                PrecioDescuento = 0
            };

            var ventaDetalle2 = new VentaDetalle
            {
                VentaId = venta.Id,
                ProductoId = producto2.Id,
                Cantidad = 2,
                UnidadMedida = "unidad",
                Precio = 0, // Dos productos
                DescuentoItem = 0,
                PrecioDescuento = 0
            };

            await controllerVentaDetalle.PostVentaDetalle(ventaDetalle1);
            await controllerVentaDetalle.PostVentaDetalle(ventaDetalle2);

            // Recalcular el total de la venta
            venta.PrecioTotal = ventaDetalle1.Precio + ventaDetalle2.Precio;

            // Assert: verificamos la venta y sus detalles
            var ventaRegistrada = await context.Venta.FindAsync(venta.Id);
            Assert.NotNull(ventaRegistrada);
            Assert.Equal(venta.ConIva, ventaRegistrada.ConIva);
            Assert.Equal(venta.PrecioTotal, ventaRegistrada.PrecioTotal);

            var detalles = context.VentaDetalle.Where(vd => vd.VentaId == venta.Id).ToList();
            Assert.Equal(2, detalles.Count); // Dos detalles de venta
        }
    }
}
