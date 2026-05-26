using Microsoft.EntityFrameworkCore;
using Segunda4F.Data;

namespace Segunda4F.Repositorios
{
    public class RepositorioIntereses
        : IRepositorioIntereses
    {
        private readonly DirectorioDBContext _context;

        public RepositorioIntereses(
            DirectorioDBContext context)
        {
            _context = context;
        }

        public async Task<List<Interes>>
            ObtenerIntereses()
        {
            return await _context.Intereses
                .ToListAsync();
        }

        public async Task<Interes?>
            ObtenerInteresPorId(int id)
        {
            return await _context.Intereses
                .FindAsync(id);
        }

        public async Task AgregarInteres(
            Interes interes)
        {
            _context.Intereses.Add(interes);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarInteres(
            Interes interes)
        {
            _context.Intereses.Update(interes);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarInteres(int id)
        {
            var interes =
                await _context.Intereses.FindAsync(id);

            if (interes != null)
            {
                _context.Intereses.Remove(interes);
                await _context.SaveChangesAsync();
            }
        }
    }
}