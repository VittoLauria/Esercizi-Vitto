// App con menu e funzioni di base
// le funzione sono dei principali tipi

using Newtonsoft.Json;
// ci sono due tipi di metodi dei quali uno e statico 
// il metodo statico è un metodo che puo essere invocato senza creare unistanza della classe
// static readonly -> valore condico tra tute le istanze, ma immutabile dopo linizializzazione
// public static readonly -> valore condico tra tute le istanze, ma immutabile dopo linizializzazione ed accessibile ovunque
// public -> Accessibilità -> chi puo vedere/chiamare il membro
// static -> Legame alla classe -> Membro condiviso, invocabile senza istanza
// readonly -> Immutabilita dopo inizializzazione -> Campo assegnabile solo in dichiarazione o costruttore

// creo un menu di ipzioni da scegliere quale funzione invocare
while (true)
{
    Console.Clear();
    Console.WriteLine("=== App Per imparare le funzioni ===");
    Console.WriteLine("1. Esempio funzione void");
    Console.WriteLine("2. Esempio funzione con azione");
    Console.WriteLine("3. Esempio funzione con dati complessi");
    Console.WriteLine("0. Esci");
    Console.Write("Scegli un opzione");

    // acquisisco l'input dell'utente
    string scelta = Console.ReadLine();
    // gestisco le scelte dell'utente
    switch (scelta)
    {
        case "1":
            EsempioVoid();
            break; // uso break in modo da uscire e non eseguire e altre opzioni
        case "2":
            EsempioConAzione();
            break;
        case "3":
            EsempioDatiComplessi();
            break;
        case "0":
            Console.WriteLine("Uscita del programma...");
            return; // esco dal while e quindi esco dal programma
        default:
            Console.WriteLine("Opzione non valida. Premi un tasto per continuare...");
            Console.ReadKey();
            break;
    }
}

// funzione void: non restituisce niente
static void EsempioVoid()
{
    // pulisco la console
    Console.Clear();
    Console.WriteLine("--- Funzione void ---");
    // stampo un messaggio di saluto e chiamo lalra funzione
    StampaSaluto();
    Console.WriteLine("Premi un tasto per tornare al menu...");
    Console.ReadKey();
}
// funzione void: non restituisce niente
static void StampaSaluto()
{
    Console.WriteLine("Ciao!");
}

EsempioVoid();
EsempioDatiComplessi();
// funzione void : non restituisce nulla ma esegue un azione
static void EsempioConAzione()
{
    Console.Clear();
    Console.WriteLine("--- funzione con azione");
    //chiedo i dati all'utente
    Console.WriteLine("Inserisci il primo numero: ");
    int a = int.Parse(Console.ReadLine() ?? "0");
    Console.WriteLine("Inserisci il secondo numero: ");
    int b = int.Parse(Console.ReadLine() ?? "0");

    // calcolo la somma invocando la funzione somma
    int somma = EseguiSomma(a, b);
    Console.WriteLine($"La somma di {a} e {b} è: {somma}");
    Console.WriteLine("Premi un tatso per tornare al menu...");
    Console.ReadKey();
}

// funzione con tipo di ritorno: restituisce un valorer
static int EseguiSomma(int x, int y)
{
    return x + y;
}

// funzione che gestisce dati complessi: elenco libri

static void EsempioDatiComplessi()
{
    Console.Clear();
    Console.WriteLine("--- funzione con dati complessi");
    // creo l'elenco di libri
    var libri = new List<Libro>
    {
        new Libro("Il nome della rosa", 1980, "Storico", true),
        new Libro("1984", 1949, "Distopico", false),
        new Libro("Il Signore degli Anelli", 1954, "Fantasy", true)
    };

    // filtra libri letti usando la funzione FiltraLibriLetti
    var libriLetti = FiltraLibriLetti(libri);
    // stampo i libri letti
    Console.WriteLine("Libri gia letti:");
    foreach (var libro in libriLetti)
    {
        Console.WriteLine($"- {libro.Titolo} ({libro.AnnoPubblicazione}) - {libro.Genere}");
    }
    Console.WriteLine("Premi un tasto per tornare al menu..");
    Console.ReadKey();
}

static List<Libro> FiltraLibriLetti(List<Libro> libri)
{
    // creo una lista per il filtraggio
    List<Libro> letti = new List<Libro>();
    foreach (var l in libri)
    {
        if (l.Letto)
            letti.Add(l);
    }
    return letti;
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


