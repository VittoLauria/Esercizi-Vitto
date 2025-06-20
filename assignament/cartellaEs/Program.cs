using Newtonsoft.Json;
while (true)
{
    // menu del programma
    Console.WriteLine("MENU");
    Console.WriteLine("Dimmi se vuoi: \n1)Aggiungere un file \n2)Modificare un file \n3)Eliminare un file specifico \n4)Visualizzare l'elenco dei file, \n5)Visualizzare un file Json specifico, \n6)Visualizza per categoria, \n7)Visualizza per magazzino  \nEsc per uscire");
    string scelta = Console.ReadLine().ToLower();
    if (scelta == "esc")
    {
        
        Console.WriteLine("ok abbiamo finito");
        break;
    }
    
}