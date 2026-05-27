using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Segunda4F.Data
{
    [Index(nameof(Correo), IsUnique = true)]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Phone]
        [Required]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;
        public int? TipoClienteId { get; set; }

        public TipoCliente? TipoCliente { get; set; }

        public ICollection<ClienteInteres> ClienteIntereses { get; set; }
            = new List<ClienteInteres>();
    }
}