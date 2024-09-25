namespace M7Tarea1.Server.Data.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateOnly Fecha { get; set; }
        public int NitFacturacion { get; set; }
        public string NombreFacturacion { get; set; }
        public bool ConIva { get; set; }
        public decimal? DescuentoGlobal { get; set; }
        public decimal? PrecioIva { get; set; }
        public decimal? PrecioTotalIva { get; set; }
        public decimal? PrecioTotal { get; set; }
        //precio total despues de aplicar el descuento global
        public decimal? PrecioTotalDescuento {  get; set; }
        public int? PersonaId { get; set; }
        public int? EmpresaId { get; set; }

        //Navegacion
        public Persona? Persona { get; set; }
        public Empresa? Empresa { get; set; }
        public ICollection<VentaDetalle>? VentaDetalle { get; set; }

    }
}
