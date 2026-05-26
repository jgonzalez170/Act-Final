using Segunda4F.Data;

namespace Segunda4F.Repositorios
{
    public interface IRepositorioIntereses
    {
        Task AgregarInteres(
            Interes interes);

        Task<List<Interes>>
            ObtenerIntereses();

        Task<Interes?>
            ObtenerInteresPorId(int id);

        Task ActualizarInteres(
            Interes interes);

        Task EliminarInteres(int id);
    }
}