using Newtonsoft.Json;
string path = @"c:\Users\devops3\Documents\Esercizi-Vitto\assignament\compito16-JsonManager";
void VerificaFolders(string path)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }
int CalcolaNuovoId(List<string[]> prodotti)
    {
        // se non ci sono nuovi prodotti return a 1
        if (prodotti.Count == 0)
        {
            return 1;
        }
        // altrimente prendo l'ultimo prodotto e restituisco il suo id + 1
        string[] ultimoProdotto = prodotti[prodotti.Count - 1];
        int ultimoId = int.Parse(ultimoProdotto[0]);
        return ultimoId + 1;
    }
List<string> ListFiles(List<string> path)
{
    if (!Directory.Exists(path))
    {
        string[] files = Directory.GetFiles(path);
        foreach (var file in files)
        {
            Console.WriteLine(path.GetFilesName(files));
        }
    }
    else
    {
        Console.WriteLine("La cartella non esiste");
    }
}
List<string> ReadProduct(string path)
{
    if (!File.Exists(path))
    {
        Console.WriteLine("File Json non trovato..");
    }
    string contenutoJson = File.ReadAllText(path);
    List<string> prodotti = JsonConvert.DeserializeObject<List<string>>(contenutoJson);
    return prodotti;
}
void WriteProduct(string path)
{
    string json = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
    File.WriteAllText(path, json);
   Console.WriteLine("File json salvato");
}
void DeleteFile(string path)
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
void ModificaFiles(string path)
    {
       
        if (!File.Exists(path))
        {
            Console.WriteLine("File non trovato o non esistente");
            return;
        }
        string json = File.ReadAllText(path);
        Product p = JsonConvert.DeserializeObject<Product>(json);
        Console.Write("Quantità:");

    }
string ReadString(string prompt)
{
    Console.Write(prompt);
    return Console.ReadLine();
}
int ReadInt (string prompt)
{
    int valore;
    while (true)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine();
        if (int.TryParse(input, out valore))
        {
            return valore;
        }
        else
        {
            Console.WriteLine("Inserisci un numero valido");
        }
    }
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
void AggiungiProdotto(List<string[]> prodotti)
{
        // chiediamo all'utente di inserire il nome del prodotto
        Console.WriteLine("Inserisci il nome del prodotto: ");
        //acquisiamo il nome del prodotto
        string nome = Console.ReadLine();
        // chiediamo la quantita
        Console.WriteLine("Inserisci la quantita del prodotto: ");
        int quantita = int.Parse(Console.ReadLine());
        // calcoliamo il nuovo id per il prodotto
         int nuovoId = CalcolaNuovoId(prodotti);
        string[] nuovoProdotto = new string[] { nuovoId.ToString()};
        // Aggiungiamo il nuovo prodotto alla lista dei prodotti
        prodotti.Add(nuovoProdotto);

}

while (true)
{
    Console.WriteLine("MENU");
    Console.WriteLine("/nDimmi se vuoi: 1)aggiungere, 2)modificare, 3)eliminare o 4)visualizzare un file/n esc per uscire");

    string scelta = Console.ReadLine();
    if (scelta == "esc")
    {
        Console.WriteLine("ok abbiamo finito");
        break;
    }
    switch (scelta)
    {
        case "1": AggiungiProdotto(path); break;
        case "2": ModificaFiles(path); break;
        case "3": DeleteFiles(path); break;
        case "4": ReadProduct(path); break;
        default: Console.WriteLine("Scelta non valida"); break;
    }
}
class Product
{
    public string id { get; set; }
    public string nome { get; set; }
    public List<string> categoria { get; set; }
    public int quantita { get; set; }
    public bool disponibile { get; set; }
    public Posizione Posizione { get; set; }
}
class Posizione
{
    public string magazzino { get; set; }
    public int scaffale { get; set; }
}
