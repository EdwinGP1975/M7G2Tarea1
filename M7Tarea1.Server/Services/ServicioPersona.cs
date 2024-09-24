
using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;

namespace M7Tarea1.Server.Services
{
    public class ServicioPersona : IServicio
    {
        private readonly ApplicationDbContext _context;
        private ServicioGrupoCliente _servicioGrupoCliente;
        public ServicioPersona(ApplicationDbContext context, ServicioGrupoCliente servicioGrupoCliente)
        {
            _context = context;
            _servicioGrupoCliente = servicioGrupoCliente;
        }

        public async Task<Persona> GetPersona(int id)
        {
            var persona = await _context.Persona.FindAsync(id);

            return persona;
        }

        public async Task Registrar(object item)
        {
            Persona persona=(Persona)item;
            _context.Persona.Add(persona);
            await _context.SaveChangesAsync();
        }

        public GrupoCliente GetGrupoCliente(int id)
        {
            var grupoCliente = _servicioGrupoCliente.GetGrupoCliente(id).Result;
            return grupoCliente;
        }

        public Descuento GetDescuentoGrupoCliente(int grupoClienteId)
        {
            var descuento = _servicioGrupoCliente.GetDescuentoGrupoCliente(grupoClienteId);
            return descuento;
        }
    }
}
