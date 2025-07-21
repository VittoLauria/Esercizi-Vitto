using System.Text.Json;

namespace Backend.Utils
{
    public static class JsonFileHelper
    {
        // questa classe fornisce metodi per caricare e salvare liste di oggetti in file json
        // quetsa e una classe statica che non puo essere istanziata 

        // configuro le impostazioni di serializzazione
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            // importa le opzione di serializzazione per gestire i nomi delle proprieta in modo case.insensitive
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        // metodo per caricare una lista di oggetti da un file Json(deserializzazione)
        public static List<T> LoadList<T>(string filePath)
        {
            // T indica che il metodo puo essere utilizzata con qulalsisasi tipo di oggetto
            // controllo se il file esiste 
            if (!File.Exists(filePath))
                return new List<T>();
            // leggo il contenuto del file
            string json = File.ReadAllText(filePath);
            // lo deserializzo in una lista di oggetti genrici di tipo T
            return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
        }

        // metodo per salvare una lista di oggetti in un file Json(serializzazione)
        public static void SaveList<T>(string filePath, List<T> list)
        {
            string json = JsonSerializer.Serialize(list, options);
            File.WriteAllText(filePath, json); 
        }
    }
}