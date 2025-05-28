//FATTO DAL PROF
// L'utente deve poter scegliere la lunghezza della password
Console.WriteLine("Inserisci la lunghezza della password (tra 5 e 8): ");
if (!int.TryParse(Console.ReadLine(), out int lunghezza) || lunghezza < 5 || lunghezza > 8) 
{
    Console.WriteLine("Lunghezza non valida.");
    return;
}


//Puoi creare gruppi di caratteri(lettere maiuscole,minuscole,numeri e caratteri speciali) e selezionare casualmente un carattere da ciascun gruppo
string caratteri = "ABCDEFGHILMNOPQRSTUVZabcdefeghilmnopqrstuvz0123456789@#*!$%&eeeeeeeeee";

//Usa classe random per generare caratteri casuali
Random random = new Random();
char[] password = new char[lunghezza];
password[0] = caratteri[random.Next(26)];
password[1] = caratteri[random.Next(26, 52)];
password[2] = caratteri[random.Next(52, 62)];
password[3] = caratteri[random.Next(62, caratteri.Length)];

for (int i = 4; i < lunghezza; i++)
{
    password[i] = caratteri[random.Next(caratteri.Length)];
}

// Opzionale
/*
for (int i = password.Lenght - 1; i > 0; i--)
{
    (password[i], password[random.Next(i + 1)]) = (password[random.Next(i + 1)], password[i]);
}
*/
Console.WriteLine($"La tua password generata è: {new string(password)}");
