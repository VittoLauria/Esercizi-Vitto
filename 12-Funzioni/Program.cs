/*
List<string> lista = new List<string> {"elemento1", "elemento2", "elemento 3" };
List<string> lista2 = new List<string> { "elemento4", "elemento5", "elemento 6" };
List<string> lista3 = new List<string> { "elemento 7", "elemento 8" };
//uso la funzione unisciListe per unire due liste di stringhe

List<string> UnisciListe(List<string> lista, List<string> lista2, List<string> lista3)
{
    List<string> listaUnita = new List<string>(); // creo una lista vuota ad uso tempoarneo
    listaUnita.AddRange(lista);
    listaUnita.AddRange(lista2);
    listaUnita.AddRange(lista3);
    return listaUnita; // restituisco la lista unita in modo da stamparla
}

List<string> listaUnita = UnisciListe(lista, lista2, lista3);

void StampaLista(List<string> lista)
{
    foreach (var item in lista)
    {
        Console.WriteLine(item);
    }
}
StampaLista(listaUnita);
*/
int Doppio(int n)
{
    return n * 2;// doppio di n
}
int Quadruplo(int n)
{
    return Doppio(n) * 2;// doppio di n * 2
}
int numero = 5;
int risultato = Quadruplo(numero);
Console.WriteLine($"Il quadruplo di {numero} è: {risultato}");