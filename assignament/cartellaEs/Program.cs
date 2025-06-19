using Newtonsoft.Json;
List<string> ReadProduct(string path)
{
    if (!File.Exists(path))
    {
        Console.WriteLine("File Json non trovato..");
        return new List<string>();
    }
    string contenutoJson = File.ReadAllText(path);
    List<string> prodotti = JsonConvert.DeserializeObject<List<string>>(contenutoJson);
    return prodotti;
}

string origine = @"c:\Users\devops3\Documents\Esercizi-Vitto\assignament\compito16-JsonManager\prodotti.Json";
List<string> Lacci = ReadProduct(origine);
foreach (string lacciO in Lacci)
{
    Console.Write(lacciO);
}