using Backend.Models;


namespace Backend.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Titolo { get; set; }
        public int Anno { get; set; }
        public string Autore { get; set; }
        public string Genere { get; set; }

        public bool Ascoltato { get; set; }
        public List<string> Canzoni { get; set; } = new List<Canzone>();
    }
    public Album(string titolo, int anno, string autore, string genere, bool ascoltato, List<string> canzoni)
        {
            Titolo = titolo;
            Anno = anno;
            Autore = autore;
            Genere = genere;
            Ascoltato = ascoltato;
            Canzoni = canzoni;
        }
    public Album() { } // Costruttore vuoto per la serializzazione/deserializzazione

}