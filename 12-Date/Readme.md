# Gestione delle Date
Le date dipendono dalla localizzazione del sistema operativo, quindi è importante considerare il fuso orario e le impostazione locali quando si lavora in c#.

//DateTime è una struttura che rappresenta un instante di tempo 
DateTime giornoDiNascita = new DateTime(1990, 11, 1); // inserita data di nascita
// DateTime accetta tre paramentri:anno, mese, giorno
Console.WriteLine($"Sei nato il {giornoDiNascita}"); // stampa il giorno di nascita

### Conversioni di Date
//DateTime
DateTime giornoDiOggi = DateTime.Today; // Oggi
Console.WriteLine($"oggi è {giornoDiOggi}"); // stampa la data odierna
Console.WriteLine($"Oggi è {giornoDiOggi.ToShortDateString()}"); //Stampa la data odierna in formato breve
Console.WriteLine($"Oggi è {giornoDiOggi.ToLongDateString()}"); //Stampa la data odierna in formato lungo

Console.WriteLine($"Oggi è {giornoDiOggi.ToString("dd/MM/yyyy")} "); // stampa la data odierna in modo personalizzato giorni a due cifre, mesi a due cifre e anno a 4 cifre
Console.WriteLine($"Oggi è {giornoDiOggi.ToString("dddd/MMMM/yy")} ");

//DayOfWeek 
restituisce il giorno della settimana che scegliamo in inglese
Console.WriteLine($"il giorno della settimana è: {giornoDiOggi.DayOfWeek}");
// se lo vogliamo in italiano dobbiamo fare una conversione
Console.writeLine($"il giorno della settimana è: {giornoDiOggi.dddd}");

//possiamo farci restituire l'indice numerico del giorno della settimana
Console.writeLine($"il giorno della settimana è: {(int)giornoDiOggi.DayOfWeek}");

//possiamo farci restituire il giorno dell'anno
Console.writeLine($"il giorno della settimana è: {giornoDiOggi.DayOfYear}");

PARSE

//DateTime.Parse è un metodo che converte una stringa in un oggetto DateTime(tipo quando un utente inserisce una data)
string dateString = "2024-12-31";
DateTime date = DataTime.Parse(dateString);// Converte la stringa in un oggetto DateTime
Console.WriteLine($"Data convertita e. {date}"); // Stampa la data convertita

TRYPARSE

// restituisce true se avviene la conversione altrimenti false
// il risultato della conversione è restituito tramite il parametro out
DataTime parsedDate;
if (DataTime.TryParse("2024, 12, 31", out parsedDate))
{
    Console.writeLine(parsedDate);
}
else
{
    Console.WriteLine("Errore nella conversione della data");
}


### Operazioni con le Date
// possiamo sommare o sottrarre 
DateTime giornoDiDomani = giornoDiOggi.AddDays(1);
Console.WriteLine($"Domani è: {giornoDiDomani}");

DateTime giornoDiIeri = giornoDiOggi.AddDays(-1);
Console.WriteLine($"ieri era: {giornoDiDomani}");

TIMESPAN

// TimeSpan indica un intervallo di tempo
TimeSpan timeSpan = new TimeSpan(5, 3, 5, 10, 0, 0); // 5 giorni, 3 ore, 5 minuti, 10 secondi, 0 millisecondi, 0 microsecondi

o anche 

TimeSpan eta = today - giornoDiNascita;  // Calcola l'eta in giorni
Console.WriteLine($"La tua eta in giorni è: {eta.Days}");


// Passiamo da eta in anni
Console.WriteLine($"Hai {eta.Days / 365} anni"); //stampo l'eta in anni
//"eta" arriva a eta.hours,  eta.minutes,  eta.second, eta.millisecond, eta.ticks
// ticks = decimi di microsecondi

DateTime annoPros = new DateTime(giornoDiOggi.Year + 1, 1, 1); // Prossimo anno
Console.WriteLine($"Mancano {annoPros - giornoDiOggi} giorni a capodanno");// quanti giorni mancano a capodanno

DateTime mesePros = giornoDiOggi.AddMonths(1); // prossimo mese

Console.WriteLine($"mancano {mesePros - giornoDiOggi} giorni al prossimo mese");// stampa i giorni mancanti al prossimo 
mese


COMPARE
//Confornto tra due date

DateTime data1 = DateTime.Today;
DateTime data2 = new DateTime(2024, 12, 31);// scelta data casuale
int result = DateTime.Compare(date1, date2); // confronto tra date 
Console.WriteLine($"Confronto tra date: {result}");