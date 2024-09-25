
using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M7Tarea1.Server.Services
{
    public class ServicioVentaDetalle : IServicio
    {
        private readonly ApplicationDbContext _context;
        private ServicioProducto _servicioProducto;
        private ServicioVenta _servicioVenta;

        public ServicioVentaDetalle(ApplicationDbContext context, ServicioProducto servicioProducto, ServicioVenta servicioVenta)
        {
            _context = context;
            _servicioProducto = servicioProducto;
            _servicioVenta = servicioVenta;
        }
        public async Task Registrar(object item)
        {
            VentaDetalle ventaDetalle = (VentaDetalle)item;
            Producto producto = await _servicioProducto.GetProducto((int)ventaDetalle.ProductoId);
            Venta venta = await _servicioVenta.GetVenta(ventaDetalle.VentaId);
            ventaDetalle.Producto = producto;
            ventaDetalle.Venta = venta;

            ventaDetalle.Precio = CalcularPrecioProducto(ventaDetalle.Cantidad, ventaDetalle.Producto.nPrecioLista);
            ventaDetalle.DescuentoItem = VerificarDescuentoProducto(ventaDetalle.Producto);
            ventaDetalle.PrecioDescuento = CalcularPrecioConDescuento(ventaDetalle.Precio, ventaDetalle.DescuentoItem);

            ventaDetalle.Venta.PrecioTotal = CalcularPrecioTotalVenta(ventaDetalle.PrecioDescuento, (decimal)ventaDetalle.Venta.PrecioTotal);

            ventaDetalle.Venta.PrecioTotalDescuento = CalcularPrecioTotalDescuentoVenta((decimal)ventaDetalle.Venta.PrecioTotal, (decimal)ventaDetalle.Venta.DescuentoGlobal);


            //Impuestos
            ventaDetalle.Venta.PrecioIva = (ventaDetalle.Venta.ConIva) ? ventaDetalle.Venta.PrecioTotalDescuento * (13 / 100) : 0;
            ventaDetalle.Venta.PrecioTotalIva = ventaDetalle.Venta.PrecioTotalDescuento + ventaDetalle.Venta.PrecioIva;


            _context.VentaDetalle.Add(ventaDetalle);
            await _context.SaveChangesAsync();
        }

        private decimal CalcularPrecioProducto(int cantidad, decimal precioUnitario)
        {
            return precioUnitario * cantidad;
        }

        private decimal VerificarDescuentoProducto(Producto producto)
        {
            Descuento descuento = _servicioProducto.GetDescuentoProducto(producto.Id);

            decimal porcentajeDescuento = 0.0m;
            if (descuento != null)
            {
                porcentajeDescuento = descuento.PorcentajeDescuento;
            }

            return porcentajeDescuento;            
        }

        private decimal CalcularPrecioConDescuento(decimal precio, decimal porcentajeDescuento)
        {
            return precio - (precio * porcentajeDescuento / 100);
        }

        private decimal CalcularPrecioTotalVenta(decimal precioVentaDetalle, decimal precioVentaTotal = 0.0m)
        {
            decimal precioTotal = 0.0m;
            precioTotal = precioVentaTotal + precioVentaDetalle;
            return precioTotal;
        }
        private decimal CalcularPrecioTotalDescuentoVenta(decimal precio, decimal porcentajeDescuento)
        {
            return CalcularPrecioConDescuento(precio, porcentajeDescuento);
        }
    }
}
