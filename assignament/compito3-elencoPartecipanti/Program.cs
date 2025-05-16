List<string> elencoPart = new List<string>();


while (true)
{
    Console.WriteLine("Inserisci il nome");
    string nome = Console.ReadLine();
    if (nome == "fine")
        break;
    elencoPart.Add(nome);
}

foreach (string part in elencoPart) 
{
    Console.WriteLine(part); 
}










