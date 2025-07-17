namespace Backend.Models
{
    public class Acquisto
    {
        public int Id { get; set; }
        public int UtenteId { get; set; }
        public int AlbumId { get; set; }
        public DateTime DataAcquisto { get; set; }

    }
}