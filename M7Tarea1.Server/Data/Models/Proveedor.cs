using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M7Tarea1.Server.Data.Models
{
    [Table("Proveedores")]
    [Index(nameof(cNmbProveedor))]
    public class Proveedor
    {
        #region Properties
        /// <summary>
        /// Unique id and primary key
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }
        public required string cNmbProveedor { get; set; }

        /// <summary>
        /// ProductoId (foreign key)
        /// </summary>
        [ForeignKey(nameof(Producto))]
        public int ProductoId { get; set; }
        #endregion

        #region Navigation Properties
        /// <summary>
        /// The Producto related to this Fabricante
        /// </summary>
        public Producto? Producto { get; set; }
        #endregion
    }
}
