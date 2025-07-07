
public class Libro
{
    public string Titolo { get; set; }
    public int AnnoPubblicazione { get; set; }               // Proprieta pubbliche accessibile tramite i metodi get e set
    public string Genere { get; set; }
    public bool Letto { get; set; }
    public Libro(string titolo, int annoPubblicazione, string genere, bool letto)
    {
        Titolo = titolo;
        AnnoPubblicazione = annoPubblicazione;
        Genere = genere;
        Letto = letto;
    }
    public Libro() { }
}