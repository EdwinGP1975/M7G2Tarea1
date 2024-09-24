
using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M7Tarea1.Server.Services
{
    public class ServicioVentaDetalle : IServicio
    {
        private readonly ApplicationDbContext _context;

        public ServicioVentaDetalle(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Registrar(object item)
        {
            VentaDetalle ventaDetalle = (VentaDetalle)item;
            ventaDetalle.PrecioDescuento = CalcularPrecioConDescuento(ventaDetalle.Precio, ventaDetalle.DescuentoItem);

            ventaDetalle.Venta.PrecioTotal = CalcularPrecioTotalVenta(ventaDetalle.PrecioDescuento, (decimal)ventaDetalle.Venta.PrecioTotal);
            
            _context.VentaDetalle.Add(ventaDetalle);
            await _context.SaveChangesAsync();
        }

        public decimal CalcularPrecioConDescuento(decimal precio, decimal porcentajeDescuento)
        {
            return precio - (precio * porcentajeDescuento / 100);
        }

        public decimal CalcularPrecioTotalVenta(decimal precioVentaDetalle, decimal precioVentaTotal = 0.0m)
        {
            decimal precioTotal = 0.0m;
            precioTotal = precioVentaTotal + precioVentaDetalle;
            return precioTotal;
        }
    }
}
