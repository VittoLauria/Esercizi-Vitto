// calcolatrice



//chiedo all'utente il primo numero 


Console.WriteLine("dimmi il primo numero");
int numero1 = int.Parse (Console.ReadLine());

//chiedo all'utente di inserire il secondo numero 

Console.WriteLine("dimmi il secondo numero");
int numero2 = int.Parse (Console.ReadLine());

//chiedo all'utente l'operazione da eseguire

Console.WriteLine("dimmi che operazione vuoi fare +, -, /, *");

string operatore = Console.ReadLine ();


// ora lavoriamo con le variabili acquisite


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


case "/": 

if ( numero2 == 0)
{ 
    Console.WriteLine("Non puoi dividere per 0 ERRORE");
}
else 
{
     int divisione = numero1 / numero2;
    Console.WriteLine($"{divisione}");
}
break;

case "*": 
    int moltiplicazione = numero1 * numero2;
    Console.WriteLine($"{moltiplicazione}");
    break;

      default:
       Console.WriteLine("non hai inserito l'operatore valido scegli tra: +, -, /, * ");
       break;  
 }


//se l'operazione scelta dall'utente è es.divisione
//se il secondo numero è zero 

//allora stampo un messaggio di errore

//altrimenti eseguo l'operazione

//stampo il risultato