# TIPI DI DATI

```csharp
v// Tipi di dati
// i tipi di dati possono essre dati semplici o complessi (strutture di dati)

int eta2; // dichiarazione di una variabile di tipo interoariabili di
eta2 = 20; // inizializzazione di una variabile di tipo intero

// variabili di tipo intero
int eta = 10; // dichiarazione e inizializzazione di una variabile di tipo intero

// variabile di tipo stringa (devo specificare il valore tra gli apici doppi)
string numero = "5" // dichiarazione e inizializzazione di una variabile di tipo stringa

// variabili di tipo char (devo specificare il valore tra gli apici singoli)
char lettera = 'a'; // dichiarazione e inizializzazione di una variabile di tipo char

// variabili di tipo float (devo separare gli interi dai decimali con il punto)
float pi = 3.14f; // dichiarazione e inizializzazione di una variabile di tipo float
double pi2 = 3.14; // dichiarazione e inizializzazione di una variabile di tipo double
// la differenza tra float e double è la precisione
// float ha una precisione di 7 cifre decimali
// double ha una precisione di 15 cifre decimali

// variabili di tipo booleano (con due stati true o false)
bool maggiorenne = true; // dichiarazione e inizializzazione di una variabile di tipo booleano

// variabile var
// var e una parola chiave che permette di dichiarare una variabile senza specificare il tipo
// il tipo viene dedotto dal valore assegnato
var eta3 = 20; // dichiarazione e inizializzazione di una variabile di tipo intero
var nome = "Nome della persona"; // dichiarazione e inizializzazione di una variabile di tipo stringa
// non posso dichiararla sanza inizializzarla:
var eta4; // errore
// var pero necessita di essere inizializzata al momento della dichiarazione

// variabili di tipo data
DateTime dataNascita = new DateTime(2000, 1, 1); // dichiarazione e inizializzazione di una variabile di tipo data
// new è una parola chiave che permette di creare un oggetto (costruttore) 

// esempio di utilizzo di una variabile attraverso i metodi di console
Console.WriteLine($"La variabile maggiorenne vale: {maggiorenne}"); // stampa il valore della variabile maggiorenne
Console.Writeline($"La variabile nome vale: {nome}"); // stampa il valore della variabile nome
```