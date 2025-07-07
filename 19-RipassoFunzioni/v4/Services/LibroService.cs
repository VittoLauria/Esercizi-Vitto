
using Newtonsoft.Json;
public class LibroService
{
    // Percorso file json come variabile privata
    private readonly string _percorsoFile;

    public LibroService(string percorsoFile)
    {
        _percorsoFile = percorsoFile; // rendo pubblica la variabile in modo che possa essere manipolata esternamente alla classe LibroService
    }

    // funzione che carica i libri da un file Json
    public List<Libro> CaricaLibri()
    {
        // controllo se il file esiste prima di leggerlo
        if (!File.Exists(_percorsoFile))
        {
            throw new FileNotFoundException("File non trovato", _percorsoFile);
        }
        // leggo il contenuto del file e lo memorizzo in una stringa
        var contenuto = File.ReadAllText(_percorsoFile);
        // deserializzo il contenuto
        var elenco = JsonConvert.DeserializeObject<List<Libro>>(contenuto);
        // controllo se lelenco e null e lancio un'eccezione se lo è altrimenti ritono l'elenco
        if (elenco == null)
        {
            throw new JsonException("Deserializzazione tornata null");
        }
        return elenco; // ritorna l'elenco dei libri deserializzati
    }
    public List<Libro> FiltraLibriLetti(List<Libro> elenco)
    {
        // creo una variabile per memorizzare i libri letti
        var risultati = new List<Libro>();
        foreach (var libro in elenco)
        {
            if (libro.Letto)
            {
                risultati.Add(libro);
            }
        }
        return risultati; // ritorna l'elenco dei libri letti
    }
}
