namespace VetS.Core.Models
{
    public class ClienteMascota
    {
        public int ClienteId { get; set; }
        public int MascotaId { get; set; }
        public Cliente Cliente { get; set; }
        public Mascota Mascota { get; set; }
    }
}
