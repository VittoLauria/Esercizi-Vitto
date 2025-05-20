# format
Adattare il seguente metodo format per fromattare le strighe:
```csharp
string nome = "Nome";
int eta = 10;
string frase = string.Format("Il partecipante si chiama {0} e ha {1} anni.", nome, eta);
Console.WriteLine(frase)
```
ad una collezioni di nomi ed eta.
otterrò più frasi ognuna riferita ad un elemento della collezione

## suggerimenti
- esempio di collezione di nomi
```csharp
string [] nomi = { "Nome1", "Nome2", "Nome3" };

- esempio collezione di eta
int [] eta = { 10, 20, 30 };

- Uso il ciclo foreach per iterare su ongi elemento della collezione
foreach (var nome in nomi)
{
    // codice da eseguire per ogni elemento della collezione
}

# Format versione2
In questa versione usiamo un dizionario invece di due collezioni separate