# METODI ARRAY
I metodi prinicpali per manipolare gli array sono:
- Lenght
- Copy
- Clear
- Reverse
- Sort
- IndexOf
 ```csharp
// definizione di un array di interi
int[] numeri = { 11, 12, 3, 41, 5 };
```
## Acceder ad un elemnto dell'array
```csharp
Console.Writeline(numeri[0]); // stampa il primo numero dell'array 11
```
se provo ad accedere un elemento che non esiste, il programma darà un'errore di runtime. (un eccezione non gestita)

## Lunghezza array
```csharp
Console.WriteLine(numeri.Lenght);
```

## Copiare un array
```csharp
int [] numeri2 = new int[numeri.Lenght]; // devo dichiarare l'array di destinazione con la stessa lunghezza di quello di origine
Array.Copy(numeri, numeri2, numeri.Lenght);
// oppure 
numeri.CopyTo(numeri2, 0); // copio in numeri2 il contenuto di numeri dal primo elemento
// Join unisce gli elementi di un array in una stirnga separati da una virgola
Console.WriteLine(string.Join(", ", numeri2)); // stampa 11, 12, 3, 41, 5
```
## Cancellare un array
```csharp
Array.Clear(numeri2, 0, numeri2.Lenght); // resetta i valori partendo dall'indice 0 fino alla fine
Console.WriteLine(string.Join(", ", numeri2)); // stampa 0, 0, 0, 0, 0
// oppure
numeri2 = new int[0]; // cancella l'array
Console.WriteLine(string.Join(", ", numeri2));
```

## Ordinare un Array
```csharp
Array.Sort(numeri); // sort ordina l'array in ordine crescente
Console.WriteLine(string.Join(", ", numeri2)); // stampa 3, 5, 11, 12, 41
```
## Invertire un array
```csharp
Array.Reverse(numeri2); // reverse inverte l array
Cosnole.WriteLine(string.Join(", ", numeri2)); // stampa 41, 12, 11, 5, 3
```

## IndexOf 
```csharp
int index = Array.IndexOf(numeri2, 12); //  restituisce un elemento dell'array
Console.WriteLine(index); // stampa 1 , in caso ci ofssero piu elementi uguali restituisce l'indice del primo se invece non ci sono restituisce -1
```


