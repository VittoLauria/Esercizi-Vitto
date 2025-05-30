// iniziallizzo un dizionaro per i partecipanti

Dictionary<string, DateTime> partecipanti = new Dictionary<string, DateTime>();


while (true)
{
    // chiedo all'utente di inserire nome e data di nascita
    Console.WriteLine("Ciao,come ti chiami ?");
    string nome = Console.ReadLine();
    if (nome.ToLower() == "fine")
    {
        break;
    }
    Console.WriteLine("Quando sei nato?");
    string data = Console.ReadLine();
    DateTime dataNascita = DateTime.Today;
    bool ok = DateTime.TryParse(data, out dataNascita);

    if (ok)
    {
        partecipanti.Add(nome, dataNascita);
    }
    else
    {
        Console.WriteLine("Data non valida.Riprova!");
    }
}
List<string> maggiorenni = new List<string>();


foreach(var caratteristiche in partecipanti)
{
    int anni = dataNascita.Year - caratteristiche.Value.Year;
    
    if (anni >= 18)
    {
        maggiorenni.Add(caratteristiche.Key);
    }
    if (maggiorenni.Count == 0)
    {
        Console.WriteLine("Nessun partecipante maggiorenne");
    }
    else
    {
        Random rnd = new Random();
        string partEstratto = maggiorenni[rnd.Next(maggiorenni.Count)];
        Console.WriteLine("Il partecipante estratto è:");
        Console.WriteLine("Nome: " + partEstratto);
        Console.WriteLine("Data di nascita: " + partecipanti[partEstratto].ToString("dd/MM/yyyy"));
    }
}
