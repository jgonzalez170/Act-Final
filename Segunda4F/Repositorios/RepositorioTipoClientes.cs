using Microsoft.EntityFrameworkCore;
using Segunda4F.Data;

namespace Segunda4F.Repositorios
{
    public class RepositorioTipoClientes
        : IRepositorioTipoClientes
    {
        private readonly DirectorioDBContext _context;

        public RepositorioTipoClientes(
            DirectorioDBContext context)
        {
            _context = context;
        }

        public async Task<List<TipoCliente>>
            ObtenerTipoClientes()
        {
            return await _context.TipoClientes
                .ToListAsync();
        }

        public async Task<TipoCliente?>
            ObtenerTipoClientePorId(int id)
        {
            return await _context.TipoClientes
                .FindAsync(id);
        }

        public async Task AgregarTipoCliente(
            TipoCliente tipoCliente)
        {
            _context.TipoClientes.Add(tipoCliente);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarTipoCliente(
            TipoCliente tipoCliente)
        {
            _context.TipoClientes.Update(tipoCliente);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarTipoCliente(int id)
        {
            var tipoCliente =
                await _context.TipoClientes.FindAsync(id);

            if (tipoCliente != null)
            {
                _context.TipoClientes.Remove(tipoCliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}