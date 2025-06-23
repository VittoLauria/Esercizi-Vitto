using Newtonsoft.Json;
string path = @"prodotti";
List<string> prodotti = new List<string>();
Product prodotto = new Product();
var posizione = prodotto.Posizione;

VerificaFolders(path);
void VerificaFolders(string path)
{
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
        Console.WriteLine($"Cartella {path} creata!");
    }
}
int CalcolaNuovoId(string prodotti)
{
    var lista = prodotti.Split(',').ToList();
    int maxId = 0;

    foreach (var p in lista)
    {
        if (int.TryParse(p.Trim(), out int id))
        {
            if (id > maxId)
                maxId = id;
        }
    }

    return maxId + 1;
}
List<string> ListFiles(string path)
{
    List<string> fileNames = new List<string>();
    if (!Directory.Exists(path))
    {
        Console.WriteLine("il file non e stato trovato..");
    }
    else
    {
        string[] files = Directory.GetFiles(path);
        foreach (var file in files)
        {
            string nameFile = Path.GetFileName(file);
            Console.WriteLine(nameFile);
            fileNames.Add(nameFile);
        }
    }
    return fileNames;
}
List<string> ReadProduct(string path)
{
    if (!File.Exists(path))
    {
        Console.WriteLine("File Json non trovato..");
    }
    string contenutiJson = File.ReadAllText(path);
    List<string> prodotti = JsonConvert.DeserializeObject<List<string>>(contenutiJson);
    return prodotti;
}     
void WriteProduct(string path)
{
    
    string json = JsonConvert.SerializeObject(path, Formatting.Indented);
    File.WriteAllText(path, ".json");
    Console.WriteLine("File json salvato");
}
void DeleteFiles(string path)
{
    foreach (var p in path)
    {
        if (File.Exists(path)) // controllo che il file esista
        {
            File.Delete(path);
            Console.WriteLine("File Eliminato con successo.");
        }
        else
        {
            Console.WriteLine("File non trovato o non esistente.");
        }
    }
}
void ModificaFiles(string path)
{
    Console.Write("Che file vuoi modificare?");

    if (!File.Exists(path))
    {
        Console.WriteLine("File non trovato o non esistente");
    }
    string json = File.ReadAllText(path);
    Product p = JsonConvert.DeserializeObject<Product>(json);
    Console.Write("Quantità:");
    if (int.TryParse(Console.ReadLine(), out int nuovaQuantita))
    {
        p.quantita = nuovaQuantita;
        string jsonModificato = JsonConvert.SerializeObject(p, Formatting.Indented);
        File.WriteAllText(path, jsonModificato);
        Console.WriteLine("File Modificato");
    }
    else
    {
        Console.WriteLine("Input non valido riprova");
    }
}
string ReadString(string prompt)
{
    
    Console.Write(prompt);
    return Console.ReadLine();
}
int ReadInt(string prompt)
{
    Console.Write(prompt);
    int result;
    while (!int.TryParse(Console.ReadLine(), out result))
    {
        Console.Write("Inserisci un numero valido: ");
    }
    return result;
}
bool ReadBool(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt + " (s/n): ");
        string input = Console.ReadLine().ToLower();
        if (input == "s")
        {
            return true;
        }
        else if (input == "n")
        {
            return false;
        }
        else
        {
            Console.WriteLine("Inserisci 's' per si o 'n' per no");
        }
    }
}
void AggiungiProdotto()
{
    var p = new Product();
    p.id = ReadInt("Inserisci l'ID: ");
    p.nome = ReadString("Inserisci il nome: ");
    p.categoria = ReadString("Inserisci la categoria: ");
    p.quantita = ReadInt("Inserisci la quantità: ");
    p.disponibile = ReadBool("È disponibile? (s/n): ");
    p.Posizione.magazzino = ReadString("Inserisci il magazzino: ");
    p.Posizione.scaffale = ReadInt("Inserisci il numero dello scaffale: ");
    // chiediamo all'utente di inserire il nome del prodotto
    Console.WriteLine("Inserisci il nome del prodotto: ");
    //acquisiamo il nome del prodotto
    string nome = Console.ReadLine();
    // chiediamo la quantita
    Console.WriteLine("Inserisci la quantita del prodotto: ");
    int quantita = int.Parse(Console.ReadLine());
    // calcoliamo il nuovo id per il prodotto
    //int nuovoId = CalcolaNuovoId(prodotti);
    //string[] nuovoProdotto = new string[] { nuovoId.ToString() };
    // Aggiungiamo il nuovo prodotto alla lista dei prodotti
    var percorso = Path.Combine(path, p.id + ".json");
    var json = JsonConvert.SerializeObject(p, Formatting.Indented);
    File.WriteAllText(percorso, json);
   
}
void VisualizzaProdottiPerMagazzino()
{
    Console.WriteLine("Che magazzino vuoi visualizzare?");
    string magazzino = Console.ReadLine();
    if (Directory.Exists(path))
    {
        Console.WriteLine("Il magazzino selezionato non esiste");
        return;
    }
    string[] fileDelMagazzino = Path.GetFileName(path);
    if (fileDelMagazzino.Length == 0)
    {
        Console.WriteLine("Nessun prodotto trovato");
        return;
    }
    foreach (var file in fileDelMagazzino)
        {
            string contenutoJson = File.ReadAllText(path);
            List<string> prodotto = JsonConvert.DeserializeObject<List<string>>(contenutoJson);
            Console.WriteLine($"Contenuto di {Path.GetFileName(path)}" + "json");
        }
}
/*void VisualizzaProdottiPerCategoria()
{
    Console.WriteLine("Categoria?");
    string prodCategoria = Console.ReadLine();
    string[] fileCategoria = Path.GetFileName(path);
    foreach (var cat in fileCategoria)
    {

    }
}
*/
while (true)
{
    // menu del programma
    Console.WriteLine("MENU");
    Console.WriteLine("Dimmi se vuoi: \n1)Aggiungere un file \n2)Modificare un file \n3)Eliminare un file specifico \n4)Visualizzare l'elenco dei file, \n5)Visualizza per magazzino  \n6)Visualizza per categoria, \nEsc per uscire");
    string scelta = Console.ReadLine().ToLower();
    if (scelta == "esc")
    {
        
        Console.WriteLine("ok abbiamo finito");
        break;
    }
   
    switch (scelta)
    {
        case "1": AggiungiProdotto(); break;
        case "2": ModificaFiles(path); break;
        case "3": DeleteFiles(path); break;
        case "4": ReadProduct(path); break;
        case "5": VisualizzaProdottiPerMagazzino(); break;  
        //case "6": VisualizzaProdottiPerCategoria();break;  
        default: Console.WriteLine("Scelta non valida"); break;
    }
}
class Product
{
    public int id { get; set; }
    public string nome { get; set; }
    public string categoria { get; set; }
    public int quantita { get; set; }
    public bool disponibile { get; set; }
    public Posizione Posizione { get; set; }
}
class Posizione
{
    public string magazzino { get; set; }
    public int scaffale { get; set; }
}
