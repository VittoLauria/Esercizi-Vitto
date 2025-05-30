
Dictionary<string, DateTime> partecipanti = new Dictionary<string, DateTime>();

while (true)
{
    Console.WriteLine("Inserisci il nome");
    string nome = Console.ReadLine();
    if (nome.ToLower() == "fine")
    {
    break;
    }
    Console.WriteLine("Quando sei nato?");
    string inputData = Console.ReadLine();
    DateTime dataNascita;
    bool ok = DateTime.TryParse(inputData, out dataNascita);
    if (ok)
    {
        partecipanti.Add(nome, dataNascita);
    }
    else
    {
        Console.WriteLine("Data non valida. Riprova");
    }
}   
var maggiorenni = new List<string>();
foreach (var p in partecipanti)
{
    
if (anni >= 18)
    {
    maggiorenni.Add(p.Key);
    }
}
if (maggiorenni.Count == 0)
{

Console.WriteLine("Nessun partecipante maggiorenne!");
}
else
{
    Random rnd = new Random();
    string partEstratto = maggiorenni[rnd.Next(maggiorenni.Count)];
    Console.WriteLine("Il partecipante sorteggiato è");
    Console.WriteLine("Nome: " + partEstratto);
    Console.WriteLine("Data di nascita: " + partecipanti[partEstratto].ToString("dd/MM/yyyy"));
}