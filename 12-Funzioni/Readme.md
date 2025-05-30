### Funzioni
- Una funzione è un bloco di codice che esegue un compito specifico
- Il vantaggio di usare le funzioni è che il codice diventa piu leggibile e ordinato

# Esistono due tipi principali di funzione:
 - Funzioni che elaborano i dati pero non restituiscono un valore (void)
 - Funzioni che invece restituiscoo un valore (return) -> sono definite con un tipo di ritorno es: di stringa, di liste ecc

# Una Funzione è definita da:
- Un tipo di ritorno
- un nome
- Una lista di parametri (opzionale) 
- Un corpo della funzione
- Un valore di ritorno (opzionale)
- Deve essere sempre chiamata alla fine
# Importante
> Una funzione in csharp deve avere un nome scritto in PascalCase
> Una funzione deve svolgere un compito specifico e non deve essere troppo lunga
> Una variabile definita all'interno della funzione è visibile sono all'interno di quella funzione (scope locale).scope = mdove ha valore
> Una funzione puo avere solo un return, ma puo essere chiamato piu volte
# Esempio di funzione void (senza ritorno e senza parametri)
funzione che stampa un messaggio
void StampaMessaggio()
{
    Console.WriteLine("funzione void");
}
StampaMessaggio(); //chiamata della funzione


# Esempio di funzione void (senza ritorno e con parametri)
Funzione che stampa un messaggio con un parametro
void StampaMessaggioConParametro(string messaggio)
{
    Console.WriteLine(messaggio);
}
StampaMessaggioConParametro("funzione void con parametro");

# Esempio di funzione void(senza ritorno ma con piu parametri)

void  StampaMessaggioConPiuParametri(string messagio1, string messaggio2)
{
    Console.WriteLine($"{mesaggio1} {messaggio2}");
}
 StampaMessaggioConPiuParametri("funzione void", "con parametri")


// fuznione void che stampa due parametri diversi
void StampaMessaggioConParametriDiversi(string messaggio, int numero)
{
    Console.WriteLine($"{messaggio} {numero}");
}
StampaMessaggioConParametriDiversi("funzione void con", 2);

# Esempio di funzione void che manipola una lista

List<string> lista = new List<string> {"elemento1", "elemento2", "elemento 3" };
void StampaLista(List<string> lista>)
{
    foreach (var item in lista)
    {
        Console.WriteLine(item);
    }
}
StampaLista(lista);// stampa lista

List<string> lista2 = new List<string> {"elemento4", "elemento5", "elemento 6" };
StampaLista(lista2); // stampa lista 2

# Esempio di due funzione, una che unisce le liste e una che stampa la lista

List<string> lista = new List<string> {"elemento1", "elemento2", "elemento 3" };
List<string> lista2 = new List<string> {"elemento4", "elemento5", "elemento 6" };
//uso la funzione unisciListe per unire due liste di stringhe
List<string> listaUnita = UnisciListe(lista1, lista2);

List<string> UnisciListe(List<string>)
{
    List<string> listaUnita = new List<string>(); // creo una lista vuota ad uso tempoarneo
    listaUnita.AddRange(lista1);
    listaUnita.AddRange(lista2);
    return listaUnita; // restituisco la lista unita in modo da stamparla
}

void StampaLista(List<string> lista)
{
    foreach (var item in lista)
    {
        Console.WriteLine(item);
    }
}
StampaLista(listaUnita);

# Esempio di una funzione che somma due valori e restituisce un risultato
// funzione che somma due numeri
int Somma(int a, int b)
{
    return a + b; // restituisco la somma die numeri
}
// chiamata funzione Somma
int risultato = Somma(5, 10);
Console.Writeline($"La somma di a e b è: {risultato}")

# Esempio di una funzione che restituiscu un booleano
// funzione che verifica se una parola ha es: numero di lettere pari
bool ParolaPari(string parola)
{
    return parola.Length % 2 == 0; // restituisco true se la funzione e pari
}
bool risultatoPari = ParolaPari("cane"); // utilizzo della funzione
Console.WriteLine($"La parola ha un numero di lettere pari? {risultatoPari}");

# Esempio di una funzione che restituisce una stringa

// funzione che restituisce una stringa formattata
string FormattaMessaggio(string nome, int eta)
{
    return ($"Ciao {nome}, hai {eta} anni.");// restituisco una stringa formattata
}
string messaggio = FormattaMessaggio("Utente 1", 30);// passiamo i parametri
Console.WriteLine(messaggio);// stampo il messaggio formattatato

# Esempio di funzione con parametri di out
// funzine che divid edue numeri
void Divisione(int dividendo, int divisore, out int quoziente, out int resto)
{
    quoziente = dividendo / divisore; // calcolo quoziente
    resto = dividendo % divisore;// calcolo resto
}
int quoziente, resto;
Divisione(10, 3, out quoziente, out resto);
Console.WriteLine($"Quoziente: {quoziente}, Resto: {resto}");

# Esempio di funzione che trasmette il valore ad un altra
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

# Esempio di una funzione che usa il parametro REF
il REf paasa il riferimento della variabile, quindi se la variabile viene modificata all'interno della funzione, la modifiica viene riflessa anche all'esterno della funzione.
int DoppioConRef(ref int n)
{
    n *= 2; // raddoppia n
    return n; // restituisce il valore di n
}
int n = 5; // dichiaro una variabile di tipo intero
int doppioConref = DoppioConRef(ref n); // utilizzo della funzione
Console.WriteLine(doppioConRef); // stampa 10
Console.WriteLine(n); // stampa 10 invece di 5 perche n e stata modificata nella funzione