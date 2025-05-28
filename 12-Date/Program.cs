
/*
DateTime giornoDiNascita = new DateTime(1990, 11, 1); // inserita data di nascita
// DateTime accetta tre paramentri:anno, mese, giorno
Console.WriteLine($"Sei nato il {giornoDiNascita}"); // stampa il giorno di nascita



DateTime giornoDiOggi = DateTime.Today;

Console.WriteLine($"oggi è {giornoDiOggi}"); // stampa la data odierna
Console.WriteLine($"Oggi è {giornoDiOggi.ToShortDateString()}"); //Stampa la data odierna in formato breve
Console.WriteLine($"Oggi è {giornoDiOggi.ToLongDateString()}"); //Stampa la data odierna in formato lungo
Console.WriteLine($"Oggi è {giornoDiOggi.ToString("dd/MMM/yyyy")} ");
Console.WriteLine($"il giorno della settimana è: {giornoDiOggi.DayOfWeek}");
Console.WriteLine($"il giorno della settimana è: {giornoDiOggi:dddd}");
Console.WriteLine($"il giorno della settimana è: {(int)giornoDiOggi.DayOfWeek}");

DateTime giornoDiDomani = giornoDiOggi.AddDays(1);
Console.WriteLine($"Domani è: {giornoDiDomani}");

DateTime giornoDiIeri = giornoDiOggi.AddDays(-1);
Console.WriteLine($"ieri era: {giornoDiDomani}");

// in formato stringa 

Console.wrieLine($"Domani è: {giornoDiDomani:dddd}")


TimeSpan eta = giornoDiOggi - giornoDiNascita
Console.WriteLine($"Hai {eta.Days / 365} anni"); //stampo l'eta in anni
*/
DateTime data1 = DateTime.Today;
DateTime data2 = new DateTime(2024, 12, 31); // scelta data casuale
int result = DateTime.Compare(data1, data1); // confronto tra date 
Console.WriteLine($"Confronto tra date: {result}");

if (result == 1)
{
    Console.WriteLine("data1 superiore dada2");
}
else if (result == -1)
{
    Console.WriteLine("data1 inferiore dada2");
}
else
{
    Console.WriteLine("date uguali");
}