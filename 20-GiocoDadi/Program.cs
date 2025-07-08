class Program
{
    static void Main()
    {
        // creo un oggetto dado con 6 facce
        var d6 = new Dado();
        Console.WriteLine(d6.ToString());
        Console.WriteLine(d6.Lancia());
        // rappresento il dado con il ToString()


        // creo un dado con 20 facce
        var d20 = new Dado(20);
        Console.WriteLine(d20.ToString());
        Console.WriteLine(d20.Lancia());

        var risultati = d20.LanciaMultiplo();
        Console.WriteLine("Risultati dei lanci multipli: ");
        foreach (var risultato in risultati)
        {
            Console.WriteLine(risultato);
        }

        var risultatiPersonalizzati = d20.LanciaMultiplo(3);
        Console.WriteLine("Risultati lanci multipli personalizzati: ");
        foreach (var risultato in risultati)
        {
            Console.WriteLine(risultato);
        }
        var risultatid6 = d6.LanciaMultiplo();
        Console.WriteLine("Risultati dei lanci multipli: ");
        foreach (var risultato in risultatid6)
        {
            Console.WriteLine(risultato);
        }
        var risultati5Dadi = d6.LanciaMultiplo();
        Console.WriteLine("Risultati dei 5 dadi lanciati: ");
        foreach (var risultato in risultati5Dadi)
        {
            Console.WriteLine(risultato);
        }
        var indiciDaRilanciare = new List<int> { 0, 2, 4 };
        var risultatiRilanciati = d6.Rilancia(risultati5Dadi, indiciDaRilanciare);
        Console.WriteLine("Risultati dopo il rilancio");
        foreach (var risultato in risultatiRilanciati)
        {
            Console.WriteLine(risultato);
        }
        
        var frequenze = d6.StatisticheLanci(1000);
        Console.WriteLine("Statistiche dei lanci:");
        foreach (var kvp in frequenze)
        {
            Console.WriteLine($"Numero {kvp.Key}: {kvp.Value} volte");
        }
    }
}









