using System.Text.Json;

namespace Backend.Utils
{
    public static class JsonFileHelper
    {
        // questa classe fornisce metodi per caricare e salvare liste di oggetti in file JSON
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            // Imposta le opzioni di serializzazione per gestire i nomi delle proprietà in modo case-insensitive
            PropertyNameCaseInsensitive = true,
            // Imposta l'indentazione per una migliore leggibilità del file JSON
            WriteIndented = true
        };

        // metodo per caricare una lista di oggetti da un file JSON (deserializzazione)
        // T indica che il metodo può essere utilizzato con qualsiasi tipo di oggetto tipo ad esempio List<User>, List<Category>, List<Product>
        // filePath è il percorso del file JSON da cui caricare la lista
        // restituisce una lista di oggetti del tipo specificato o una lista vuota se il file non esiste
        public static List<T> LoadList<T>(string filePath)
        {
            // Controlla se il file esiste, se non esiste restituisce una lista vuota
            if (!File.Exists(filePath))
                // Restituisce una lista vuota
                return new List<T>();
            // Legge il contenuto del file JSON e deserializza in una lista di oggetti del tipo specificato
            string json = File.ReadAllText(filePath);
            // Deserializza il JSON in una lista di oggetti del tipo T
            return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
        }

        // metodo per salvare una lista di oggetti in un file JSON (seralizzazione)
        public static void SaveList<T>(string filePath, List<T> list)
        {
            string json = JsonSerializer.Serialize(list, options);
            File.WriteAllText(filePath, json);
        }
    }
}