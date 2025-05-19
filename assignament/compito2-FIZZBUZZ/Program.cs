// Inizializza un ciclo da 1 a 100

/*
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

*/



  //FizzBuzz (versione 2)

Console.WriteLine("Spara un numero!");
int imput = int.Parse(Console.ReadLine());
string fine = "fine";


while (true)
{

    if (imput % 3 == 0 && imput % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
        
    }
    else if (imput % 3 == 0)
    {
        Console.WriteLine("Fizz");
        
    }
    else if (imput % 5 == 0)
    {
        Console.WriteLine("Buzz");
        

    }
    else (imput == 0)
    {
        Console.Write("Non Valido");
        break;
    }
    Console.WriteLine("Inserisci un nuovo numero");
    imput = Console.ReadLine();

}