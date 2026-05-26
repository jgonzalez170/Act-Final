using Segunda4F.Data;

namespace Segunda4F.Repositorios
{
    public interface IRepositorioClientes
    {
        Task AgregarCliente(Cliente cliente);

        Task<List<Cliente>> ObtenerClientes();

        Task<Cliente?> ObtenerClientePorId(int id);

        Task ActualizarCliente(Cliente cliente);

        Task EliminarCliente(int id);
    }
}