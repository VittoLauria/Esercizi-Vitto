
while (true)
{
    Console.WriteLine("dimmi il primo numero");
    int numero1 = int.Parse(Console.ReadLine());

    Console.WriteLine("dimmi il secondo numero");
    int numero2 = int.Parse(Console.ReadLine());

    Console.WriteLine("dimmi che operazione vuoi fare +, -, /, *");
    string operatoreScelto = Console.ReadLine();

    int risultato = 0;
    
    switch (operatoreScelto)
    {
        case "+":
            risultato = Somma(numero1, numero2);
            break;
        case "-":
            risultato = Sottrazione(numero1, numero2);
            break;
        case "*":
            risultato = Moltiplicazione(numero1, numero2);
            break;
        case "/":
            if (numero2 == 0)
            {
                Console.WriteLine("errore non si puo dividere per 0");

            }
            else
            {
                risultato = Divisione(numero1, numero2);
            }
            break;
        default:
            Console.WriteLine("L'operazione richiesta non è disponibile");
            break;

    }
    if (!(operatoreScelto == "/" && numero2 == 0))
    {
        Console.WriteLine($"Il risulatato è: {risultato}");
    }
    // chiedo se vuole continuare
        Console.WriteLine("vuoi riprovare? (si o no)");
    string scelta = Console.ReadLine();
    if (scelta == "si")
    {
        Console.WriteLine("vabene");
    }
    else if (scelta == "no")
    {
        Console.WriteLine("ok");
        break;
    }
}
// Funzione per somma
int Somma(int a, int b)
{
    return a + b;
}
// funzione per sottrazione
int Sottrazione(int a, int b)
{
    return a - b;
}
// funzione moltiplicazione
int Moltiplicazione(int a, int b)
{
    return a * b;
}
// funzione per divisione
int Divisione(int a, int b)

{
    return a / b;
}
