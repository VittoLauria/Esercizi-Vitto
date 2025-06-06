
// Liste per nomi e età
List<string> nomi = new List<string>();
List<int> eta = new List<int>();

Console.Write("Quante persone vuoi inserire? ");
int n = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    Console.Write($"Inserisci il nome della persona {i + 1}: ");
    string nome = Console.ReadLine();
    nomi.Add(nome);

    Console.Write($"Inserisci l'età di {nome}: ");
    int anni = Convert.ToInt32(Console.ReadLine());
    eta.Add(anni);
}

// Stampa risultati
Console.WriteLine("\nElenco inserito:");
for (int i = 0; i < n; i++)
{
    if (eta[i] >= 18)
    {
        Console.WriteLine($"{nomi[i]} ha {eta[i]} anni ed è maggiorenne.");
    }
    else
    {
        Console.WriteLine($"{nomi[i]} ha {eta[i]} anni ed è minorenne.");
    }
    // Console.WriteLine($"{nomi[i]} ha {eta[i]} anni."); // Stampa originale ora commentata
}



