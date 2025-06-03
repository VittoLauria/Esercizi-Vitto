string pathTest = @"test.txt";

File.Create(pathTest).Close(); // chiudere il file dopo la creazione permettere di poterlo modificare

// crerare un film con il timestamp come nome

string timeStamp = DateTime.Now.ToString("yyyyMMdd");
string path = $"test_{timeStamp}.txt";
File.Create(path).Close();

// scrivere su un file

File.WriteAllText(path, "test di scrittura su file"); // scrive il testo nel file, sovrascrivendo il contenuto esistente

// scrivere una collezione di stringhe su un file

List<string> lines = new List<string> { "linea1", "linea2", "linea3" };
File.WriteAllLines(path, lines); // scrive ogni stringa della lista su una nuova riga del file

File.AppendAllText(path, "test di append\n");

File.AppendAllLines(path, lines);

string content = File.ReadAllText(path);             // sono tutti esempi
Console.WriteLine(content);

string[] lines = File.ReadAllLines(path);

for (int i = 0; i < 2; i++)
{
    Console.WriteLine(lines[i]);
}
string[] line = File.ReadAllLines(path);

foreach (string line in lines)
{
    Console.WriteLine(line);
}