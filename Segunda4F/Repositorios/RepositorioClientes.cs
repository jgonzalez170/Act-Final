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
                .Include(c => c.ClienteIntereses)
                    .ThenInclude(ci => ci.Interes)
                .ToListAsync();
        }

        public async Task<Cliente?>
            ObtenerClientePorId(int id)
        {
            return await _context.Clientes
                .Include(c => c.ClienteIntereses)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AgregarCliente(
            Cliente cliente,
            List<int> interesesIds)
        {
            bool correoExiste =
    await _context.Clientes
    .AnyAsync(c =>
        c.Correo == cliente.Correo);

            if (correoExiste)
            {
                throw new Exception(
                    "Ya existe un cliente con ese correo");
            }
            _context.Clientes.Add(cliente);

            await _context.SaveChangesAsync();

            foreach (var interesId in interesesIds)
            {
                _context.ClienteIntereses.Add(
                    new ClienteInteres
                    {
                        ClienteId = cliente.Id,
                        InteresId = interesId
                    });
            }

            await _context.SaveChangesAsync();
        }

        public async Task ActualizarCliente(
      Cliente cliente,
      List<int> interesesIds)
        {
            var clienteExistente =
                await _context.Clientes
                .FirstOrDefaultAsync(
                    c => c.Id == cliente.Id);

            if (clienteExistente == null)
                return;
            bool correoExiste =
    await _context.Clientes
    .AnyAsync(c =>
        c.Correo == cliente.Correo
        && c.Id != cliente.Id);

            if (correoExiste)
            {
                throw new Exception(
                    "Ya existe un cliente con ese correo");
            }
            // Actualizar datos básicos
            clienteExistente.Nombre =
                cliente.Nombre;

            clienteExistente.Telefono =
                cliente.Telefono;

            clienteExistente.Correo =
                cliente.Correo;

            clienteExistente.TipoClienteId =
                cliente.TipoClienteId;

            // Obtener relaciones actuales
            var relacionesActuales =
                await _context.ClienteIntereses
                .Where(ci => ci.ClienteId == cliente.Id)
                .ToListAsync();

            // Borrarlas
            _context.ClienteIntereses.RemoveRange(
                relacionesActuales);

            await _context.SaveChangesAsync();

            // Crear nuevas relaciones
            foreach (var interesId in interesesIds)
            {
                _context.ClienteIntereses.Add(
                    new ClienteInteres
                    {
                        ClienteId = cliente.Id,
                        InteresId = interesId
                    });
            }

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