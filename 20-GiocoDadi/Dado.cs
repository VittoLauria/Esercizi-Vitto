public class Dado
{

    private static readonly Random _random = new Random();
    public int NumeroFacce { get; set; }

    /// <summary>
    /// Classe che rappresenta un dado con un numero variabile di facce
    /// </summary>
    /// <param name="numeroFacce">
    /// Il numero di facce del dado. deve essere un numero intero positivo
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Viene lanciata se il numero di facce e minore di 4 o maggiore di 20.
    /// </exception>
    /// <example>
    /// Esempio di utilizzo:
    /// <code>
    /// int x = 8; // numero facce del dado
    /// Dado dado = new Dado(x);
    /// </code>
    /// </example>
    public Dado(int numeroFacce = 6)
    {
        if (numeroFacce < 4 || numeroFacce > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(numeroFacce), "Il numero di facce deve essere compreso tra 4 e 20.");
        }
        NumeroFacce = numeroFacce;
    }
    /// <summary>
    /// Lancia il dado e restituisce un valore casuale tra 1 e numeroFacce (inclusi)
    /// </summary>
    /// <returns>
    /// Ritorna il risultato del lancio
    /// </returns>
    /// <example>
    /// Esempio di utilizzo:
    /// <code>
    /// int risultato = dado.Lancia();
    /// </code>
    /// </example>

    public int Lancia()
    {

        return _random.Next(1, NumeroFacce + 1);
    }
    public override string ToString()
    {
        return $"Lanciato Dado a {NumeroFacce} facce: ";
    }

    public List<int> LanciaMultiplo(int numeroLanci = 5)
    {
        List<int> risultati = new List<int>();
        // ciclo per il numero di lanci specificato
        for (int i = 0; i < numeroLanci; i++)
        {
            risultati.Add(_random.Next(1, NumeroFacce + 1));
        }
        return risultati;
    }
    ///<summary>
    /// Rialcnia i dadi specificati da indici in una lista di risultati precedenti
    /// </summary>
    /// <param name="risultatiPrecedenti"></param>
    /// <param name="indiciDaRilanciare"></param>
    /// <example>
    /// Esempio di utilizzo:
    /// <code>
    /// var risultati = dado.LanciaMultiplo();
    /// var indiciDaRilanciare = new List<int> { 0, 2, 4 };
    /// var risultatiRilanciati = dado.Rilancia(risultati, indiciDaRilanciare);
    /// </code>
    /// </example>
    public List<int> Rilancia(List<int> risultatiPrecedenti, IEnumerable<int> indiciDaRilanciare)
    {

        var risultati = risultatiPrecedenti.ToList();

        foreach (var idx in indiciDaRilanciare)
        {

            if (idx < 0 || idx >= risultati.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(indiciDaRilanciare), $"Indice {idx} fuori dall'intervallo.");
            }

            risultati[idx] = Lancia();
        }
        return risultati;
    }
    public Dictionary<int, int> StatisticheLanci(int numeroLanci = 500)
    {
        // CREO UN DIZIONARIO IN MODO DA MEMORIZZARE I RISULTATI
        // la chiave e il numero e il valore e il numero di volte che e uscito quel numero
        var counts = new Dictionary<int, int>();

        // ciclo per il numero di elementi che espone ogni dado (facce)
        for (int faccia = 1; faccia <= NumeroFacce; faccia++)
        {
            // inizializzo il conteggio per ogni faccia da 0
            counts[faccia] = 0;
        }

        // lancio il dado per il numero di volte specificat
        for (int i = 0; i < numeroLanci; i++)
        {
            // creo una variabile per il risultato
            int risultato = Lancia();
            // incremento il conteggio per il numero uscito
            counts[risultato]++;
        }
        return counts;
    }
}