/*
string progetti = @"Progetti"; // creo la prima cartella di backup
Directory.CreateDirectory(progetti);

// creo i file da aggiungere alla cartella
string file1 = @"prova1.txt"; 
File.Create(file1).Close();
string file2 = @"prova2.txt";
File.Create(file2).Close();

// aggiungo una lista di stringhe per il file1
List<string> lines = new List<string> { "linea1", "linea2", "linea3" };
File.WriteAllLines(file1, lines);
List<string> lines2 = new List<string> { "linea4", "linea5", "linea6" };
File.WriteAllLines(file2, lines2);


//Creo la seconda cartella dove incollarci tutto
string data = DateTime.Now.ToString("yyyyMMdd");
string progetto2 = $"Progetto2_{data}";
Directory.CreateDirectory(progetto2);

string[] files = Directory.GetFiles(progetti);
foreach (string file in files)
{
    Console.WriteLine(file);
}
*/
string cartellaSorgente = @"Progetti";
string timespan = DateTime.Now.ToString("yyyyMMdd_HHmmss");
string cartellaDestinazione = @$"{cartellaSorgente}_{timespan}";

void Copia(string sorgente, string destinazione)
{
    Directory.CreateDirectory(destinazione);
    // cercare i files nella cartella sorgente
    string[] files = Directory.GetFiles(sorgente);
    // ciclare in modo da copiare i files che ci sono dalla destinazione alla sorgente
    for (int i = 0; i < files.Length; i++)
    {
        // ottengo le info sul file corrente
        FileInfo Info = new FileInfo(files[i]);
        string nuovoPercorso = $"{destinazione}/{Info.Name}";
        File.Copy(files[i], nuovoPercorso, true);
    }

    // cercare le cartelle nella cartella sorgente
    string[] cartelle = Directory.GetDirectories(sorgente);
    for (int i = 0; i < cartelle.Length; i++)
    {
        // ottengo le info delle cartelle
        DirectoryInfo Info = new DirectoryInfo(cartelle[i]);
        string nuovaCartella = $"{destinazione}/{Info.Name}";
        Copia(cartelle[i], nuovaCartella);
    }
}

Copia(cartellaSorgente, cartellaDestinazione);
Console.WriteLine($"Backup completato in: {cartellaDestinazione}");