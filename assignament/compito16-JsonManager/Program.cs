using Newtonsoft.Json;
string prodotti = @"prodotti.Json";
File.Create(prodotti).Close();
while (true)
{
    Console.WriteLine("dimmi se vuoi: aggiungere, eliminare, modificare o visualizzare un file/esc per uscire");

    string scelta = Console.ReadLine();
    if (scelta == "esc")

    void AggiungiProdotto(List<string[]> prodotti)
    {


        // chiediamo all'utente di inserire il nome del prodotto
        Console.WriteLine("Inserisci il nome del prodotto: ");
        //acquisiamo il nome del prodotto
        string nome = Console.ReadLine();
        // chiediamo all'utente di indìserire il prezzo del prdotto
        Console.WriteLine("Inserisci il quantita del prodotto: ");
        // acquisiamo il prezzo del prodotto
        string quantita = Console.ReadLine();



        // calcoliamo il nuovo id per il prodotto
        int nuovoId = CalcolaNuovoId(prodotti);
        string[] nuovoProdotto = new string[] { nuovoId.ToString(), nome, quantita.ToString() };
        nuovoProdotto[2] = nuovoProdotto[2].Replace(",", ".");
        // Aggiungiamo il nuovo prodotto alla lista dei prodotti
        prodotti.Add(nuovoProdotto);

    }
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

}