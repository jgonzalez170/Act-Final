namespace Segunda4F.Data
{
    public class ClienteInteres
    {
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public int InteresId { get; set; }
        public Interes? Interes { get; set; }
    }
}