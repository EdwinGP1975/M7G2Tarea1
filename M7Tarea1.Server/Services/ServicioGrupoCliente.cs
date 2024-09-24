using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace M7Tarea1.Server.Services
{
    public class ServicioGrupoCliente : IServicio
    {
        private readonly ApplicationDbContext _context;
        private ServicioDescuento _servicioDescuento;
        public ServicioGrupoCliente(ApplicationDbContext context, ServicioDescuento servicioDescuento)
        {
            _context = context;
            _servicioDescuento = servicioDescuento;
        }

        public async Task<GrupoCliente> GetGrupoCliente(int grupoClienteId)
        {
            var grupoCliente = await _context.GrupoCliente.FindAsync(grupoClienteId);

            return grupoCliente;
        }

        public async Task Registrar(object item)
        {
            GrupoCliente grupoCliente= (GrupoCliente)item;
            _context.GrupoCliente.Add(grupoCliente);
            await _context.SaveChangesAsync();
        }

        public Descuento GetDescuentoGrupoCliente(int grupoClienteId) 
        {
            var grupoCliente = GetGrupoCliente(grupoClienteId).Result;
            var descuento = _servicioDescuento.GetDescuentoGrupoCliente(grupoCliente.Id);
            return descuento;
        }
    }
}
