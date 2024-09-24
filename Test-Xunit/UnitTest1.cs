using M7Tarea1.Server.Controllers;
using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;
using M7Tarea1.Server.Services;
using Microsoft.CodeAnalysis.Options;
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
        public async void RegistrarVenta_1Producto_Total_1Item()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "M7G2")
                .Options;
            using var context = new ApplicationDbContext(options);

            var servicioDescuento = new ServicioDescuento(context);
            var servicioProducto = new ServicioProducto(context,servicioDescuento);
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

            
            var servicioGrupoCliente = new ServicioGrupoCliente(context, servicioDescuento);
            var servicioPersona = new ServicioPersona(context, servicioGrupoCliente);
            var servicioVenta = new ServicioVenta(context, servicioPersona);
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

            var servicioVentaDetalle = new ServicioVentaDetalle(context, servicioProducto, servicioVenta);
            var controllerVentaDetalle = new VentaDetalleController(context, servicioVentaDetalle);
            int cantidadProducto = 1;
            decimal precioTotalProducto = producto.nPrecioLista * cantidadProducto;
            var ventaDetalle = new VentaDetalle()
            {
                VentaId = venta.Id,
                ProductoId = producto.Id,
                //Producto = producto,
                Cantidad = cantidadProducto,
                UnidadMedida = "unidad",
                Precio = 0,
                DescuentoItem = 0,
                PrecioDescuento = 0,
                //Venta = venta
            };

            // Act
            var resultRegistrarVentaDetalle = controllerVentaDetalle.PostVentaDetalle(ventaDetalle);

            // Assert
            Assert.NotNull(resultRegistrarVentaDetalle);
            Assert.NotNull(ventaDetalle.Id);
            Assert.Single(venta.VentaDetalle);
            Assert.NotNull(venta.VentaDetalle.First().Id);
            Assert.NotNull(ventaDetalle.Venta);
            Assert.Equal(precioTotalProducto, ventaDetalle.Precio);
            Assert.Equal(precioTotalProducto, ventaDetalle.Venta.PrecioTotal);
        }

        [Fact]
        public async void RegistrarVenta_2Productos_Total_3Items()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "M7G2")
                .Options;
            using var context = new ApplicationDbContext(options);

            var servicioDescuento = new ServicioDescuento(context);
            var servicioProducto = new ServicioProducto(context, servicioDescuento);
            var controllerProducto = new ProductosController(context, servicioProducto);
            decimal precioListaProducto = 112.8m;
            Producto producto1 = new Producto()
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
            var resultRegistrarProducto1 = (await controllerProducto.PostProducto(producto1)).Result;
            
            Producto producto2 = new Producto()
            {
                cSku = "100022",
                cNombre = "Teclado",
                cNombreExtrangero = "KeyBoard",
                nPeso = 280.1m,
                cUM = "gr",
                nPrecioBase = 142.0m,
                nPrecioLista = precioListaProducto,
                cCodBarra = "2236541874",
                cSkuFabricante = "MT80017",
                cSkuAlternante = "13401014",
            };
            var resultRegistrarProducto2 = (await controllerProducto.PostProducto(producto2)).Result;

            var servicioGrupoCliente = new ServicioGrupoCliente(context, servicioDescuento);
            var servicioPersona = new ServicioPersona(context, servicioGrupoCliente);
            var servicioVenta = new ServicioVenta(context, servicioPersona);
            var controllerVentas = new VentasController(context, servicioVenta);
            var venta = new Venta()
            {
                Codigo = "000001",
                Fecha = DateOnly.FromDateTime(DateTime.Today),
                NitFacturacion = 100100100,
                NombreFacturacion = "Empresa Bienes Raices Tu Casa",
                ConIva = false,
                DescuentoGlobal = 0,
                PrecioTotal = 0,
                PrecioTotalDescuento = 0
            };
            var resultRegistrarVenta = controllerVentas.PostVenta(venta);

            var servicioVentaDetalle = new ServicioVentaDetalle(context, servicioProducto, servicioVenta);
            var controllerVentaDetalle = new VentaDetalleController(context, servicioVentaDetalle);
            
            int cantidadProducto1 = 1;
            decimal precioTotalProducto1 = producto1.nPrecioLista * cantidadProducto1;
            var ventaDetalle1 = new VentaDetalle()
            {
                VentaId = venta.Id,
                ProductoId = producto1.Id,
                //Producto = producto1,
                Cantidad = cantidadProducto1,
                UnidadMedida = "unidad",
                Precio = 0,
                DescuentoItem = 0,
                PrecioDescuento = 0,
                //Venta = venta
            };

            int cantidadProducto2 = 2;
            decimal precioTotalProducto2 = producto2.nPrecioLista * cantidadProducto2;
            var ventaDetalle2 = new VentaDetalle()
            {
                VentaId = venta.Id,
                ProductoId =producto2.Id,
                //Producto = producto2,
                Cantidad = cantidadProducto2,
                UnidadMedida = "unidad",
                Precio = 0,
                DescuentoItem = 0,
                PrecioDescuento = 0,
                //Venta = venta
            };

            // Act
            var resultRegistrarVentaDetalle1 = controllerVentaDetalle.PostVentaDetalle(ventaDetalle1);
            var resultRegistrarVentaDetalle2 = controllerVentaDetalle.PostVentaDetalle(ventaDetalle2);

            // Assert
            Assert.Equal(2, venta.VentaDetalle.Count);

            Assert.NotNull(resultRegistrarVentaDetalle1);
            Assert.NotNull(ventaDetalle1.Id);
            Assert.NotNull(venta.VentaDetalle.ElementAt(0).Id);
            Assert.NotNull(ventaDetalle1.Venta);
            Assert.Equal(precioTotalProducto1, ventaDetalle1.Precio);

            Assert.NotNull(resultRegistrarVentaDetalle2);
            Assert.NotNull(ventaDetalle2.Id);
            Assert.NotNull(venta.VentaDetalle.ElementAt(1).Id);
            Assert.NotNull(ventaDetalle2.Venta);
            Assert.Equal(precioTotalProducto2, ventaDetalle2.Precio);

            Assert.Equal(precioTotalProducto1 + precioTotalProducto2, venta.PrecioTotal);
        }

        [Fact]
        public async void RegistrarVenta_1ItemConDescuentoProducto()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "M7G2")
                .Options;
            using var context = new ApplicationDbContext(options);

            var servicioDescuento = new ServicioDescuento(context);
            var servicioProducto = new ServicioProducto(context, servicioDescuento);
            var controllerProducto = new ProductosController(context, servicioProducto);
            decimal precioListaProducto = 156.3m;
            Producto producto = new Producto()
            {
                cSku = "100022",
                cNombre = "Teclado",
                cNombreExtrangero = "KeyBoard",
                nPeso = 280.1m,
                cUM = "gr",
                nPrecioBase = 142.0m,
                nPrecioLista = precioListaProducto,
                cCodBarra = "2236541874",
                cSkuFabricante = "MT80017",
                cSkuAlternante = "13401014",
            };
            var resultRegistrarProducto = (await controllerProducto.PostProducto(producto)).Result;

            var controllerDescuento = new DescuentosController(context, servicioDescuento);
            Descuento descuento = new Descuento()
            {
                PorcentajeDescuento = 2.5m,
                FechaInicio = new DateOnly(2024, 9, 1),
                FechaFin = new DateOnly(2024, 9, 30),
                ProductoId = producto.Id,
                //Producto = producto
            };
            var resultRegistrarDescuento = await controllerDescuento.PostDescuento(descuento);

            var servicioGrupoCliente = new ServicioGrupoCliente(context, servicioDescuento);
            var servicioPersona = new ServicioPersona(context, servicioGrupoCliente);
            var servicioVenta = new ServicioVenta(context, servicioPersona);
            var controllerVentas = new VentasController(context, servicioVenta);
            var venta = new Venta()
            {
                Codigo = "000002",
                Fecha = DateOnly.FromDateTime(DateTime.Today),
                NitFacturacion = 100100100,
                NombreFacturacion = "Empresa Consultora Finanzas PYME",
                ConIva = false,
                DescuentoGlobal = 0,
                PrecioTotal = 0,
                PrecioTotalDescuento = 0
            };
            var resultRegistrarVenta = controllerVentas.PostVenta(venta);

            var servicioVentaDetalle = new ServicioVentaDetalle(context, servicioProducto, servicioVenta);
            var controllerVentaDetalle = new VentaDetalleController(context, servicioVentaDetalle);
            int cantidadProducto = 1;
            decimal precioTotalProducto = producto.nPrecioLista * cantidadProducto;
            decimal porcentajeDescuentoProducto = producto.Descuento.ElementAt(0).PorcentajeDescuento;
            decimal precioTotalProductoDescuento = precioTotalProducto - (precioTotalProducto * porcentajeDescuentoProducto / 100);
            var ventaDetalle = new VentaDetalle()
            {
                VentaId = venta.Id,
                ProductoId = producto.Id,
                //Producto = producto,
                Cantidad = cantidadProducto,
                UnidadMedida = "unidad",
                Precio = 0,
                DescuentoItem = 0,
                PrecioDescuento = 0,
                //Venta = venta
            };

            // Act
            var resultRegistrarVentaDetalle = controllerVentaDetalle.PostVentaDetalle(ventaDetalle);

            // Assert
            Assert.NotNull(resultRegistrarVentaDetalle);
            Assert.NotNull(ventaDetalle.Id);
            Assert.Single(venta.VentaDetalle);
            Assert.NotNull(venta.VentaDetalle.First().Id);
            Assert.NotNull(ventaDetalle.Venta);
            Assert.Equal(precioTotalProducto, ventaDetalle.Precio);
            Assert.Equal(porcentajeDescuentoProducto, ventaDetalle.DescuentoItem);
            Assert.Equal(precioTotalProductoDescuento, ventaDetalle.PrecioDescuento);
            Assert.Equal(precioTotalProductoDescuento, ventaDetalle.Venta.PrecioTotal);
        }

        [Fact]
        public async void RegistrarVenta_1ItemConDescuentoGrupoCliente()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "M7G2")
                .Options;
            using var context = new ApplicationDbContext(options);

            var servicioDescuento = new ServicioDescuento(context);
            var servicioProducto = new ServicioProducto(context, servicioDescuento);
            var controllerProducto = new ProductosController(context, servicioProducto);
            decimal precioListaProducto = 1012.8m;
            Producto producto = new Producto()
            {
                cSku = "4200681",
                cNombre = "Pantalla",
                cNombreExtrangero = "Monitor",
                nPeso = 2.5m,
                cUM = "kg",
                nPrecioBase = 985.0m,
                nPrecioLista = precioListaProducto,
                cCodBarra = "65417874123",
                cSkuFabricante = "MT150176",
                cSkuAlternante = "10141340",
            };
            var resultRegistrarProducto = (await controllerProducto.PostProducto(producto)).Result;
            
            var controllerDescuento = new DescuentosController(context, servicioDescuento);
            var servicioGrupoCliente = new ServicioGrupoCliente(context, servicioDescuento);
            var controllerGrupoCliente = new GrupoClientesController(context, servicioGrupoCliente);
            GrupoCliente grupoCliente = new GrupoCliente()
            {
                Codigo = "GC1001",
                Nombre = "Empleados de la empresa Fino",
                Clientes = new List<Cliente>()
            };
            var resultRegistrarGrupoCliente = await controllerGrupoCliente.PostGrupoCliente(grupoCliente);

            Descuento descuentoGrupoCliente = new Descuento()
            {
                PorcentajeDescuento = 5.5m,
                FechaInicio = new DateOnly(2024, 9, 1),
                FechaFin = new DateOnly(2024, 9, 30),
                GrupoClienteId = grupoCliente.Id,
            };
            var resultRegistrarDescuento = await controllerDescuento.PostDescuento(descuentoGrupoCliente);

            var servicioPersona = new ServicioPersona(context,servicioGrupoCliente);
            var controllerPersona = new PersonasController(context, servicioPersona);
            Persona persona = new Persona()
            {
                Codigo = "P14531",
                Email = "luis.pedrazas10@gmail.com",
                Nombre = "Luis",
                Apellidos = "Pedrazas",
                Ci = 2156321,
                GrupoClienteId = grupoCliente.Id,
            };
            var resultRegistrarPersona = controllerPersona.PostPersona(persona);

            grupoCliente.Clientes.Add(persona);
            var resultActualizarGrupoCliente = await controllerGrupoCliente.PutGrupoCliente(grupoCliente.Id, grupoCliente);
            
            var servicioVenta = new ServicioVenta(context, servicioPersona);
            var controllerVentas = new VentasController(context, servicioVenta);
            var venta = new Venta()
            {
                PersonaId = persona.Id,
                Codigo = "000013",
                Fecha = DateOnly.FromDateTime(DateTime.Today),
                NitFacturacion = persona.Ci,
                NombreFacturacion = persona.Apellidos,
                ConIva = false,
                DescuentoGlobal = 0,
                PrecioTotal = 0,
                PrecioTotalDescuento = 0
            };
            var resultRegistrarVenta = controllerVentas.PostVenta(venta);

            var servicioVentaDetalle = new ServicioVentaDetalle(context, servicioProducto,servicioVenta);
            var controllerVentaDetalle = new VentaDetalleController(context, servicioVentaDetalle);
            int cantidadProducto = 1;
            decimal precioTotalProducto = producto.nPrecioLista * cantidadProducto;
            var ventaDetalle = new VentaDetalle()
            {
                VentaId = venta.Id,
                ProductoId = producto.Id,
                Cantidad = cantidadProducto,
                UnidadMedida = "unidad",
                Precio = 0,
                DescuentoItem = 0,
                PrecioDescuento = 0,
            };
            
            // Act
            var resultRegistrarVentaDetalle = controllerVentaDetalle.PostVentaDetalle(ventaDetalle);

            decimal porcentajeDescuentoGrupoCliente = grupoCliente.Descuento.ElementAt(0).PorcentajeDescuento;
            decimal precioTotalVenta = precioTotalProducto;
            decimal precioTotalVentaConDescuento = (decimal)(venta.PrecioTotal - (venta.PrecioTotal * porcentajeDescuentoGrupoCliente / 100));

            // Assert
            Assert.NotNull(resultRegistrarVentaDetalle);
            Assert.NotNull(ventaDetalle.Id);
            Assert.Single(venta.VentaDetalle);
            Assert.NotNull(venta.VentaDetalle.First().Id);
            Assert.NotNull(ventaDetalle.Venta);
            Assert.Equal(precioTotalVenta, venta.PrecioTotal);
            Assert.Equal(precioTotalVentaConDescuento, venta.PrecioTotalDescuento);           
        }

    }
}