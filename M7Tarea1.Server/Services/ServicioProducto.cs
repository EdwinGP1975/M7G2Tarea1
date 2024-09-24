using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M7Tarea1.Server.Services
{
    public class ServicioProducto : IServicio
    {
        private readonly ApplicationDbContext _context;
        private ServicioDescuento _servicioDescuento;
        public ServicioProducto(ApplicationDbContext context, ServicioDescuento servicioDescuento)
        {
            _context = context;
            _servicioDescuento = servicioDescuento;
        }

        public async Task<Producto> GetProducto(int productoId)
        {
            var producto = await _context.Productos.FindAsync(productoId);

            return producto;
        }
        public async Task Registrar(Object item)
        {
            Producto producto = (Producto)item;
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public Descuento GetDescuentoProducto(int productoId)
        {
            return _servicioDescuento.GetDescuentoProducto(productoId);
        }

        public void RegistrarPrecioBaseProducto(int idProducto, decimal precio) { }

        public string[] getSkuAlternante(string cSkuBase)
        {
            string[] skus = [];

            return skus;
        }

        public void RegistrarMinimoMaximoMRPAlmacen() { }
    }
}
