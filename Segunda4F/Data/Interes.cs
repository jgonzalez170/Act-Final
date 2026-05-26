using System.ComponentModel.DataAnnotations;

namespace Segunda4F.Data
{
    public class Interes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<ClienteInteres> ClienteIntereses { get; set; }
            = new List<ClienteInteres>();
    }
}