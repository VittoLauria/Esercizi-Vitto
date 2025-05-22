# METODI STRINGA
I tipi di stringa hanno dei metodi che permettono di eseguire delle operazioni su di esse(manipolazioni di stringa) o di ottenere informazioni.


// lenght = prende la lunghezza di una stringa
```csharp
string nome = " Nome1 ";
int lunghezza = nome.Lenght;
Console.WriteLine(lunghezza); // output: 5 (lunghezza di nome1)
```
// isnullorwhitespace = verifica se una stringa e nulla o vuota o contiene spazi
```csharp
Console.writeLine(string.IsNullOrWhiteSpace(nome)); // output false
```
// isnullorempty = verifica se una stinga e nulla o vuota
```csharp
Console.WriteLine(string.IsNullOrEmpty(nome)); // output false
```
// tolower = converta una stringa in minuscolo
```csharp
Console.WriteLine(nome.ToLower()); // output nome1 
```
// toupper = converta una stringa in maiuscolo
```csharp
Console.WriteLine(nome.ToUpper()); // output NOME1
```

// trim = rimuove gli spazi bianchi all inizio e alla fine di una stringa
```csharp
Console.WriteLine(nome.Trim()); // output Nome1
```
// split = divide una stringa in base ad un separatore
```csharp
string nomi = "Nome1, Nome2, Nome3, Nome4, Nome5";
string [] nomiArray = nomi.Split(", ");
foreach (string n in nomiArray)
{
    Console.Writeline(n);
}
```
// Join = Unisce gli elementi di un array in una stringa usando un separatore
```csharp
string nomiUniti = string.join(", " nomi);
Console.WriteLine(nomiUniti);
```

// replace = sostituisce una sottostringa con un'altra sottostringa
```csharp
string sostituzione = nome.Replace("Nome", "Cognome");
Console.WriteLine(sostituzione); // output Cognome1
// oppure
Console.Writeline(nome.Replace("Nome1", "Nome2"));
```

// substring = restituisce una sottostringa a partire da un indice ed una lunghezza(partendo dalla lettera in posizione 0 prende due caratteri)
```csharp
Console.WriteLine(nome.Substring(0, 2));
```

// contains = verifica se una stringa contiene una sottostringa
```csharp
Console.WriteLine(nome.Contains("Nom")); // output false
```
// startswith = verifica se una stringa inizia con una sottostringa
```csharp
Console.WriteLine(nome.StartsWith("Nom")); // output true
```
//endswith = verifica se una stringa finsice con una sottostringa
```csharp
Console.WriteLine(nome.EndsWith("ome")); // output true
```

## conversioni

// tostring = converte un tipo di dato in stringa
```csharp
int numero = 10;
string numeroStringa = numero.ToString();
Console.WriteLine(numeroStringa); // output: 10
```

// parse = converte una stringa in un tipo di dato
```csharp
string numeroDaConvertire = "10";
int numeroConvertito = int.Parse(numeroDaConvertire);
Console.WriteLine(numeroConvertito); // ouput: 10
```
// tryparse = converte una stringa in un tipo di dato e restituisce un booleano che indica se la converiosne è andata a buon fine
```csharp
string numeroDaConvertire = "10";
int numeroConvertito;
bool conversione = int.TryParse(numeroDaConvertire, out numeroConvertito);
Console.WriteLine(conversione); // output: true
Console.WriteLine(numeroConvertito); // output: 10
```
// convert = converte un tipo di dato in un altro tipo di dato
```csharp
int numeroDaConvertire = 10;
string numeroConvertito = Convert.ToString(numeroDaConvertire);
Console.WriteLine(numeroConvertito); // output 10
```
//oppure(se la conversione non è possibile viene generata un'eccezione ditipo ivalidCastException)
```csharp
string numeroDaConvertire = 10;
int numeroConvertito = Convert.ToInt32(numeroDaConvertire);
Console.WriteLine(numeroConvertito); // output 10
```
// format = formatta una stringa usando dei segnaposto con degli indici
```csharp
string nome = "Nome";
int eta = 10;
string frase = string.Format("Il partecipante si chiama {0} e ha {1} anni.", nome, eta);
Console.WriteLine(frase); // output: il partecipante si chiama Nome e ha 10 anni.
```
