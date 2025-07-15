using Newtonsoft.Json;
using Backend.Models;

namespace Backend.Services
{
    public class UtenteService
    {
        private readonly string _utenteFile;

        public UtenteService(string utenteFile = "Data/Utenti.Json")
        {
            _utenteFile = utenteFile;
        }

        public void AddUtente(Utente utente)
        {
            var utenti = GetAllUtenti() ?? new List<Utente>();
            int nuovoId = 1;
            foreach (var u in utenti)
            {
                if (u.Id >= nuovoId)
                {
                    nuovoId = u.Id + 1;
                }
            }
            utente.Id = nuovoId;
            utenti.Add(utente);
            SaveUtenti(utenti);
        }
        private void SaveUtenti(List<Utente> utenti)
        {

            var Json = JsonConvert.SerializeObject(utenti, Formatting.Indented);
            File.WriteAllText(_utenteFile, Json);
        }
        public List<Utente> GetAllUtenti()
        {
            if (!File.Exists(_utenteFile))
            {
                throw new FileNotFoundException("File non trovato");
            }
            var json = File.ReadAllText(_utenteFile);
            var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
            return utenti ?? new List<Utente>();
        }
        public Utente GetUtente(int id)
        {
            var utenti = GetAllUtenti();
            foreach (var utente in utenti)
            {
                if (utente.Id == id)
                {
                    return utente;
                }
            }
            return null;
        }
        public void UpdateUtente(int id, Utente updatedUtente)
        {
            if (updatedUtente == null)
            {
                return;
            }
            var utenti = GetAllUtenti();
            Utente utenteScelto = null;

            foreach (var utente in utenti)
            {
                if (utente.Id == id)
                {
                    utenteScelto = utente;
                    break;
                }
            }
            if (utenteScelto != null)
            {
                // Aggiorna i campi dell'album
                utenteScelto.Nome = updatedUtente.Nome;
                utenteScelto.Eta = updatedUtente.Eta;
                utenteScelto.DataNascita = updatedUtente.DataNascita;
                utenteScelto.Indirizzo = updatedUtente.Indirizzo;

                SaveUtenti(utenti);
            }
        }
        public void DeleteUtenteById(int id)
        {
            // andiamo a leggere tutto il file json
            var utenti = GetAllUtenti();
            Utente utenteDaEliminare = null;
            // ciciliamo per gli utenti all'interno del file Json
            foreach (var utente in utenti)
            {
                if (utente.Id == id)
                {
                    utenteDaEliminare = utente;
                    break;
                }
            }
            if (utenteDaEliminare != null)
            {
                utenti.Remove(utenteDaEliminare);
                SaveUtenti(utenti);
            }
        }
    }
}