### Metodi Files e Folder

## FILES

// creare un file

string path = @"test.txt";

File.Create(path).Close(); // chiudere il file dopo la creazione permettere di poterlo modificare

// crerare un film con il timestamp come nome

string timeStamp = DateTime.Now.ToString("yyyyMMdd");
string path = $"test_{timeStamp}.txt";
File.Create(path).Close():

// scrivere su un file

File.WriteAllText(path, "test di scrittura su file"); // scrive il testo nel file, sovrascrivendo il contenuto esistente

// scrivere una collezione di stringhe su un file

List<string> lines = new List<string> { "linea1", "linea2", "linea3" };
File.WriteAllLines(path, lines); // scrive ogni stringa della lista su una nuova riga del file

// aggiungere testo ad un file

File.AppendAllText(path, "test di append\n"); // aggiunge il testo alle fine del file senz asovrascruvere contenuti

// aggiungere una lista di stringhe al file

File.AppendAllLines(path, lines); // aggiunge ogni stringa della lista alla fine del file uno per riga

// Leggere da un file tutto

string content = File.ReadAllText(path); // leggo il contenuto del file in una stringa
// stampo il contenuto del file
Console.WriteLine(content);

// Leggere riga per riga da un file

string[] lines = File.ReadAllLines(path);
foreach (string line in lines)
{
    Console.WriteLine(line);
}

for (int = 0; i< lines.Lenght; i++)
{
    Console.WriteLine($"Riga {i + 1}: {lines[i]}");
}


// Eliminare un file(controllo se esiste)

if (File.Exist(path))
{
    File.Delete(path); // elimina il file se esiste
}
else
{
    Console.WriteLine("Il file non esiste");
}

// Copiare un File

string sourcePath = @"source.txt";
string destinationPath = @"destination.txt";
if (File.Exists(sourcePath))
{
    File.Copy(sourcePath, destinationPath, true);  // Copia il File, sovrascrivendolo se esiste già
    // Il parametro true indica se il file di destinazione esiste o meno
}
else
{
    Console.WriteLine("Il file di origine non esiste")
}

// Rinominare un file

string oldFileName = @"oldName.txt";
string newFileName = @"newName.txt";
if (File.Exists(oldFileName))
{
    File.Move(oldFileName, newFileName); // Rinomina il file
}
else
{
    Console.WriteLine("IL file da rinominare non esiste.")
}

// ottenere informazioni su un file:

FileInfo Info = new FileInfo(path);

Console.Writeline(info.Length);
Console.Writeline(info.CreationTime);
Console.Writeline(info.LastWriteTime);
Console.Writeline(info.Extension);
Console.Writeline(info.Name);
Console.Writeline(info.DirectoryName);

## FOLDER

// creare un directory

string dir = @"test";
Directory.CreateDirecotry(dir);

// verificare se una directory esiste

if (Directory.Exists(dir))
{
    Console.WriteLine("Directory exists");
}

// Eliminare una Directory

Directory.Delete(dir);

// ottenere informazioni su una directory

DirectoryInfo dirInfo = new DirectoryInfo(dir);

Console.Writeline(dirInfo.CreationTime);
Console.Writeline(dirInfo.LastWriteTime);
Console.Writeline(dirInfo.Name);
