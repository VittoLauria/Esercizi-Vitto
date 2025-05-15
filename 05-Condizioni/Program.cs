/*
 Le condizioni o le istruzioni condizionali sono utilizzate per eseguire un ##blocco di codice solo se una certa condizione e vera.In C#
le condizioni possono essere scritte in vari modi,i piu comuni sono (if, else, else if, switch)

//If (se)
if (condizione)
{
    // codice da eseguire se la condizione e vera (questo è un blocco di codice, le due graffe messe cosi)
}
*/

//esempio uso di if else

int a = 10;
int b = 5;
if (a > b)
{ 
    Console.WriteLine($"{a} è maggiore di {b}");
}
else // else (altrimenti)
{
    Console.WriteLine($"{a} non è maggiore di {b}");
}

// esempio di uso di if else if

int a = 10;
int b = 5;
if (a > b)
{
    //codice da eseguire se la condizione e vera
    Console.WriteLine($"{a} è maggiore di {b}");
}
else if (a < b)
{
     //codice da eseguire se la condizione e vera
     Console.WriteLine($"{a} è minore di {b}");
}
else
{
     //codice da eseguire se la condizione e falsa
     Console.WriteLine($"{a} è uguale a {b}");
}

// switch
 //break serve per uscire dal blocco switch
 int a = 10;
 switch (a) 
 {
    case 1:
        Console.WriteLine("il valore è 1");
        break;
     case 2:
            Console.WriteLine("il valore è 2");
        break;
    case 3:
        Console.WriteLine("il valore è 3");
        break ;
      default:
       Console.WriteLine("il valore non è 1, 2 o 3");
       break;  
 }

 //switch (string)
 string a = "pausa";
 switch (a)
 {
    case "pausa":
     Console.WriteLine("il valore è pausa");
     break;
    case "pranzo":
     Console.WriteLine("il valore è pranzo");
     break;
    case "cena":
    Console.WriteLine("il valore è cena");
    break;
    default:
     Console.WriteLine("Il valore non è pausa,pranzo o cena");
     break;
 }

 //switch (bool)
 bool a = true;
 switch (a)
 {
    case true: 
    Console.WriteLine("Il valore è true");
    break;
    case false:
    Console.WriteLine("Il valore è false");
    break;
 }