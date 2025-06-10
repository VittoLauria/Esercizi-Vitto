using System.Globalization;
CultureInfo.CurrentCulture = new CultureInfo("it-IT");

string percorso = "prodotti.csv";
// Legge i prodotti dal csv
List<string[]> prodotti = LeggiProdotti(percorso);
// mostra i prodotti esistenti
MostraProdotti(prodotti);
// Aggiungi un nuovo prodotto
string risposta = "s"; // inizializza con s per entare nel ciclo
while (risposta == "s" || risposta == "si")
{
    AggiungiProdotto(prodotti);
    Console.WriteLine("\nVuoi inserire un nuovo prodotto? (s/n): ");
    risposta = Console.ReadLine().Trim().ToLower();

}
    // Scrivi iprodotti su file csv
 ScriviProdotti(percorso, prodotti);

// La funzione leggiprodotti, legge i prodotti dal csv che specifichiamo come argomento (percorso) e restituisce una lista
List<string[]> LeggiProdotti(string file)
{
    // creo una lista di stringhe per conteneri i prodotti
    List<string[]> lista = new();
    //verifico che il file esista
    if (File.Exists(file))
    {
        // leggo il file riga per riga
        string[] righe = File.ReadAllLines(file);
        // ciclo le righe
        for (int i = 1; i < righe.Length; i++)
        {
            // separo i valori della riga (dove ce la virgola) usando il metodo Split
            string[] campi = righe[i].Split(',');
            // aggiungo i campi alla lista
            lista.Add(campi);
        }
    }
    return lista;
}
// aggiungo un prodotto alla lsita dei prodotti
// Uso la funzione CalcolaNuovoId per trovare il nuovo id da assegnare al nuvo prodotto
void AggiungiProdotto(List<string[]> prodotti)
{

    
        // chiediamo all'utente di inserire il nome del prodotto
        Console.WriteLine("Inserisci il nome del prodotto: ");
        //acquisiamo il nome del prodotto
        string nome = Console.ReadLine();
        // chiediamo all'utente di indìserire il prezzo del prdotto
        Console.WriteLine("Inserisci il prezzo del prodotto: ");
        // acquisiamo il prezzo del prodotto
        string prezzoInput = Console.ReadLine();
    
    
    // convertiamo il prezzo in un numero decimale
    double prezzo;
    while (!double.TryParse(prezzoInput, out prezzo))
    {
        // se la conversione falliscie richiedere
        Console.WriteLine("prezzo non valido riprova");
        prezzoInput = Console.ReadLine();
        // creiamo un array di stringhe per il nuovo prodotto
    }
    // calcoliamo il nuovo id per il prodotto
    int nuovoId = CalcolaNuovoId(prodotti);
    string[] nuovoProdotto = new string[] { nuovoId.ToString(), nome, prezzo.ToString("F2") }; // F2 serve per formattare il prezzo con due decimali
    nuovoProdotto[2] = nuovoProdotto[2].Replace(",", ".");
    // Aggiungiamo il nuovo prodotto alla lista dei prodotti
    prodotti.Add(nuovoProdotto);

}
// La funzione MostraProdotti mostra i prodotti esisitenti e ci serve per ciclare i prodotti e stamparli a video(void)
void MostraProdotti(List<string[]> prodotti)
{
    // se non ci sono prodotti stampiano un messaggio
    if (prodotti.Count == 0)
    {
        Console.WriteLine("Non ci sono prodotti disponibili");
        return;
    }
    // altrimenti stampiamo i prodotti
    Console.WriteLine("Prodotti disponibili:");
    foreach (var prodotto in prodotti)
    {
        //stampo il prodotto con il suo id, nome,prezzo
        Console.WriteLine($"Id: {prodotto[0]}, Nome: {prodotto[1]}, Prezzo: {prodotto[2]}");
    }
}

// la funzione CalcolaNuovoId trova qual'è il nuovo id da asseganare al nuovo prodotto

int CalcolaNuovoId(List<string[]> prodotti)
{
    // se non ci sono nuovi prodotti return a 1
    if (prodotti.Count == 0)
    {
        return 1;
    }
    // altrimente prendo l'ultimo prodotto e restituisco il suo id + 1
    string[] ultimoProdotto = prodotti[prodotti.Count - 1];
    int ultimoId = int.Parse(ultimoProdotto[0]);
    return ultimoId + 1;
}

// la funzione ScriviProdotti salva i prodotti in un File CSV

void ScriviProdotti(string file, List<string[]> prodotti)
{
    // scrivo l'intestazione del file CSV
    List<string> righe = new() { "Id,nome,prezzo" };
    // ciclo i prodotti  li aggiungo
    foreach (var prodotto in prodotti)
    {
        //creo la riga del prodotto il metodo Join per uniri i campi con la virgola
        string riga = string.Join(",", prodotto);
        //aggiungo la riga 
        righe.Add(riga);
    }
    // scrivo il contenuto sul file CSV
    File.WriteAllLines(file, righe);
}