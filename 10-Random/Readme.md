### Random
La classe random di c# si occupa di generare numeri casuali.
genera numeri in un intervallo semiaperto cioe: se voglio generare i numeri tra 1 e 100 dovrò scrivere 1 e 101.
```csharp
Random numeroRandom = new Random(); // creo un oggetto random
int numero = numeroRandom.Next(1, 101); // genero un numero casuale da 1 a 100
Console.WriteLine(numero); // stampo il numero
```
se invece specifico un solo argomento, il numero generato sraà compreso tra 0 e il numero specificato
```csharp
int numero2 = numeroRandom.Next(100); // genero un numero casualmente tra 0 e 99
Console.WriteLine(numero2); // stampo il numero
```
se voglio generare un numero casuale compreso tra 0 e 1(esclsuo) posso usare il metodo NextDouble

double numero3 = numeroRandom.NextDouble(); // genero un numero casual tra 0 e 1 inteso come 0,00001
Console.WriteLine(numero3); // stampo il numero

## Esercizio 1 
scrivere un programma che genera 10 numeri casuali compresi tra 1 e 100 e stampa solo i numeri divisibili per 3 o 5 

## esercizio 2 
scrivere un programma che genera 10 numeri casuali compresi tra 1 e 100 e memorizza in una lista solo i numeri pari e stampa la lsita

## esercizio 3
scrivere un programma che simuli il lancio di due dadi e calcoli la somma dei due numeri