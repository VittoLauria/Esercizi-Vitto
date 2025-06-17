// ESEMPIO DI DESERIALIZZAZIONE (Lettura)

using Newtonsoft.Json; // importazione libreria 

// percorso del file json
string path = @"persona.json";


// anche cosi : Partecipante partecipante = JsonConvert.DeserializeObject<Partecipante>(File.ReadAllText(path));
// deserializzazione tramite newtonsoft.json
// Partecipante partecipante = JsonSerializer.Deserialize<Partecipante>(json);

string json = File.ReadAllText(path); // Leggo il contenuto del file
// deserializzo il file json in un oggetto
Partecipante partecipante = JsonConvert.DeserializeObject<Partecipante>(json);

// una volta deserializzato, posso accedere ai campi dell'oggetto
//nome
Console.WriteLine($"Nome: {partecipante.nome}");
//eta
Console.WriteLine($"Eta: {partecipante.eta}");
//presente
Console.WriteLine($"Presente: {partecipante.presente}");
// interessi
Console.WriteLine("interessi:");

foreach (var interesse in partecipante.interessi)
{
    Console.WriteLine($"{interesse}");
}
// oppure con il Join
Console.WriteLine($"Interessi: {string.Join(", ", partecipante.interessi)}");

//deseriallizare un nodo specifico in quetso caso indirizzo che e formato da piu campi tipo "via" "citta" e "cap"
//indirizzo
Console.WriteLine($"Indirizzo: {partecipante.indirizzo.via}, {partecipante.indirizzo.citta}, {partecipante.indirizzo.cap}");



// ESEMPIO DI SERIALIZZAZIONE (Scrittura)

//creao un nuovo oggetto Partecioane tramite il costruttore new
Partecipante nuovoPartecipante = new Partecipante
// lo inizializzo con i valori desiderati
{
    nome = "nuovo Partecipante",
    eta = 25,
    presente = true,
    interessi = new List<string> { "arte", "viaggi", "cucina" },
    indirizzo = new Indirizzo
    {
        via = "Via Milano",
        citta = "Roma",
        cap = "00100"
    }
};
// serializzo l'oggetto in un file json
string jsonOutput = JsonConvert.SerializeObject(nuovoPartecipante,  Formatting.Indented);
// scegliere percorso file json
string outputPath = @"output.json";
// scrivo il file json
File.WriteAllText(outputPath, json);
// stampare a console il json
Console.WriteLine($"JSON serielizzato:");
Console.WriteLine(jsonOutput);

// ESEMPIO MODIFICA del valore di un campo FILE JSON
// modifica nome del partecipante
partecipante.nome = "Partecipante modificato";
//serializzo nuovamenente l'oggetto in un file json
string jsonModificato = JsonConvert.SerializeObject(partecipante, Formatting.Indented);
// scrivo il file json
File.WriteAllText(path, jsonModificato);
// stampo il file modificato
Console.WriteLine("JSON MODIFICATO:");
Console.WriteLine(jsonModificato);

// ESEMPIO DI CANCELLAZIONE DI UN FILE JSON
//cancello il file json
if (File.Exists(path))
{
    File.Delete(path);
    Console.WriteLine($"File {path} cancellato.");
}
else
{
    Console.WriteLine($"Il file {path} non esiste");
}


// creare la classe partecipante
public class Partecipante
{
    public string nome { get; set; } // campo string
    public int eta { get; set; } // campo int
    public bool presente { get; set; } // campo bool
    public List<string> interessi { get; set; } // campo list di stringhe
    public Indirizzo indirizzo { get; set; } // campo oggetto di tipo indirizzo
}

public class Indirizzo
{
    public string via { get; set; }
    public string citta { get; set; }
    public string cap { get; set; }
}

