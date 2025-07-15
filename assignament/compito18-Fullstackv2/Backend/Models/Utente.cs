namespace Backend.Models
{
    public class Utente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Eta { get; set; }
        public DateTime DataNascita { get; set; }
        public string DataNascitaFormattata => DataNascita.ToString("dd/MM/yyyy");
        public Indirizzo Indirizzo { get; set; }

        public Utente(int id, string nome, int eta, DateTime dataNascita, Indirizzo indirizzo)
        {
            Id = id;
            Nome = nome;
            Eta = eta;
            DataNascita = dataNascita;
            Indirizzo = indirizzo;
        }
        public Utente() { }
    }
}