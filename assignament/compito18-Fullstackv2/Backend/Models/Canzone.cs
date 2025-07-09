using Backend.Models;

namespace Backend.Models
{
    public class Canzone
    {
        public int CanzoneId { get; set; }
        public string Titolo { get; set; }
        public int Durata { get; set; } // Durata in secondi
    }
   
}