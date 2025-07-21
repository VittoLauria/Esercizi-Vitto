// Questa classe statica si occupa di tracciare le operazione di log 
using System.Text.Json;

namespace Backend.Utils
{
    public static class LoggerHelper
    {
        public static void Log(string message)
        {
            // creo una strign di log con timespan
            string logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            // scrivo il log su console
            Console.WriteLine(logLine);
            // scrive sul file di log
            File.AppendAllText("log.txt", logLine + Environment.NewLine);
        }
    }
}