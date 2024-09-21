using M7Tarea1.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Fabricante>(BuildFabricante);
            modelBuilder.Entity<GrupoProducto>(BuildGrupoProducto);
            modelBuilder.Entity<Producto>(BuildProducto);
            modelBuilder.Entity<Proveedor>(BuildProveedor);
        }

        #region Build Fabricante Mapping
        private void BuildFabricante(EntityTypeBuilder<Fabricante> entityBuilder)
        {
            entityBuilder.ToTable("Fabricantes");
            entityBuilder.HasKey(f => f.Id);
            entityBuilder.Property(f => f.cNmbFabricante).HasColumnType("nvarchar(100)").IsRequired();
        }
        #endregion

        #region Build Grupo Producto Mapping
        private void BuildGrupoProducto(EntityTypeBuilder<GrupoProducto> entityBuilder)
        {
            entityBuilder.ToTable("GrupoProductos");
            entityBuilder.HasKey(gp => gp.Id);
            entityBuilder.Property(gp => gp.cNombreGrupoProducto).HasColumnType("nvarchar(150)").IsRequired();
            entityBuilder.Property(gp => gp.cCodGrupoProducto).HasColumnType("nvarchar(10)");
            //entityBuilder
            //    .HasMany(gp => gp.Productos)
            //    .WithOne(gp => gp.GrupoProducto)
            //    .HasForeignKey(gp => gp.Id)
            //    .IsRequired(false);
        }
        #endregion

        #region Build Producto Mapping
        private void BuildProducto(EntityTypeBuilder<Producto> entityBuilder)
        {
            entityBuilder.ToTable("Productos");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.cSku).HasColumnType("nvarchar(25)");
            entityBuilder.Property(p => p.cNombre).HasColumnType("nvarchar(100)").IsRequired();
            entityBuilder.Property(p => p.cNombreExtrangero).HasColumnType("nvarchar(100)");
            entityBuilder.Property(p => p.nPeso).HasColumnType("decimal(8,2)");
            entityBuilder.Property(p => p.cUM).HasColumnType("nvarchar(50)");
            entityBuilder.Property(p => p.nPrecioBase).HasColumnType("decimal(8,2)");
            entityBuilder.Property(p => p.nPrecioLista).HasColumnType("decimal(8,2)");
            entityBuilder.Property(p => p.cCodBarra).HasColumnType("nvarchar(50)");
            entityBuilder.Property(p => p.cSkuFabricante).HasColumnType("nvarchar(25)");
            entityBuilder.Property(p => p.cSkuAlternante).HasColumnType("nvarchar(25)");

        }
        #endregion

        #region Build Proveedor Mapping
        private void BuildProveedor(EntityTypeBuilder<Proveedor> entityBuilder)
        {
            entityBuilder.ToTable("Proveedores");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.cNmbProveedor).HasColumnType("nvarchar(100)").IsRequired();
        }
        #endregion

    }
}
