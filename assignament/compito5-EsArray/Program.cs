/*
// definisco un array di interi
int[] numeri = { 8, 12, 20, 16 };
// inizializzo la variable somma a 0
int somma = 0;
// ciclo for per iterare attraverso gli elementi dell'array
for (int i = 0; i < numeri.Length; i++)
{
    // aggiungi ogni elemento alla variabile somma
    somma += numeri[i];
}
// stampa il risultato finale
Console.WriteLine(somma);


// definsici un array di interi
int[] numeri = { 1, 2, 3, 4, 5, 6, 7, 8 };
int somma = 0;
//ciclo for per iterare attraverso gli elementi dell'array
for (int i = 0; i < numeri.Length; i++)
{
    if ( i % 2 == 0)
    {
        Console.WriteLine(i);
        
    }
     
}
// utilizza un istruzione if per controllare se un numero è pari
//stampa il numero se è pari

List<int> newNum = new List<int>();
for (int i = 0; i < numeri.Length; i++)
{
    if ( numeri [i] % 2 == 0)
    {
        newNum.Add(numeri [i]);
    }

}
Console.WriteLine(string.Join(", ", newNum));


// definisci un array di interi
int[] num = { 22, 40, 12, 45 };
// definsici un valore da cercare
int  numeroDaTrovare = 12;
// inizializza una variabile per tenere traccia della posizione trovata
int traccia = -1;

//utilizza un ciclo for pe riterare attravesro gli elementi dell'array
for (int i = 0; i < num.Length; i++)
{
    //coonfronta ogni elemento con il valore cercato
    if (num[i] == numeroDaTrovare)
    {
        traccia = i;
        break;
    }
   

}

// se il ciclo termina senza trovare l'elemento, stampa un messaggio che l'elemento non e stato trovato
if (traccia != -1)
{
    Console.WriteLine($"Il valore {numeroDaTrovare} è stato trovato alla posizione {traccia}");
}
else
{
    Console.WriteLine($"Il valore {numeroDaTrovare} non è stato trovato nell'array.");
}


int [] numeri = { 8, 12, 20, 16 };
int [] numeri2 = new int[numeri.Length];


for (int i = 0; i < numeri.Lenght; i++)
{
    numeri2.CopyTo(numeri2, 0);
    Console.WriteLine(string.Join(", ", numeri2.Length));
}
for (int i = 0; i < numeri2.Length; i++)
{
    Array.Reverse(numeri2);
 Console.WriteLine(string.Join(", ", numeri2));
}
*/

// chide all'utente di inserire un numero di elementi per un array
Console.WriteLine("INserisci la lunghezza dell'Array");
// crea un array della lunghezza specificata dall'utente
int lunghezza = int.Parse(Console.ReadLine());
int[] numeri = new int [lunghezza];
// chiedi all'utente di inserire ciascun elemento
for (int i = 0; i < lunghezza; i++)
{
    Console.WriteLine("Inserisci il numero");
    numeri[i] = int.Parse(Console.ReadLine());
} 



// chiedi all'utente di inserire un numero da cercare nell'array
Console.WriteLine("dimmi un numero che cercheremo all'interno dell'array");
int numDaCercare = int.Parse(Console.ReadLine());

for (int i = 0; i < numeri.Length; i++)
{

    if (numeri[i] == numDaCercare)
    {
        Console.WriteLine("Numero trovato");
        break;
    }
    else
    {
        Console.WriteLine("Non trovato");
    }
}
// scorri gli elementi con un foreach
   

