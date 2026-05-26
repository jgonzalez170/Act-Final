using System.ComponentModel.DataAnnotations;

namespace Segunda4F.Data
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;
        public int? TipoClienteId { get; set; }

        public TipoCliente? TipoCliente { get; set; }

        public ICollection<ClienteInteres> ClienteIntereses { get; set; }
            = new List<ClienteInteres>();
    }
}