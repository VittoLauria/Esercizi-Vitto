namespace Backend.Models
{
    public class AcquistoDTO
    {
        public int Id { get; set; }
        public string NomeUtente { get; set; }
        public string TitoloAlbum { get; set; }
        public List<Canzone> Canzoni { get; set; } = new List<Canzone>();
        public DateTime DataAcquisto { get; set; }
    }
}