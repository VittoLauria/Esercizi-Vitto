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