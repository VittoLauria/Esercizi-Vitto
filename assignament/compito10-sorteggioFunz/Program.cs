// dizionario globale con i partecipanti (nome, data di nascita)
Dictionary<string, DateTime> partecipanti = RaccogliPartecipanti();
// Lista globale per i partecipanti idonei
List<string> idonei = FiltraIdonei(partecipanti);
// chiamata alla funzione che sorteggia un parteciapnte idoneo
SorteggioPartecipanti(idonei);

// funzione che raccoglie i partecipanti senza nessun parametro
Dictionary<string, DateTime> RaccogliPartecipanti()
{
    Dictionary<string, DateTime> partecipanti = new();
    while (true)
    {
        //gestione del nome
        Console.WriteLine("Nome o 'fine' per uscire");
        string nome = Console.ReadLine();
        // gestione data di nascita
        if (nome.ToLower() == "fine")
        {
            break;
        }
        // gestione della data
        Console.WriteLine("Data di nascita (es. 01/01/2000): ");
        string inputData = Console.ReadLine();
        // parse della data per convertire da string a DataTime
        DateTime data;
        if (!DateTime.TryParse(inputData, out data))
        {
            Console.WriteLine("Data non valida");
            continue;
        }
        // aggiunta del partecipante al dizionario
        partecipanti[nome] = data;
    }
    return partecipanti;
}

// funzione che filtra i parametri idonei con parametro (dict e partecipanti) da filtrare in una lista
List<string> FiltraIdonei(Dictionary<string, DateTime> partecipanti)
{
    List<string> idonei = new();
    // gestire la data odierna
    DateTime oggi = DateTime.Today;
    // ciclo per filtrare i partecpanti idonei
    foreach (var p in partecipanti)
    {
        int eta = oggi.Year - p.Value.Year;
        // se l'eta e maggiore a 21 aggiugno il partecipante
        if (eta >= 21)
        {
            // aggiunta partecipanti alla lista
            idonei.Add(p.Key);
        }
    }

    return idonei;
}
// funzione che sorteggia un partecipante idoneo con parametro Lista di idonei e nessun return dato che stamperà il partecipante
void SorteggioPartecipanti(List<string> idonei)
{
    // gestire il caso in cui non ci siano partecipanti idonei
    if (idonei.Count > 0)
    {
        // voglio generare un indice casule per sorteggiare un partecipante idoneo
        Random rnd = new();
        // sorteggio un partecipante idoneo
        string scelto = idonei[rnd.Next(idonei.Count)];
        // stampare il nome del partecièante sorteggiato
        Console.WriteLine("partecipante scelto:" + scelto);
    }
    else
    {
        Console.WriteLine("Nessun partecipante idoneo trovato");
    }
}