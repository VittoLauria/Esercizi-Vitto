List<string> squadra1 = new List<string>();
List<string> squadra2 = new List<string>();
while (true)
{
    Console.WriteLine("Come ti chiami 'fine' per uscire");

    string nome = Console.ReadLine();
    if (nome.ToLower() == "fine")
    {
        break;
    }

    Console.WriteLine("In che squadra vuoi giocare?");
    string scelta = Console.ReadLine();

    if (scelta == "squadra1" || scelta == "1")
    {
        Console.WriteLine("aggiunto alla squadra1");
        squadra1.Add(nome);
    }
    else if (scelta == "squadra2" || scelta == "2")
    {
        Console.WriteLine("aggiunto alla squadra2");
        squadra2.Add(nome);
    }
    else
    {
        Console.WriteLine("squadra non valida.Riprova");
    }
}
Console.WriteLine("squadra1:");
foreach (var n in squadra1)
{
    Console.WriteLine(n);
}
Console.WriteLine("squadra2:");
foreach (var n in squadra2)
{
    Console.WriteLine(n);
}