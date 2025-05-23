 Metodi Lista
i metodi per manipolare le liste sono:

- Count -> con gli array non esiste perchè è lenght
- Add -> con gli array non esiste si usa solo l'operatore di assegnazione += [i]
- AddRange
- Clear
- Contains
- IndexOf
- Remove
- RemoveAt
- Sort
- ToArray
- TrimExcess

## Add
Il metodo add permette di aggiungere un numero di elementi alla lista.
// creiamo una lista di interi vuota 
```csharp
List<int> numeri = new List<int>();
//aggiunta di 10 nuemeri alla lista
for (int i = 0; i <10; i++)
{
    numeri.Add(i);
}
//creazione di una lista gia piena
List<int> numeri2 = newList<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
```
## Count
Il metodo count permette di restituire il numero di elementi di una lista
```csharp
numeri.Count // stampa 10
// oppure
Console.WriteLine(numeri.Count);

## AddRange
Il metodo AddRange permette di aggiungere piu elementi alla lista in un colpo solo.
```csharp
numeri.AddRange(new int[] {11, 12, 13, 14, 15 });
Console.WriteLine(numeri.Count); // stampa 15 

permette anche di aggiungere un altra lista

numeri.AddRange(numeri2);
Console.WriteLine(numeri.Count); // stampa 25
```
## Contains
Il metodo Contains permette di verificare se un elemento è presente nella lista.
```csharp
Console.WriteLine(numeri.Contains(5)); // true
Console.WriteLine(numeri.Contains(30)); // false
```
## IndexOf
Il metodo IndexOf permette di trovare l indice di un elemento nella lista()
```csharp
Console.WriteLine(numeri.IndexOf(5)); // 4 posizione del 5 all' interno della lista
Console.WriteLine(numeri.IndexOf(30)); // -1
```
## Sort
Il metodo sort ordina gli elementi della lista in ordine crescente
```csharp
numeri.Sort();
Console.WriteLine(numeri[0]); // 1 parte dal primo
Console.WriteLine(numeri[numeri.Count - 1]); // 25 parte dall'ultimo
```
## Remove
Il metodo remove permette di rimuovere un elemento dalla lista (restituisce un booleano).
```csharp
Console.WriteLine(numeri.Remove(5)); // true ovvero leva il 5
Console.WriteLine(numeri.Remove(30)); // false non ce quindi non leva niente
Console.WriteLine(numeri.Count); // 24
```
## RemoveAt
Il metodo removeAt rimuove un elemento dalla lista in base all'indice
```csharp
numeri.RemoveAt(0); // rimuove il primo elemento ovvero 1
Console.WriteLine(numeri[0]); // 2 perche alla posizione 0 ora ce il 2
Console.WriteLine(numeri.Count); // 23 
```
## TrimExcess
Il metodo TrimExcess permette di ridurre la capacita della lista 

```csharp
numeri.TrimExcess();
Console.writeLine(numeri.Capacity); // 23
```
## ToArray
Il metodo ToArray permetti di convertire la lista in un array

```csharp
int[] arrayNumeri = numeri.ToArray();
Console.WriteLine(arrayNumeri.Lenght); // 23
```

## Clear
Il metodo Clear permette di rimuovere tutti gli elementi dalla lista
```csharp
numeri.Clear();
Console.WriteLine(numeri.Count); // 0
```