using M7Tarea1.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M7Tarea1.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<GrupoProducto> GrupoProductos => Set<GrupoProducto>();
        public DbSet<Proveedor> Proveedor => Set<Proveedor>();
        public DbSet<Fabricante> Fabricante => Set<Fabricante>();

        public ApplicationDbContext() : base()
        {            
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {           
        }


    }
}
