
var servizio = new LibroService("libri.json");

while (true)
{
    Console.Clear();
    Console.WriteLine("=== App Per imparare le funzioni ===");
    Console.WriteLine("1. Esempio funzione void");
    Console.WriteLine("2. Esempio funzione con azione");
    Console.WriteLine("3. Esempio funzione con dati complessi");
    Console.WriteLine("0. Esci"); // esce con qualsiasi input che non sia 1 o 2 o 3
    Console.Write("Scegli un opzione");
    // acquisico l'input dell'utente
    string op = Console.ReadLine()?.Trim();
    // oppure acquisico direttamente l'input dell'utente pulito da spazi in eccesso facenco string op = Console.ReadLine()?.ToTrim();
    // con il ? evito il warning del dato che potrebbe essere null

    if (op == "1")
    {
        StampaSaluto();
    }
    else if (op == "2")
    {
        EseguiSomma();
    }
    else if (op == "3")
    {
        EseguiDatiComplessi(servizio);
    }
    else
    {
        break;
    }
}
static void StampaSaluto()
{
    Console.WriteLine("Ciao");
     Console.WriteLine("Premi un tasto...");
    Console.ReadKey();
}
static void EseguiSomma()
{
    Console.Write("primo numero?\n");
    int a = int.Parse(Console.ReadLine());
    Console.WriteLine("secondo numero?");
    int b = int.Parse(Console.ReadLine());
    Console.WriteLine($"Risultato: {a + b}");
    Console.WriteLine("Premi un tasto...");
    Console.ReadKey();
}
// funzione che si occupa di caricare i vari servizi
static void EseguiDatiComplessi(LibroService servizio)
{
    Console.Clear();
    Console.WriteLine("--- Libri da JSON ---");
    try
    {
        // carico l'elenco dei libri
        var elenco = servizio.CaricaLibri();
        // applico il filtro sui libri letti
        var letti = servizio.FiltraLibriLetti(elenco);
        // calcolo il numero di libri gia letti
        int numLetti = letti.Count;
        // calcolo il numero dei libri da leggere
        int numNonLetti = elenco.Count - numLetti;
        // calcolo il totale dei libri
        int totale = Somma(numLetti, numNonLetti);

        //stampo i libri gia letti
        Console.WriteLine("Libri gia letti:");
        foreach (var libro in letti)
        {
            Console.WriteLine($"Libri letti: {libro.Titolo} - {libro.AnnoPubblicazione} - ({libro.Genere})");
        }
        // stampo il totale dei libri letti e non letti
        Console.WriteLine($"Totale libri: {totale} (Letti: {numLetti}, Non Letti: {numNonLetti})");
    }
    // eccezione generica
    catch (Exception ex)
    {
        Console.WriteLine($"Errore: {ex.Message}");
    }
    Console.WriteLine("Premi un tasto...");
    Console.ReadKey();

    static int Somma(int x, int y)
    {
        return x + y;
    }
}