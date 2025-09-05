// questa classe statica si occupa di tracciare le operazioni di log
namespace Backend.Utils
{
    public static class LoggerHelper
    {
        public static void Log(string message)
        {
            // Crea una stringa di log con timestamp
            string logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            // Scrive il log su console
            Console.WriteLine(logLine);
            // Scrive sul file di log
            File.AppendAllText("log.txt", logLine + Environment.NewLine);
        }
    }
}