// gestione eccezioni

// sto tentando di accedere ad un file che non esiste

try
{
    // il file deve essere nella stessa cartella del programma
    string contenuto = File.ReadAllText("file.txt");
    Console.WriteLine(contenuto);
}
catch (Exception e)
{
    Console.WriteLine("Il file non esiste");
    Console.WriteLine($"Errore non trattato {e.Message}");
    Console.WriteLine($"Codice errore: {e.HResult}");
    return;
}

// sto cercando di dividere un numero per zero

try
{
    int zero = 0;
    int numero = 1 / zero; // il programma si blocca perche non si puo dividere per zero
}
catch (Exception e)
{
    Console.WriteLine("Divisione per zero");
    Console.WriteLine($"Errore non trattato {e.Message}");
    Console.WriteLine($"Codice errore: {e.HResult}");
    return;
    
}


// sto cercando di accedere ad un elemento di un array che non esiste

int[] numeri = { 1, 2, 3, };

try
{
    Console.WriteLine(numeri[3]);
}
catch (Exception e)
{
    Console.WriteLine("Divisione per zero");
    Console.WriteLine($"Errore non trattato {e.Message}");
    Console.WriteLine($"Codice errore: {e.HResult}");
    return;

}

// sto cercando di accedere ad un oggetto null

string nome = null;
try
{
    Console.WriteLine(nome.Length);
}
catch (Exception e)
{
    
    Console.WriteLine($"Errore non trattato {e.Message}");
    Console.WriteLine($"Codice errore: {e.HResult}");
    return;

}


// non ce abbastanza memoria disponibile
try
{
    int[] numeri = new int[int.MaxValue]; // 2147483591
}
catch (Exception e)
{

    Console.WriteLine($"Errore non trattato {e.Message}");
    Console.WriteLine($"Codice errore: {e.HResult}");
    return;

}


try
{
    int numero = int.Parse("100000000000"); // 2147483591
}
catch (Exception e)
{

    Console.WriteLine($"Errore non trattato {e.Message}");
    Console.WriteLine($"Codice errore: {e.HResult}");
    Console.WriteLine(e.Data);
    return;

}


// esempio try catch finally con un files di tetso che sia che avvengo o non avvenga la scrittura dev'essere chiusa
try
{
    using (StreamWriter writer = new StreamWriter("file.txt"))
    {
        writer.WriteLine("Ciao mondo");
    }
}
catch (Exception e)
{
    Console.WriteLine($"Errore non trattato {e.Message}");
    Console.WriteLine($"Codice errore: {e.HResult}");
    Console.WriteLine(e.Data);
}
finally
{
    Console.WriteLine("Il file è stato chiuso");
}
