using System.ComponentModel.DataAnnotations;

namespace Segunda4F.Data
{
    public class TipoCliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Cliente> Clientes { get; set; }
            = new List<Cliente>();
    }
}