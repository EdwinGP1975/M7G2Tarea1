namespace M7Tarea1.Server.Data.Models
{
    public class VentaDetalle
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Precio {
            get;// => Producto.nPrecioLista * Cantidad;
            set;// => Precio = value;
        }
        public decimal DescuentoItem { get; set; }
        public decimal PrecioDescuento { get; set; }
        public int VentaId { get; set; }
        public int? ProductoId {  get; set; }
        public int? ServicioId { get; set; }

        //Navegacion
        public Venta? Venta { get; set; }
        public Producto? Producto { get; set; }
        public Servicio? Servicio { get; set; }
    }
}
