public class Libro
{
    public string Titolo { get; set; }
    public int AnnoPubblicazione { get; set; }               // Proprieta pubbliche accessibile tramite i metodi get e set
    public string Genere { get; set; }
    public bool Letto { get; set; }

    // costruttore di default
    public Libro()
    {
        // inizializza i valori di default deve essere senza parametri
        Titolo = "sconosciuto";
        AnnoPubblicazione = 2000;
        Genere = "N/A";
        Letto = false;
    }
     // definiscio il costruttore che si chiamera come la classe senza pero il tipo di ritorno
    public Libro(string titolo, int annoPubblicazione, string genere, bool letto)
    {//qui inizializzo le proprieta con i valori passati
        Titolo = titolo;
        AnnoPubblicazione = annoPubblicazione;
        Genere = genere;
        Letto = letto;
    }
}
