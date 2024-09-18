using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M7Tarea1.Server.Services
{
    public class ServicioProducto : IServicio
    {
        public async void  Registrar(Object item, ApplicationDbContext context)
        {
            Producto producto = (Producto)item;
            context.Productos.Add(producto);
            await context.SaveChangesAsync();
        }

        public void RegistrarPrecioBaseProducto(int idProducto, decimal precio) { }

        public string[] getSkuAlternante(string cSkuBase)
        {
            string[] skus = [];

            return skus;
        }
    }
}
