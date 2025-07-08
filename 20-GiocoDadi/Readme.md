# GIOCO DADI

Il programma usa una classe dado all'interno della logica di gioco.
- Il dado ha un metodo lancia che restituisce un numero casuale tra 1 e il numero di facce del dado.
Incominciamo definenado la classe dado (con un numero variabile di facce)
```csharp
public class Dado
{
    // creo un campo privato per il numero di facce di dado
    // private è il modifcatore d'accesso che rende il campo visibile solo alla classe
    // static indica che il campo è condiviso tra tutte le istanze della classe
    // readonly indica che il campo puo essere inizializzato dl costruttore della classe e non puo essere modificato dopo la creazione
    private static readonly Random _random = new Random();
    // creo un campo pubblico per il numero delle facce del dado
    public int NumeroFacce { get; set; }

    // creo la documentazione della classe

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

    // costruttore della classe con parametro opzionale per il numero di facce
    // quando creero l'oggetto se omettero il numero delle facce, costruira il dado da 6 facce
    // ES:
    // var d6 = new Dado();
    // var d20 = new Dado(20);
    // var d3 = new Dado(3); quato lancera l'eccezione perche deve essere tra 4 e 20
    public Dado(int numeroFacce = 6)
    {
        if (numeroFacce < 4 || numeroFacce > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(numeroFacce), "Il numero di facce deve essere compreso tra 4 e 20.");
        }
        // assegno il valore del numero di facce al campo NumeroFacce
        NumeroFacce = numeroFacce;
    }

    // Metodo che simula il lancio del dado

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
        // scrivendo _random proteggo lo stato interno della classe in modo che nesuno possa modificarlo 
        // se lo rendessi public chiunque potrebbe fare cose tipo:
        // dado._random = new Random(42);
        // int x = Dado._random.Next(); 
        return _random.Next(1, NumeroFacce + 1);
    }

    // possiamo creare un metodo override 
    // inanzitutto voglio creare un metodo che rappresnti una stampa del numero delle facce
    // quindi deve poter variare comportamneto a seconda dell'oggetto che creo 
    public override string ToString()
    {
        return $"Dado a {NumeroFacce} facce";
    }
    // posso invocare il metodo ToString () su un oggetto Dado per ottenre una stringa che rappresenta il dado
    // esempio:
    // Dado dado = new Dado (6);
    // string messaggio = dado.ToString();
}
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
        
    }
    
}
```

# GIOCO DADI V2
Voglio aggiungere ad un elenco i primi 5 lanci di un dado
-quindi potrei implementare il metodo Lancia in modo che riceva un parametro opzionale che indica il numer di lanci da effettuare e restituisca una lista di risultati
- se il parametro non viene specifaicato. il metodo lancia verra eseguito 5 volte
- il metodo ritorna una lista di interi
```csharp
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
```
La chiamata al metodo sarebbe:
```csharp
dado.LanciaMultiplo(); // lancia il dado 5 volte
```
```csharp
dado.LanciaMultiplo(3); // lancia il dado 10 volte
```
```csharp
List<int> risultati = dado.LanciaMultiplo();
Console.WriteLine("Risultato dei lanci:");
foreach (int risultato in risultati)
{
    Console.WriteLine(risultato);
}
```
# GIOCO DADI V3
Implementiamo un metodo che permette di rilanciare alcuni dati scelti
// metodo che rilancia i dadi specificati
// il metodo prende input una lista di risultati precedenti e una lista di indici da rilanciare
//restituisce una lista di risultati doèpo il rilancio
// possiamo farlo usando gli IEnumerable per permettere di passare qualsisasi tipo di collezzione

public List<int> Rilancia(List<int> risultatiPrecedenti, IEnumerable<int> indiciDaRilanciare)
{
    //se voglio copio la lista per non modificare quella originale
    var risultati = risultatiPrecedenti.ToList();
    // ciclo attraverso gli indici
    foreach(var idx in indiciDaRilanciare)
    {
        // se l'indice è fuori dall'intervallo lancio un'eccezione 
    if (idx < 0 || idx >= risultati.Count)
    {
        throw new ArgumentOutOfRangeException(nameof(indiciDaRilanciare), $"Indice {idx} fuori dall'intervallo.");
    }
        // altrimenti chiama l'eccezione Lancia pero con gli indici da rilanciare
        risultati[idx] = Lancia();
    }
    return risultati;
}

# GIOCO DADI V4
 
 Voglio aggiungere un metodo che lanci il dado un numero predefinito di volte e ritorni ogni numero quante volte è uscito
 il metodo dve ritornare un dizionario che associo ad ogni numero il numero di volte che e uscito
 