# TIPI DI DATI

```csharp
v// Tipi di dati 
// i tipi di dati possono essre dati semplici o complessi (strutture di dati)
// I semplici:
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

// Tipi di dati complessi (strutture di dati)
//insieme di dati dello stesso tipo

// array -> ha la caratteristcia di avere una lunghezza fissa e predeterminata

int[] numeri = new int[5]; // dichiarazione di un array di interi di lunghezza 5
numeri[0] = 1; //inizializzazione del primo elemento dell'array [0] è l'indice dell'array e parte sempre da 0
numeri[1] = "6";
numeri[2] = 35;
numeri[3] = 40;
numeri[4] = 5;
//oppure posso dichiarare e inizilizzare l'array in un un'unica riga
int[] numeri2 = new int[] { 1, 6, 35, 40, 5 }; //dichiarazione e inizializzazione di un array di interi

//array di stringhe
string[] nomi = new string[5]; //dichiarazione di un'array di strinhe lunghezza 5
nomi[0]; = "partecipante 1"; //inizializzazione del primo elemento dell'array
nomi[1]; = "partecipante 2";
nomi[2]; = "partecipante 3";
nomi[3]; = "partecipante 4";
nomi[4]; = "partecipante 5";
// oppure posso dichiarare e inizializzare l'array in un'unica 
string[] nomi2 = new string[] { "partecipante 1", "partecipante 2", "partecipante 3", "partecipante 4", "partecipante 5" };

//list
//una lista è una collezioni di oggetti dello stesso tipo
//ha la caratteristica di avere una lunghezza variabile
List<int> numeri3 = new List<int>(); //dichiarazione di una lista di interi
numeri3.Add(1); //aggiunta di un elemento alla lista
numeri3.Add(6); //aggiunta di un elemento alla lista
numeri3.Add(35);//aggiunta di un elemento alla lista
nuemri3:Add(40);//aggiunta di un elemento alla lista
numeri3.Add(5);//aggiunta di un elemento alla lista
// oppure posso dichiarare e inizializzare la lista in un'unica 
List<int> numeri4 = new List<int>() { 1, 6, 35, 40, 5 };// dichiarazione e inizializzazione di una lista di numeri
 // lista di stringhe
List<string> nomi3 = new List<string>();
nomi3.Add("partecipante 1");
nomi3.Add("Partecipante 2");
nomi3.Add("Parteicipante 3");
nomi3.Add("Partecipante 4");
nomi3.Add("Partecipante 5");
// oppure posso dichiarare e inizializzare la litsa in un un'unica riga
List<string> nomi4 = new List<string>() { "Partecipante 1", "Partecipante 2", "Partecipante 3", "PArtecipante 4", "PArtecipante 5",};

//Dizionario = collezione di oggetti dello stesso tipo 
// ha la caratteristica di avere una chiave e un valore
Dictionary<string, int> dizionario = new Dictionary<string, int>();
dizionario.Add("Partecipante 1", 1);
dizionario.Add("Partecipante 2", 6);
dizionario.Add("Partecipante 3", 35);
dizionario.Add("Partecipante 4", 40);
dizionario.Add("Partecipante 5", 5);
// oppure posso dichiarare e inizializzare il dizionario in un'unica riga
Dictionary<string, int> new Dictionary<string, int>()

//dizionario int bool
Dictiionary<int, bool> dizionario 3 = new Dictionary<int, bool>;
