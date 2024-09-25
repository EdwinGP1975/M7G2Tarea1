
using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M7Tarea1.Server.Services
{
    public class ServicioVenta : IServicio
    {
        private readonly ApplicationDbContext _context;
        private ServicioPersona _servicioPersona;

        public ServicioVenta(ApplicationDbContext context, ServicioPersona servicioPersona) 
        {
            _context = context;
            _servicioPersona = servicioPersona;
        }

        public async Task<Venta> GetVenta(int ventaId)
        {
            var venta = await _context.Venta.FindAsync(ventaId);

            return venta;
        }

        public async Task Registrar(object item)
        {
            Venta venta = (Venta)item;
            venta.DescuentoGlobal = 0.0m;
            if (venta.PersonaId != null)
            {
                Persona persona = _servicioPersona.GetPersona((int)venta.PersonaId).Result;
                venta.Persona = persona;
                venta.DescuentoGlobal = VerificarDescuentoGrupoCliente(venta);
            }
            
            _context.Venta.Add(venta);
            await _context.SaveChangesAsync();
        }

        private decimal VerificarDescuentoGrupoCliente(Venta venta)
        {
            
            //var grupoCliente = _servicioPersona.GetGrupoCliente(venta.Persona.GrupoClienteId);
            Descuento descuento = _servicioPersona.GetDescuentoGrupoCliente(venta.Persona.GrupoClienteId);
            decimal porcentajeDescuento = 0.0m;
            if (descuento != null) {
                porcentajeDescuento = descuento.PorcentajeDescuento;
            }

            return porcentajeDescuento;
        }
    }
}
