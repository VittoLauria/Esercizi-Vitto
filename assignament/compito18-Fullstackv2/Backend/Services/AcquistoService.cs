using Newtonsoft.Json;
using Backend.Models;

namespace Backend.Services
{
    public class AcquistoService
    {
        private readonly string _acquistoFile;

        public AcquistoService(string acquistoFile = "Data/Acquisto.Json")
        {
            _acquistoFile = acquistoFile;
        }

        public void AddAcquisto(Acquisto acquisto)
        {
            var acquisti = GetAllAcquisti() ?? new List<Acquisto>();
            int nuovoId = 1;
            foreach (var a in acquisti)
            {
                if (a.Id >= nuovoId)
                {
                    nuovoId = a.Id + 1;
                }
            }
            acquisto.Id = nuovoId;
            acquisti.Add(acquisto);
            SaveAcquisti(acquisti);
        }
        private void SaveAcquisti(List<Acquisto> acquisti)
        {

            var Json = JsonConvert.SerializeObject(acquisti, Formatting.Indented);
            File.WriteAllText(_acquistoFile, Json);
        }
        public List<Acquisto> GetAllAcquisti()
        {
            if (!File.Exists(_acquistoFile))
            {
                throw new FileNotFoundException("File non trovato");
            }
            var json = File.ReadAllText(_acquistoFile);
            var acquisti = JsonConvert.DeserializeObject<List<Acquisto>>(json);
            return acquisti ?? new List<Acquisto>();
        }
        public Acquisto GetAcquisto(int id)
        {
            var acquisti = GetAllAcquisti();
            foreach (var acquisto in acquisti)
            {
                if (acquisto.Id == id)
                {
                    return acquisto;
                }
            }
            return null;
        }
/*
        public void UpdateAcquisto(int id, Acquisto updatedAcquisto)
        {
            if (updatedAcquisto == null)
            {
                return;
            }
            var acquisti = GetAllAcquisti();
            Acquisto acquistoFatto = null;

            foreach (var acquisto in acquisti)
            {
                if (acquisto.Id == id)
                {
                    acquistoFatto = acquisto;
                    break;
                }
            }
            if (acquistoFatto != null)
            {
                // Aggiorna i campi dell'album
                acquistoFatto.DataAcquisto = updatedAcquisto.DataAcquisto;
                
            }
        }
        */
        public void DeleteAcquistoById(int id)
        {
            // andiamo a leggere tutto il file json
            var acquisti = GetAllAcquisti();
            Acquisto acquistoDaEliminare = null;
            // ciciliamo per gli utenti all'interno del file Json
            foreach (var acquisto in acquisti)
            {
                if (acquisto.Id == id)
                {
                    acquistoDaEliminare = acquisto;
                    break;
                }
            }
            if (acquistoDaEliminare != null)
            {
                acquisti.Remove(acquistoDaEliminare);
                SaveAcquisti(acquisti);
            }
        }
    }
}