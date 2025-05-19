// calcolatrice


/*
Console.WriteLine("dimmi il primo numero");
int numero1 = int.Parse (Console.ReadLine());


Console.WriteLine("dimmi il secondo numero");
int numero2 = int.Parse (Console.ReadLine());


Console.WriteLine("dimmi che operazione vuoi fare +, -, /, *");

string operatore = Console.ReadLine();
*/

while (true)
{
    Console.WriteLine("dimmi il primo numero");
    int numero1 = int.Parse (Console.ReadLine());


    Console.WriteLine("dimmi il secondo numero");
    int numero2 = int.Parse (Console.ReadLine());


    Console.WriteLine("dimmi che operazione vuoi fare +, -, /, *");

    string operatore = Console.ReadLine();

    switch (operatore)
    {
        case "+":
            int addizione = numero1 + numero2;
            Console.WriteLine($"{addizione}");
            break;
        case "-":
            int sottrazione = numero1 - numero2;
            Console.WriteLine($"{sottrazione}");
            break;
        case "*":
            int moltiplicazione = numero1 * numero2;
            Console.WriteLine($"{moltiplicazione}");
            break;
        case "/":

            if (numero2 == 0)
            {
                Console.WriteLine("Non puoi dividere per 0 ERRORE");
            }
            else
            {
                int divisione = numero1 / numero2;
                Console.WriteLine($"{divisione}");
            }
            break;
        default:
            Console.WriteLine("non hai inserito l'operatore valido scegli tra: +, -, /, * ");
            break;
    }

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

