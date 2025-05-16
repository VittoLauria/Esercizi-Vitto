// Inizializza un ciclo da 1 a 100


for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if (i % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (i % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine(i);
    }
}
// Contolla se il numero è divisibile per 3 o 5
//stmpa "FizzBuzz"

//int modulo = i % 3 && i % 5;
//Console.Readline("FizzBuzz");








//Controlla se il numero è divisibile per 3
// stampa "Fizz"

//Controla se il numero è divisibile per 5
//stmpa "Buzz"

//altrimenti stampa il numero
