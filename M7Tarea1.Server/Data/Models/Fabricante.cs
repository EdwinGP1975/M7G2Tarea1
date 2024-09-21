using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M7Tarea1.Server.Data.Models
{
    public class Fabricante
    {
        #region Properties
        /// <summary>
        /// Unique id and primary key
        /// </summary>
        public int Id { get; set; }
        public string cNmbFabricante { get; set; }
        #endregion

        #region Navigation Properties
        /// <summary>
        /// The Productos related to this Fabricante
        /// </summary>
        public ICollection<Producto>? Productos { get; set; }
        #endregion
    }
}
