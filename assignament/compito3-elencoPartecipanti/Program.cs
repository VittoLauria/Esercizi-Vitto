/*
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
    Console.WriteLine(elencoPart); 
}

*/

List<string> Squadra1 = new List<string>();
List<string> Squadra2 = new List<string>();
string nome;
int lunghezza;

while (true)
{
    Console.WriteLine("Inserisci il nome del partecipante");
    nome = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(nome))
   {
    Console.WriteLine("nullo");
    continue;
   }

   nome = nome.Trim();
   
    if (nome == "fine")

    {
        break;
    }

    Console.WriteLine("A quale squadra vuoi aggiungere il partecipante? (1 o 2)");
    string scelta = Console.ReadLine();

   if (string.IsNullOrWhiteSpace(scelta));
    {
        Console.WriteLine("Scelta non valida,Riprova!");
    continue;
   } 
   
    if (scelta == "1")
    {
        Squadra1.Add(nome);
    }
    else if (scelta == "2")
    {
        Squadra2.Add(nome);
    }

    if (nome.ToLower() == "fine")
    {
        
        break;
    }
    
}


Console.WriteLine("Partecipanti Squadra 1:");
foreach (string partecipante in Squadra1)
{
    Console.WriteLine(partecipante);
}

Console.WriteLine("Partecipanti Squadra 2:");
foreach (string partecipante in Squadra2)
{
    Console.WriteLine(partecipante);
}






