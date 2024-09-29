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
        public DbSet<Servicio> Servicio => Set<Servicio>();
        public DbSet<Almacen> Almacen => Set<Almacen>();
        public DbSet<Persona> Persona => Set<Persona>();
        public DbSet<Empresa> Empresa => Set<Empresa>();
        public DbSet<GrupoCliente> GrupoCliente => Set<GrupoCliente>();
        public DbSet<Venta> Venta => Set<Venta>();
        public DbSet<VentaDetalle> VentaDetalle => Set<VentaDetalle>();
        public DbSet<Descuento> Descuento => Set<Descuento>();

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
            modelBuilder.Entity<GrupoCliente>(BuildGrupoCliente);
            modelBuilder.Entity<Cliente>().UseTpcMappingStrategy();
            modelBuilder.Entity<Persona>(BuildPersona);
            modelBuilder.Entity<Empresa>(BuildEmpresa);
            modelBuilder.Entity<Venta>(BuildVenta);
            modelBuilder.Entity<VentaDetalle>(BuildVentaDetalle);
            modelBuilder.Entity<Servicio>(BuildServicio);
            modelBuilder.Entity<Almacen>(BuildAlmacen);
            modelBuilder.Entity<Descuento>(BuildDescuento);
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

        #region Grupo Cliente Mapping
        private void BuildGrupoCliente(EntityTypeBuilder<GrupoCliente> entityBuilder)
        {
            entityBuilder.ToTable("GrupoCliente");
            entityBuilder.HasKey(gp => gp.Id);
            entityBuilder.Property(gp => gp.Codigo).HasColumnType("nvarchar(25)").IsRequired();
            entityBuilder.Property(gp => gp.Nombre).HasColumnType("nvarchar(100)").IsRequired();
        }
        #endregion

        #region Persona Mapping
        private void BuildPersona(EntityTypeBuilder<Persona> entityBuilder) {
            entityBuilder.ToTable("Personas");
            //entityBuilder.HasKey(p => p.Id);
            //entityBuilder.Property(p => p.Id).HasColumnName("PersonaId");
            entityBuilder.Property(p => p.Codigo).HasColumnType("nvarchar(25)").IsRequired();
            entityBuilder.Property(p => p.Email).HasColumnType("nvarchar(100)");
            entityBuilder.Property(p => p.Nombre).HasColumnType("nvarchar(50)").IsRequired();
            entityBuilder.Property(p => p.Apellidos).HasColumnType("nvarchar(100)").IsRequired();
            entityBuilder.Property(p => p.Ci).HasColumnType("int");
            entityBuilder.Property(p => p.TipoDocumento).HasColumnType("nvarchar(100)");
        }
        #endregion

        #region Empresa Mapping
        private void BuildEmpresa(EntityTypeBuilder<Empresa> entityBuilder)
        {
            entityBuilder.ToTable("Empresas");
            //entityBuilder.HasKey(e => e.Id);
            //entityBuilder.Property(p => p.Id).HasColumnName("EmpresaId");
            entityBuilder.Property(e => e.Codigo).HasColumnType("nvarchar(25)").IsRequired();
            entityBuilder.Property(e => e.Email).HasColumnType("nvarchar(100)");
            entityBuilder.Property(e => e.RazonSocial).HasColumnType("nvarchar(100)").IsRequired();
            entityBuilder.Property(e => e.Nit).HasColumnType("int").IsRequired();
        }
        #endregion

        #region Venta Mapping
        private void BuildVenta(EntityTypeBuilder<Venta> entityBuilder)
        {
            entityBuilder.ToTable("Ventas");
            entityBuilder.HasKey(v => v.Id);
            entityBuilder.Property(v => v.Codigo).HasColumnType("nvarchar(25)").IsRequired();
            entityBuilder.Property(v => v.Fecha).HasColumnType("Date").IsRequired();
            entityBuilder.Property(v => v.NitFacturacion).HasColumnType("int");
            entityBuilder.Property(v => v.NombreFacturacion).HasColumnType("nvarchar(100)").IsRequired();
            entityBuilder.Property(v => v.ConIva).HasColumnType("bit");
            entityBuilder.Property(v => v.DescuentoGlobal).HasColumnType("decimal(4,2)");
            entityBuilder.Property(v => v.PrecioTotal).HasColumnType("decimal(8,2)");
            entityBuilder.Property(v => v.PrecioTotalDescuento).HasColumnType("decimal(8,2)");
            entityBuilder.Property(v => v.PrecioIva).HasColumnType("decimal(8,2)");
            entityBuilder.Property(v => v.PrecioTotalIva).HasColumnType("decimal(8,2)");
        }
        #endregion

        #region Venta Detalle Mapping
        private void BuildVentaDetalle(EntityTypeBuilder<VentaDetalle> entityBuilder)
        {
            entityBuilder.ToTable("VentaDetalle");
            entityBuilder.HasKey(v => v.Id);
            entityBuilder.Property(v => v.Cantidad).HasColumnType("int").IsRequired();
            entityBuilder.Property(v => v.UnidadMedida).HasColumnType("nvarchar(50)").IsRequired();
            entityBuilder.Property(v => v.Precio).HasColumnType("decimal(8,2)").IsRequired();
            entityBuilder.Property(v => v.DescuentoItem).HasColumnType("decimal(4,2)");
            entityBuilder.Property(v => v.PrecioDescuento).HasColumnType("decimal(8,2)");                
        }
        #endregion

        #region Servicio Mapping
        private void BuildServicio(EntityTypeBuilder<Servicio> entityBuilder)
        {
            entityBuilder.ToTable("Servicios");
            entityBuilder.HasKey(s => s.Id);
            entityBuilder.Property(s => s.Codigo).HasColumnType("nvarchar(25)").IsRequired();
            entityBuilder.Property(s => s.Nombre).HasColumnType("nvarchar(100)").IsRequired();
            entityBuilder.Property(s => s.Precio).HasColumnType("decimal(8,2)").IsRequired();
            entityBuilder.Property(s => s.UnidadVenta).HasColumnType("nvarchar(50)").IsRequired();
        }
        #endregion

        #region Almacen Mapping
        private void BuildAlmacen(EntityTypeBuilder<Almacen> entityBuilder)
        {
            entityBuilder.ToTable("Almacenes");
            entityBuilder.HasKey(a => a.Id);
            entityBuilder.Property(a => a.Codigo).HasColumnType("nvarchar(25)").IsRequired();
            entityBuilder.Property(a => a.Direccion).HasColumnType("nvarchar(250)");
        }
        #endregion

        #region Descuento Mapping
        private void BuildDescuento(EntityTypeBuilder<Descuento> entityBuilder)
        {
            entityBuilder.ToTable("Descuentos");
            entityBuilder.HasKey(d => d.Id);
            entityBuilder.Property(d => d.PorcentajeDescuento).HasColumnType("decimal(4,2)").IsRequired();
            entityBuilder.Property(d => d.FechaInicio).HasColumnType("Date");
            entityBuilder.Property(d => d.FechaFin).HasColumnType("Date");
        }
        #endregion

    }
}
