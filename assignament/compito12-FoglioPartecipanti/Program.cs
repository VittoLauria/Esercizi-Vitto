/*
// creo i file "partecipanti", "estratto"
string partecipanti = @"partecipanti.txt";
File.Create(partecipanti).Close();
string partEstratto = @"estratto.txt";
File.Create(partEstratto).Close();
// creo la lista da aggiungere al file creato

List<string> listaPartecipanti = new List<string> { "Edoardo", "Salvatore", "Riccardo", "Luca" };
string partecipanteEstratto = "";

// creo l'oggetto Random
 Random rndEstratto = new Random();
 // genero l'indice del partecipante
 int indiceEstratto = rndEstratto.Next(listaPartecipanti.Count);

File.AppendAllLines(partecipanti, listaPartecipanti);

foreach (string partecipante in listaPartecipanti)
{
    Console.WriteLine(partecipante);
}

partecipanteEstratto = listaPartecipanti[indiceEstratto];


File.WriteAllText(partEstratto, partecipanteEstratto);
Console.WriteLine("Il fortunato è:" + partecipanteEstratto);
*/
//VERSIONE 2//

// leggo l'elenco dei partecipanti
string[] partecipanti = File.ReadAllLines("partecipanti.txt");
// inizializzo un arry per gli estratti
string[] estratti = new string[0];
string timespan = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
// mi assicuro che il file dei partecipanti estratti esista
if (File.Exists("estratto.txt"))
{
    estratti = File.ReadAllLines("estratto.txt");

}
Console.Clear();
Console.WriteLine($"Timestamp corrente: {timespan}");
// stampa i partecipanti a video
Console.WriteLine("partecipanti:");
foreach (string partecipante in partecipanti)
{
    Console.WriteLine(partecipante);
}
// uso il metodo Except per trovare i partecipanti non estratti
string[] disponibili = partecipanti.Except(estratti).ToArray();

// verifico se ci sono partecipanti disponibili
if (disponibili.Length == 0)
{
    Console.WriteLine("Non ci sono piu partecipanti disponibili");
    return;// esce dal programma se non ci sono piu partecipanti disponibili
}
// stampa i partecipanti disponibili

Console.WriteLine("Partecipanti disponibili:");
foreach (string partecipante in disponibili)
{
    Console.WriteLine(partecipante);
}
// crea un'istanza di random per generare un numero casuale
Random random = new Random();
// Estare un indice casuale dall'elenco dei disponibili
int indiceEstratto = random.Next(disponibili.Length);
// ottengo il partecipante estrattto
string partecipanteEstratto = disponibili[indiceEstratto];
// Visualizzo il partecipante estratto
Console.WriteLine($"Partecipante estratto: {partecipanteEstratto}");
// Aggiungo il partecipante etsrtato al file degli estratti
File.AppendAllText("estratto.txt", partecipanteEstratto + Environment.NewLine);
// Oppure
//File.AppendAllText("estratto.txt", $"{partecipanteEstratto}\n");

// stampa il numero di partecipanti estartti e quelli ancora disponibili
Console.WriteLine($"Partecipanti estratti: {estratti.Length + 1}");
Console.WriteLine($"Partecipanti ancora disponibili: {disponibili.Length - 1}");