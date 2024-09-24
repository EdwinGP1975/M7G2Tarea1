using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M7Tarea1.Server.Data.Models
{
    public class Producto
    {
        #region Properties
        /// <summary>
        /// Unique Id that is the primary Key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        ///  Stock Keeping Unit code
        /// </summary>
        public string cSku { get; set; }
        /// <summary>
        /// Product name
        /// </summary>
        public string cNombre { get; set; }
        /// <summary>
        /// Foreign product name in other countries
        /// </summary>
        public string cNombreExtrangero { get; set; }
        /// <summary>
        /// Product weight
        /// </summary>
        [Column(TypeName = "decimal(8,2)")]
        public decimal nPeso { get; set; }
        /// <summary>
        /// Unit of Measure
        /// </summary>
        public string cUM { get; set; }
        /// <summary>
        /// List Price of the product
        /// </summary>
        [Column(TypeName = "decimal(8,2)")]
        public decimal nPrecioLista { get; set; }
        /// <summary>
        /// Base price of the product
        /// </summary>
        [Column(TypeName = "decimal(8,2)")]
        public decimal nPrecioBase { get; set; }
        /// <summary>
        /// Barcode of the product
        /// </summary>
        public string cCodBarra { get; set; }
        /// <summary>
        /// Stock Keeping Unit code of the producer
        /// </summary>
        public string cSkuFabricante { get; set; }
        /// <summary>
        /// Alternative Stock Keeping Unit code 
        /// </summary>
        public string cSkuAlternante { get; set; }

        /// <summary>
        /// GrupoProductoId (foreign key)
        /// </summary>
        public int GrupoProductoId { get; set; }

        /// <summary>
        /// FabricanteId (foreign key)
        /// </summary>
        public int FabricanteId { get; set; }
        #endregion

        #region Navigation Properties
        /// <summary>
        ///  The GrupoProducto related to this producto
        /// </summary>
        public GrupoProducto? GrupoProducto { get; set; }
        
        /// <summary>
        ///  a collection of all the Proveedores related to this Producto
        /// </summary>
        public ICollection<Proveedor>? Proveedores { get; set; }

        /// <summary>
        /// the Fabricante related to this Producto
        /// </summary>
        public Fabricante? Fabricante { get; set; }
        public ICollection<VentaDetalle>? VentaDetalle { get; set; }
        public ICollection<Almacen>? Almacenes { get; set; }
        public ICollection<Descuento>? Descuento {  get; set; }
        #endregion
    }
}
