namespace VetS.Core.Models
{
    public class HistoriaMascota
    {
        public int HistoriaClinicaId { get; set; }
        public int MascotaId { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }
        public Mascota Mascota { get; set; }
    }
}
