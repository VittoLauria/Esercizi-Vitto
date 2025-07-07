// Versione 3 
// separazione dell eresponsabilita con Services
// in questa versione separiamo la logica di business n un servizio dedicato
// In questo caso il servizio gestirà la logica di caricamento e filtraggio dei libri
// in questo modo il codice principale rimane piu pulit e facilmente testabile
// in questa vs diamo un senso alla funzione somma che fino ad adesso era scollegta 
// e la usiamo in modo da calcolare il titole dei libri letti o non letti
// anziche usare lo switch usiamo un menu con delle condizioni if (ci serve come esercizio)

using Newtonsoft.Json;

var servizio = new LibroService("libri.json");

while (true)
{
    Console.Clear();
    Console.WriteLine("=== App Per imparare le funzioni ===");
    Console.WriteLine("1. Esempio funzione void");
    Console.WriteLine("2. Esempio funzione con azione");
    Console.WriteLine("3. Esempio funzione con dati complessi");
    Console.WriteLine("0. Esci"); // esce con qualsiasi input che non sia 1 o 2 o 3
    Console.Write("Scegli un opzione");
    // acquisico l'input dell'utente
    string op = Console.ReadLine()?.Trim();
    // oppure acquisico direttamente l'input dell'utente pulito da spazi in eccesso facenco string op = Console.ReadLine()?.ToTrim();
    // con il ? evito il warning del dato che potrebbe essere null

    if (op == "1")
    {
        StampaSaluto();
    }
    else if (op == "2")
    {
        EseguiSomma();
    }
    else if (op == "3")
    {
        EseguiDatiComplessi(servizio);
    }
    else
    {
        break;
    }
}
static void StampaSaluto()
{
    Console.WriteLine("Ciao");
     Console.WriteLine("Premi un tasto...");
    Console.ReadKey();
}
static void EseguiSomma()
{
    Console.Write("primo numero?");
    int a = int.Parse(Console.ReadLine());
    Console.WriteLine("secondo numero?");
    int b = int.Parse(Console.ReadLine());
    Console.WriteLine($"Risultato: {a + b}");
    Console.WriteLine("Premi un tasto...");
    Console.ReadKey();
}
// funzione che si occupa di caricare i vari servizi
static void EseguiDatiComplessi(LibroService servizio)
{
    Console.Clear();
    Console.WriteLine("--- Libri da JSON ---");
    try
    {
        // carico l'elenco dei libri
        var elenco = servizio.CaricaLibri();
        // applico il filtro sui libri letti
        var letti = servizio.FiltraLibriLetti(elenco);
        // calcolo il numero di libri gia letti
        int numLetti = letti.Count;
        // calcolo il numero dei libri da leggere
        int numNonLetti = elenco.Count - numLetti;
        // calcolo il totale dei libri
        int totale = Somma(numLetti, numNonLetti);

        //stampo i libri gia letti
        Console.WriteLine("Libri gia letti:");
        foreach (var libro in letti)
        {
            Console.WriteLine($"Libri letti: {libro.Titolo} - {libro.AnnoPubblicazione} - ({libro.Genere})");
        }
        // stampo il totale dei libri letti e non letti
        Console.WriteLine($"Totale libri: {totale} (Letti: {numLetti}, Non Letti: {numNonLetti})");
    }
    // eccezione generica
    catch (Exception ex)
    {
        Console.WriteLine($"Errore: {ex.Message}");
    }
    Console.WriteLine("Premi un tasto...");
    Console.ReadKey();

    static int Somma(int x, int y)
    {
        return x + y;
    }
}

// Servizo dedicato alla logica di lettura e filtro dei libri
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

// Modello dati Libro
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


/*
 SPIEGAZIONE DETTAGLIATA

1.Servizio
var servizio = new LibroService("libri.Json");
 qui ho instanziato un oggetto di tipo LibroService, passando al suo costruttore il percorse del file json da cui caricare i dati (libri.json
 Lo faccio perche spostando la logica di parsing-creazione-filtraggio dei libri in una classe dedicata il program.cs rimane pulito concentrandosi solo sui metodi

 2.LibroService
 Nel codice di LibroService abbiamo questo 
 private readonly string _percosoFile
 public LibroService ( string percorsoFile)
 {
    _percorsoFile = percorsoFile;
 }

 - private readonly string _percosoFile => indica che il campo è privato visibile solo dento LibroService
 - readonly garantisce che il valore venga assegnato una volta sola ( nel costruttore) e non possa piu cambiarlo
 - il nome è preceduto dal underscore perche in c# indica una variabile privata

 public LibroService(string percorsoFile)
 - costruttore pubblico
 - permette a chiunque di creare un'istanza del servizio, fornend il file di dati da caricare
 nella classe Libro invece

    public string Titolo { get; set; }
    public int AnnoPubblicazione { get; set; }               // Proprieta pubbliche accessibile tramite i metodi get e set
    public string Genere { get; set; }
    public bool Letto { get; set; }

- sono proprieta pubbliche
- descrivono l'oggetto e sono accessibili da chiunque istanzi un oggetto Libro, e possono essere lette e scritte durante la deserializzazione Json
- le proprieta automatiche get e set permettono di non dover scrivere manualmente i campi privati e i metodi di accesso

 */