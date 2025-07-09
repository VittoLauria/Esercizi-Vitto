
Console.WriteLine("Ciao, benvenuto nella Calcolatrice");
while (true)
{
    Console.WriteLine("Scegli un'operazione:");
    Console.WriteLine("1. Somma");
    Console.WriteLine("2. Sottrazione");
    Console.WriteLine("3. Moltiplicazione");
    Console.WriteLine("4. Divisione");
    var scelta = Console.ReadLine();
    var calcolatrice = new Calcolatrice();
    Console.WriteLine("inserisci il primo numero: ");
    var primoNumero = int.Parse(Console.ReadLine() ?? "0");
    Console.WriteLine("inserisci il secondo numero: ");
    var secondoNumero = int.Parse(Console.ReadLine() ?? "0");


    switch (scelta)
    {
        case "1":
            Console.WriteLine($"Il risultato della somma è: {calcolatrice.Somma(primoNumero, secondoNumero)}");
            break;
        case "2":
            Console.WriteLine($"Il risultato della sottrazione è: {calcolatrice.Sottrazione(primoNumero, secondoNumero)}");
            break;
        case "3":
            Console.WriteLine($"Il risultato della moltiplicazione è: {calcolatrice.Moltiplicazione(primoNumero, secondoNumero)}");
            break;
        case "4":
            Console.WriteLine($"Il risultato della divisione è: {calcolatrice.Divisione(primoNumero, secondoNumero)}");
            break;
        default:
            Console.WriteLine("Operazione non valida. Riprova.");
            break;
    }
    
}
