
Console.WriteLine("Inserisci i caratteri della password (tra 5 e 8): ");
if (!int.TryParse(Console.ReadLine(), out int lunghezza) || lunghezza < 5 || lunghezza > 8)
{
    Console.WriteLine("Lunghezza non valida.");
    return;
}

string maiuscole = "ABCDEFGHILMNOPQRSTUVZ";
string minuscole = "abcdefghilmnopqrstuvz";
string numeri = "0123456789";
string simboli = "!$%&@#";
string tutti = maiuscole + minuscole + numeri + simboli;

Random random = new Random();
char[] password = new char[lunghezza];

password[0] = maiuscole[random.Next(maiuscole.Length)];
password[1] = minuscole[random.Next(minuscole.Length)];
password[2] = numeri[random.Next(numeri.Length)];
password[3] = simboli[random.Next(simboli.Length)];

for (int i = 4; i < lunghezza; i++)
{
    password[i] = tutti[random.Next(tutti.Length)];
}
Console.WriteLine("eccoti la password:"  + new string(password));