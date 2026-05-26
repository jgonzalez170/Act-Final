using Microsoft.EntityFrameworkCore;
using Segunda4F.Data;

namespace Segunda4F.Repositorios
{
    public class RepositorioClientes
        : IRepositorioClientes
    {
        private readonly DirectorioDBContext _context;

        public RepositorioClientes(
            DirectorioDBContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>>
            ObtenerClientes()
        {
            return await _context.Clientes
                .Include(c => c.TipoCliente)
                .ToListAsync();
        }

        public async Task<Cliente?>
            ObtenerClientePorId(int id)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AgregarCliente(
            Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarCliente(
            Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarCliente(int id)
        {
            var cliente =
                await _context.Clientes.FindAsync(id);

            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}