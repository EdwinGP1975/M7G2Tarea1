using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M7Tarea1.Server.Services
{
    public class ServicioProducto : IServicio
    {
        private readonly ApplicationDbContext _context;
        public ServicioProducto(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Registrar(Object item)
        {
            Producto producto = (Producto)item;
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
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
