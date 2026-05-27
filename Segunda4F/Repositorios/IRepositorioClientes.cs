using Segunda4F.Data;

namespace Segunda4F.Repositorios
{
    public interface IRepositorioClientes
    {
        Task AgregarCliente(
      Cliente cliente,
      List<int> interesesIds);

        Task<List<Cliente>> ObtenerClientes();

        Task<Cliente?> ObtenerClientePorId(int id);


        Task ActualizarCliente(
            Cliente cliente,
            List<int> interesesIds);

        Task EliminarCliente(int id);
    }
}