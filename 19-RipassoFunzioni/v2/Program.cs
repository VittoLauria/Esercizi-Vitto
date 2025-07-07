// La funzione con dati complessi dve leggere i dati da un file Json invece che da un elenco interno 
// deve essere implementata la gestione degli errori per la lettura dei file Json
// Funzione che gestisce dati comlessi
static void EsempioDatiComplessi()
{
    Console.Clear();
    Console.WriteLine("--- esempio con dati complessi (da Json) ---");

    // percorso file Json
    string percorsoFile = "libri.json";
    // lista per memorizzare i libri deserializzati
    List<Libro> elencoLibri;
    // Proviamo a leggere il file Json implementando la gestione degli errori
    try
    {
        // in questo bloccco mettiamo il codice che deve eseere provato
        // controllo se il file esiste
        if (!File.Exists(percorsoFile))
            //se non esiste lanco un'eccezione FileNotFoundException
            // il throw serve a lanciare un'eccezione personalizzata
            throw new FileNotFoundException("File non trovato.", percorsoFile);
        // se il file siste leggo il contenuto 
        string contenutoJson = File.ReadAllText(percorsoFile);
        // poi deserializzo il contenuto
        elencoLibri = JsonConvert.DeserializeObject<List<Libro>>(contenutoJson);
        // se la deserializzazione restituisce null lancio un eccezione JsonException per gstire errori di parsing e formattazione Json
        if (elencoLibri == null)
            throw new JsonException("Deserializzazione tornata null");
    }
    // Catch per gestire le eccezione specifiche (il file deve essre nella cartella)
    catch (FileNotFoundException ex)
    {
        Console.WriteLine($"Errore: {ex.Message} ({ex.FileName})");
        Console.WriteLine("Verifica che il file esista nella cartella dell'eseguibile");
        Console.WriteLine("Premi un tasto per tornare al menu..");
        Console.ReadKey();
        return;
    }
    // catch per gestire eccezione specifiche (il file non e un Json valido)
    catch (JsonException ex)
    {
        Console.WriteLine($"Errore parsing Json: {ex.Message}");
        Console.WriteLine("Controlla il formato del file Json.");
        Console.WriteLine("Premi un tasto per tornare al menu..");
        Console.ReadKey();
        return;
    }
    // catch per gestire altre eccezione generiche
    catch (Exception ex)
    {
        Console.WriteLine($"Errore imprevisto: {ex.Message}");
        Console.WriteLine("Premi un tasto per tornare al menu..");
        Console.ReadKey();
        return;
    }
}

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
}