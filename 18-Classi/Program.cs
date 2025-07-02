


// using di Newtonsoft Json
using Newtonsoft.Json;
// comando dotnet add package Newtonsoft.Json

// libro
//La @ ci permette di andare a capo senza interrompere la stringa
/*
string json = @"{
""Titolo"": ""Il signore degli anelli"",
""AnnoPubblicazione"": 1954,
""Genere"": ""Fantasy"",
""Letto"": true,
}";

/*
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

/* stampo direttamente ongi campo accedendo direttamente alle proprieta della classe
Console.WriteLine($"Titolo : {libro.Titolo}");
Console.WriteLine($"Anno di pubblicazione : {libro.AnnoPubblicazione}");
Console.WriteLine($"Genere : {libro.Genere}");
Console.WriteLine($"Letto : {libro.Letto}"); // cosi stampera true o false altrimenti:
// Console.Writeline($"Letto : {(libro.Letto ? "si" : "no")}"); cosi stampera al posto di true si e al posto di false no

// Classe del libro, lho spostata sul file libro.cs
// Volendo si possono spostare le classi in unaltro file ad esempio Libro.cs, per mantenere il codice piu organizzato.

// Costruttori: un costruttore è un metodo che viene invcato automaticamente quando crei unistanza di una classe (con new)
/* serve a :
- Inizializzare i campi e proprieta con valori di default o obbligatori
- garantire che l'oggetto sia sempre valido(ad es. evitare valori null
- Semplificare la creazione dell'oggetto, ragguppando in un'unica chiamata tutte le assegnazioni iniziali
*/
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
