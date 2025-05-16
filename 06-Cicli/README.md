# CICLI

I cicli sono una struttura di controllo che permette di eseguire un blocco di codice piu volte, a seconda di una condizione.In Csharp ci sono due tipi principali di cicli: `for` e `while`
Ci sono anche il `foreach` e il `do-while`

## Ciclo `for`
Il ciclo `for` viene utilizato per iterare su una sequenza (come una lista o una stringa) o su un oggetto iterabile. La sintassi è la seguente


### Esempio
```csharp
for (int i = 0; i < 10; i++) // i è una variabile di controllo che parte da 0 e finsice a 10
{
Console.WriteLine(i); // stampa i che è il valore della variabile di controllo
}
```

## Ciclo `while`
Il ciclo `while` viene utilizzato per eseguire un blocco di codice finchè una condizione è vera.

```csharp
while (condizione)
{
    // codice da eseguire
}
```
### Esempio
```csharp
int j = 0; // inizializza la variabile di controllo
while (j < 5) // finche j è minore di 5
{
    Console.Writeline(j);
    j++;
}
```

### esempio while con true
```csharp
while (true) // ciclo infinito
{
    Console.Writeline("Ciclo infinto");
    break; // esce dal ciclo
}
```
```csharp
int k = 4;
while (true) // ciclo infinito
{
    Console.Writeline("Ciclo infinto");
    if k == 5
    {
        break; //esce dal ciclo
    }
    k++;
}  
```
## Ciclo `foreach`
il ciclo `foreach` viene utilizzato per iterare su una collezione o una struttura di dati (come un array o una lista).

```csharp
foreach (tipo variabile in collezione)
{
    //codice da eseguire
}
```
### Esempio

```csharp

string[] nomi = {"partecipante 1", "Partecipante 2", "Partecipante 3" }; // array di stringhe
foreach (string nome in nomi) // per ogni stringa in nomi
{
    Console.WriteLine(nome); //stampa la stringa
}
```

```csharp
string[] nomi = {"partecipante 1", "Partecipante 2", "Partecipante 3" }; // array di stringhe
foreach (string nome in nomi) // per ogni stringa in nomi
{
    // se il nome è uguale a partecipante 1
    if (nome == "Partecipante 2")
    {
        Console.WriteLine("Nome Trovato"); // stampa nome trovato
        break; //esce dal ciclo appena trova il nome
    }
else 
    {
    Console.WriteLine("Nome non trovato"); // stampa nome non trovato
    }
}
```












