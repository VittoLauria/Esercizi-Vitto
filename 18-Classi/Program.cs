


// using di Newtonsoft Json
using Newtonsoft.Json;
/*
// comando dotnet add package Newtonsoft.Json

// libro
//La @ ci permette di andare a capo senza interrompere la stringa

string json = @"{
""Titolo"": ""Il signore degli anelli"",
""AnnoPubblicazione"": 1954,
""Genere"": ""Fantasy"",
""Letto"": true,
}";


// faccio il parse in un oggetto generico
JObject libro = JObject.Parse(json);

// stampo direttamente ogni campo
Console.WriteLine($"Titolo: {libro["Titolo"]}");
Console.WriteLine($"Anno di pubblicazione: {libro["AnnoPubblicazione"]}");
Console.WriteLine($"Genere: {libro["Genere"]}");
Console.WriteLine($"Letto: {libro["Letto"]}");


// Deserializzazione con le classe

// using di Newtonsoft Json
// using Newtonsoft.Json.Linq lo coommento perche ce gia su 
// comando dotnet add package Newtonsoft.Json
Libro libro = JsonConvert.DeserializeObject<Libro>(json);

 stampo direttamente ongi campo accedendo direttamente alle proprieta della classe
Console.WriteLine($"Titolo : {libro.Titolo}");
Console.WriteLine($"Anno di pubblicazione : {libro.AnnoPubblicazione}");
Console.WriteLine($"Genere : {libro.Genere}");
Console.WriteLine($"Letto : {libro.Letto}"); // cosi stampera true o false altrimenti:
// Console.Writeline($"Letto : {(libro.Letto ? "si" : "no")}"); cosi stampera al posto di true si e al posto di false no

// Classe del libro, lho spostata sul file libro.cs
// Volendo si possono spostare le classi in unaltro file ad esempio Libro.cs, per mantenere il codice piu organizzato.

// Costruttori: un costruttore è un metodo che viene invcato automaticamente quando crei unistanza di una classe (con new)
serve a :
- Inizializzare i campi e proprieta con valori di default o obbligatori
- garantire che l'oggetto sia sempre valido(ad es. evitare valori null
- Semplificare la creazione dell'oggetto, ragguppando in un'unica chiamata tutte le assegnazioni iniziali

Libro libro = new Libro(
titolo: "Il signore degli anelli",
annoPubblicazione: 1954,
genere: "Fantasy",
letto: true
);



// ora possiamo creare un nuovo libro molto piu semplicemente usando il costruttore parametrico

// per stamapre e uguale
Console.WriteLine($"Titolo : {libro.Titolo}");
Console.WriteLine($"Anno di pubblicazione : {libro.AnnoPubblicazione}");
Console.WriteLine($"Genere : {libro.Genere}");
Console.WriteLine($"Letto : {(libro.Letto ? "si" : "no")}");


// VANTAGGI
// Oggetto sempre completo non si rischia di dimenticare di impostare una prorpieta
// Codice piu pulito in un unica riga di new Libro(...) pass tutti i valori, anziche settarli uno a uno dopo la creazione

// COSTRUTTORE DI DEFAULT
// se non sindichiara nessin constuttore, viene fornito un costruttore senza parametri(default) pero appena dichiariamo il costruttore personalizzato quello di default scomoare, quindi dobbaimo definirlo in modo esplicito

new Libro(); // creo un libro di default
new Libro("Titolo del libro", 2025, "Fantascienza", false); // creo un libro personalizzato

*/

// Il programma deve chidere allutente di inserire i dati fino a quando non dice no e deve inserire gli elementi in una lista se l'utente dimentica di inserire un dato il costruttore della classe deve gestire i valori vuoti


var elencoLibri = new List<Libro>(); // creo una lista di libri non tipizzata perche ogni inerimentio e composto da piu campi

// incomincio il while di inserimento dati dell'utente
// il ciclo continua fino a quando lutente non dice di volere terminare inserendo no
while (true)
{
    // acquisisco il titolo del libro
    Console.WriteLine("Titolo del libro: (schiaccia invio per terminare) ");
    string titolo = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(titolo)) // se lutente non inserisce nulla esce dal ciclo
    {
        break;
    }

    // acquisisco l'anno di pubblicazione del libro
    Console.WriteLine("Anno di pubblicazione: ");
    string annoInput = Console.ReadLine();
    int anno = 2000;
    if (string.IsNullOrWhiteSpace(annoInput) && !int.TryParse(annoInput, out anno))
    {
        anno = 2000; // valore di dafault
    }

    // acquisico il genere del libro
    Console.WriteLine("Genere (invio per N/A)");
    string genere = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(genere))
        genere = "N/A";

    //acquisico se il libro e stato letto
    Console.WriteLine("L'hai letto?");
    string lettoInput = Console.ReadLine().Trim().ToLower();
    bool letto = false;
    if (lettoInput == "s" || lettoInput == "si" || lettoInput == "true")
    {
        letto = true;
    }
    // creo un nuovo libro con i dati inseriti
    // Libro libro = new Libro(titolo, anno, genere, letto)
    // costruisco il libro con il costruttore parametrizzato che gestisce i default
    var libro = new Libro(titolo, anno, genere, letto);
    //aggiungo il libri
    elencoLibri.Add(libro);

    // stampo il libro inserito
    Console.WriteLine("Libro Aggiunto!\n");
}

// stampo lelelnco dei libri inseriti
Console.WriteLine("\n=== Elenco dei libri inseriti ===");
foreach (var libro in elencoLibri)
{
    Console.WriteLine($"Titolo: {libro.Titolo}, Anno: {libro.AnnoPubblicazione}, Genere: {libro.Genere}, Letto: {(libro.Letto ? "Si" : "No")})");
}

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
        Titolo = string.IsNullOrWhiteSpace(titolo) ? "Sconosciuto" : titolo;
        AnnoPubblicazione = annoPubblicazione != 0 ? annoPubblicazione : 2000;
        Genere = string.IsNullOrWhiteSpace(genere) ? "N/A" : genere;
        Letto = letto;
    }
}
