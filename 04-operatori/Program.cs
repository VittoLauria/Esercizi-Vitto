// Operatori
/*
i tipi di operatori principali sono:
-aritmetici
-di confronto
-logici
di assegnazione
di incremento e decremento
-di concatenazione
*/
//Operatori aritmetici
int a = 22;
int b = 7;

int somma = a + b; //somma
//stampo il risultato
Console.WriteLine($"La somma di {a} e {b} è:{somma}");

int differenza = a - b;
//stampo il risultato
Console.WriteLine($"La differnza di {a} e {b} è; {differenza}");

int prodotto = a * b;
//stampo il risultato
Console.WriteLine($"Il prodotto di {a} e {b} è: {prodotto}");

int quoziente = a / b;
//stampo il risultato
Console.WriteLine($"Il quoziente di {a} e {b} è: {quoziente}");

int resto = a % b;
//stampo il risultato
Console.WriteLine($"Il resto di {a} e {b} è: {resto}");

int modulo = a % 3;
//stampo il risultato
Console.WriteLine($"Il modulo di [a] è: {modulo}");

// Operatori di confronto (restituiscono un booleano)
bool uguale = a == b;
Console.WriteLine($"Il valore di {a} è uguale a {b}: {uguale}");

bool diverso = a != b;
//stampo risultato
Console.WriteLine($"Il valore di {a} è diverso da {b}: {diverso}");

bool maggiore = a > b;
bool minore = a < b;
bool maggioreUguale = a >= b;
bool minoreUguale = a <= b;

//Operatori Logici (or, and, not)

bool condizione1 = true;
bool condizione2 = false;

bool and = condizione1 && condizione2; // and (&&) significa che entrambe le condizione devono devono essere vere
//stampo il risultato
Console.WriteLine($"La condizone {condizione1} e {condizione2} è = {and}");

bool or = condizione1 || condizione2; // or (||) significa che almeno una delle due condizione e vera
// stampo il risultato
Console.WriteLine($"La condizione {condizione1} o {condizione2} è: {or}");

bool not = !condizione1; // not (!) significa che restituisce il contrario dello stato della condizione
// stampo il risultato
Console.WriteLine($"La condizione {condizione1} è: {not}");

// Operatori di assegnazione
int c = 10;

c += 5; // somma e assegna (in questa caso se c = 10 diventa 15)
// stampo il risultato
Console.WriteLine($"Il valore di c è: {c}");

c -= 5; // sottrae e assegna (in questo caso se c = 10 diventa 5)
 // stampo il risultato
 Console.WriteLine($"Il valore di c è: {c}"); 

c *= 5; // moltiplica e assegna (in questo caso se c = 10 diventa 50)
 // stampo il risultato
Console.WriteLine($"Il valore di c è: {c}");

c /= 5; // divide e assegna (in questo caso se c = 25 diventa 5)
 // stampo il risultato
Console.WriteLine($"Il valore di c è: {c}");

// operatore di concatenazione
string nome = "nome persona";   
string cognome = "cognome persona";
string nomecompleto = "il nome completo è: " + nome + " " + cognome + "!";
//stampo il risultato 
Console.WriteLine(nomecompleto);

//concatenazione con string interpolation
string nomecompleto2 = $"il nome completo è: {nome} {cognome}!";
//stampo il risultato
Console.WriteLine(nomecompleto2);







// operatore di incremento
c++; // incremento di un'unita
// stampo il risultato
Console.WriteLine($"Il valore di c è: {c}");

// operatore di decremento 
c--; // decremento di un'unita
Console.WriteLine($"Il valore di c è: {c}");




