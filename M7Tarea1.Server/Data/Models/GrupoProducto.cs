using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M7Tarea1.Server.Data.Models
{
    [Table("GrupoProductos")]
    [Index(nameof(cNombreGrupoProducto))]
    public class GrupoProducto
    {
        #region Properties
        /// <summary>
        /// Unique id and primary key
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// product group code
        /// </summary>
        public string cCodGrupoProducto { get; set; }
        /// <summary>
        /// Product name
        /// </summary>
        public required string cNombreGrupoProducto { get; set; }
        #endregion

        #region Navigation Properties
        /// <summary>
        /// A collection of all the Productos related to this GrupoProducto
        /// </summary>
        public ICollection<Producto>? Productos { get; set; }
        #endregion
    }
}
