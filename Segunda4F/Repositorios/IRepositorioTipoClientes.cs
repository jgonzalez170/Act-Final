using Segunda4F.Data;

namespace Segunda4F.Repositorios
{
    public interface IRepositorioTipoClientes
    {
        Task AgregarTipoCliente(
            TipoCliente tipoCliente);

        Task<List<TipoCliente>>
            ObtenerTipoClientes();

        Task<TipoCliente?>
            ObtenerTipoClientePorId(int id);

        Task ActualizarTipoCliente(
            TipoCliente tipoCliente);

        Task EliminarTipoCliente(int id);
    }
}