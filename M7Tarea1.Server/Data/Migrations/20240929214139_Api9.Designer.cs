﻿// <auto-generated />
using System;
using M7Tarea1.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace M7Tarea1.Server.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240929214139_Api9")]
    partial class Api9
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("ClienteSequence");

            modelBuilder.Entity("AlmacenProducto", b =>
                {
                    b.Property<int>("AlmacenesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductosId")
                        .HasColumnType("int");

                    b.HasKey("AlmacenesId", "ProductosId");

                    b.HasIndex("ProductosId");

                    b.ToTable("AlmacenProducto");
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Almacen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Almacenes", (string)null);
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [ClienteSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("GrupoClienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrupoClienteId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Descuento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("FechaFin")
                        .HasColumnType("Date");

                    b.Property<DateOnly>("FechaInicio")
                        .HasColumnType("Date");

                    b.Property<int?>("GrupoClienteId")
                        .HasColumnType("int");

                    b.Property<decimal>("PorcentajeDescuento")
                        .HasColumnType("decimal(4,2)");

                    b.Property<int?>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrupoClienteId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Descuentos", (string)null);
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Fabricante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("cNmbFabricante")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Fabricantes", (string)null);
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.GrupoCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("GrupoCliente", (string)null);
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.GrupoProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("cCodGrupoProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("cNombreGrupoProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("GrupoProductos", (string)null);
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FabricanteId")
                        .HasColumnType("int");

                    b.Property<int>("GrupoProductoId")
                        .HasColumnType("int");

                    b.Property<string>("cCodBarra")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("cNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("cNombreExtrangero")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("cSku")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("cSkuAlternante")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("cSkuFabricante")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("cUM")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("nPeso")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("nPrecioBase")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("nPrecioLista")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.HasIndex("FabricanteId");

                    b.HasIndex("GrupoProductoId");

                    b.ToTable("Productos", (string)null);
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<string>("cNmbProveedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.ToTable("Proveedores", (string)null);
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<int?>("DescuentoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("UnidadVenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DescuentoId");

                    b.ToTable("Servicios", (string)null);
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("ConIva")
                        .HasColumnType("bit");

                    b.Property<decimal?>("DescuentoGlobal")
                        .HasColumnType("decimal(4,2)");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("Date");

                    b.Property<int>("NitFacturacion")
                        .HasColumnType("int");

                    b.Property<string>("NombreFacturacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("PersonaId")
                        .HasColumnType("int");

                    b.Property<decimal?>("PrecioIva")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal?>("PrecioTotal")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal?>("PrecioTotalDescuento")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal?>("PrecioTotalIva")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Ventas", (string)null);
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.VentaDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("DescuentoItem")
                        .HasColumnType("decimal(4,2)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("PrecioDescuento")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int?>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int?>("ServicioId")
                        .HasColumnType("int");

                    b.Property<string>("UnidadMedida")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VentaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("ServicioId");

                    b.HasIndex("VentaId");

                    b.ToTable("VentaDetalle", (string)null);
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Empresa", b =>
                {
                    b.HasBaseType("M7Tarea1.Server.Data.Models.Cliente");

                    b.Property<int>("Nit")
                        .HasColumnType("int");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.ToTable("Empresas", (string)null);
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Persona", b =>
                {
                    b.HasBaseType("M7Tarea1.Server.Data.Models.Cliente");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Ci")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.ToTable("Personas", (string)null);
                });

            modelBuilder.Entity("AlmacenProducto", b =>
                {
                    b.HasOne("M7Tarea1.Server.Data.Models.Almacen", null)
                        .WithMany()
                        .HasForeignKey("AlmacenesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("M7Tarea1.Server.Data.Models.Producto", null)
                        .WithMany()
                        .HasForeignKey("ProductosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Cliente", b =>
                {
                    b.HasOne("M7Tarea1.Server.Data.Models.GrupoCliente", "GrupoCliente")
                        .WithMany("Clientes")
                        .HasForeignKey("GrupoClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoCliente");
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Descuento", b =>
                {
                    b.HasOne("M7Tarea1.Server.Data.Models.GrupoCliente", "GrupoCliente")
                        .WithMany("Descuento")
                        .HasForeignKey("GrupoClienteId");

                    b.HasOne("M7Tarea1.Server.Data.Models.Producto", "Producto")
                        .WithMany("Descuento")
                        .HasForeignKey("ProductoId");

                    b.Navigation("GrupoCliente");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Producto", b =>
                {
                    b.HasOne("M7Tarea1.Server.Data.Models.Fabricante", "Fabricante")
                        .WithMany("Productos")
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("M7Tarea1.Server.Data.Models.GrupoProducto", "GrupoProducto")
                        .WithMany("Productos")
                        .HasForeignKey("GrupoProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fabricante");

                    b.Navigation("GrupoProducto");
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Proveedor", b =>
                {
                    b.HasOne("M7Tarea1.Server.Data.Models.Producto", "Producto")
                        .WithMany("Proveedores")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Servicio", b =>
                {
                    b.HasOne("M7Tarea1.Server.Data.Models.Descuento", "Descuento")
                        .WithMany()
                        .HasForeignKey("DescuentoId");

                    b.Navigation("Descuento");
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Venta", b =>
                {
                    b.HasOne("M7Tarea1.Server.Data.Models.Empresa", "Empresa")
                        .WithMany("Ventas")
                        .HasForeignKey("EmpresaId");

                    b.HasOne("M7Tarea1.Server.Data.Models.Persona", "Persona")
                        .WithMany("Ventas")
                        .HasForeignKey("PersonaId");

                    b.Navigation("Empresa");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.VentaDetalle", b =>
                {
                    b.HasOne("M7Tarea1.Server.Data.Models.Producto", "Producto")
                        .WithMany("VentaDetalle")
                        .HasForeignKey("ProductoId");

                    b.HasOne("M7Tarea1.Server.Data.Models.Servicio", "Servicio")
                        .WithMany("VentaDetalle")
                        .HasForeignKey("ServicioId");

                    b.HasOne("M7Tarea1.Server.Data.Models.Venta", "Venta")
                        .WithMany("VentaDetalle")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Servicio");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Fabricante", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.GrupoCliente", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Descuento");
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.GrupoProducto", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Producto", b =>
                {
                    b.Navigation("Descuento");

                    b.Navigation("Proveedores");

                    b.Navigation("VentaDetalle");
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Servicio", b =>
                {
                    b.Navigation("VentaDetalle");
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Venta", b =>
                {
                    b.Navigation("VentaDetalle");
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Empresa", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("M7Tarea1.Server.Data.Models.Persona", b =>
                {
                    b.Navigation("Ventas");
                });
#pragma warning restore 612, 618
        }
    }
}
