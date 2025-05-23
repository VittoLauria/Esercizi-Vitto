/*
Random numeroRandom = new Random();
for (int i = 0; i < 10; i++)
{
    int numero = numeroRandom.Next(1, 101); // genero un numero casuale tra 1 e 100
    if (numero % 3 == 0 || numero % 5 == 0)
    {
        Console.WriteLine(numero);
    }
}

List<int> numeriPari = new List<int>();
Random numeroRandom = new Random();
for (int i = 0; i < 10; i++)
{
    int numero = numeroRandom.Next(1, 100);
    if (numero % 2 == 0)
    {
        numeriPari.Add(numero);
    }
}
Console.WriteLine("Numeri pari: ");
foreach (int numero in numeriPari)
{
    Console.WriteLine(numero);
}
*/

Random numeroRandom = new Random();
int dado1 = numeroRandom.Next(1, 7);
int dado2 = numeroRandom.Next(1, 7);

int somma = (dado1 + dado2);
Console.WriteLine(somma);
