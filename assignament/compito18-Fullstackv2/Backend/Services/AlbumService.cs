using Newtonsoft.Json;
using Backend.Models;

namespace Backend.Services
{
    public class AlbumService
    {
        // istanziamo il percorso del file in modo privato perchè deve essere possibile modificarlo soltanto una volta
        private readonly string _albumFile;

        public AlbumService(string albumFile = "Data/Album.json")
        {
            // lo rendiamo pubblico per essere accessibile dalle classi esterne(Controller)
            _albumFile = albumFile;
        }
        //-----------------------METODI CRUD(Create(aggiungi)-Read(leggi/Visualizza)-Update(modifica)Delete(elimina)--------------------------
        // CREATE
        // aggiunge un nuovo album all'interno del file 
        public void AddAlbum(Album album)
        {

            var albums = GetAllAlbums() ?? new List<Album>();
            int nuovoId = 1;
            foreach (var a in albums)
            {
                if (a.Id >= nuovoId)
                {
                    nuovoId = a.Id + 1;
                }
            }
            album.Id = nuovoId;
            if (album.Canzoni != null)
            {
                int canzoneId = 1;
                foreach (var c in album.Canzoni)
                {
                    c.CanzoneId = canzoneId;
                    canzoneId++;
                }
            }

            albums.Add(album);

            SaveAlbums(albums);
        }


        // READ
        // Leggiamo i contenuti all'interno del file i ritorna l'elenco completo degli album
        public List<Album> GetAllAlbums()
        {
            if (!File.Exists(_albumFile))
            {
                throw new FileNotFoundException("File non trovato");
            }
            var json = File.ReadAllText(_albumFile);
            var albums = JsonConvert.DeserializeObject<List<Album>>(json);
            return albums ?? new List<Album>();
        }
        // leggiamo e prendiamo soltanto un album all'interno del file Json
        public Album GetAlbum(int id)
        {
            var albums = GetAllAlbums();
            foreach (var album in albums)
            {
                if (album.Id == id)
                {
                    return album;
                }
            }
            return null;
        }

        // UPDATE
        // modificamo un album all'interno del file
        public void UpdateAlbum(int id, Album updateAlbum)
        {
            if (updateAlbum == null)
            {
                return;
            }
            var albums = GetAllAlbums();
            Album albumScelto = null;

            foreach (var album in albums)
            {
                if (album.Id == id)
                {
                    albumScelto = album;
                    break;
                }
            }
            if (albumScelto != null)
            {
                // Trova il massimo Id già usato
                int maxCanzoneId = 0;
                foreach (var a in albums)
                {
                    foreach (var c in a.Canzoni)
                    {
                        if (c.CanzoneId > maxCanzoneId)
                        {
                            maxCanzoneId = c.CanzoneId;
                        }
                    }
                }

                // Assegna nuovi ID alle canzoni aggiornate
                foreach (var canzone in updateAlbum.Canzoni)
                {
                    maxCanzoneId++;

                }

                // Aggiorna i campi dell'album
                albumScelto.Titolo = updateAlbum.Titolo;
                albumScelto.Autore = updateAlbum.Autore;
                albumScelto.Genere = updateAlbum.Genere;
                albumScelto.Anno = updateAlbum.Anno;
                albumScelto.Ascoltato = updateAlbum.Ascoltato;
                albumScelto.Canzoni = updateAlbum.Canzoni;

                SaveAlbums(albums);
            }
        }

        // DELETE
        // Cancella un album specifico all'intenro del file 
        public void DeleteAlbumById(int id)
        {
            // andiamo a leggere tutto il file json
            var albums = GetAllAlbums();
            Album albumDaEliminare = null;
            // ciciliamo per gli album all'interno del file Json
            foreach (var album in albums)
            {
                if (album.Id == id)
                {
                    albumDaEliminare = album;
                    break;
                }
            }
            if (albumDaEliminare != null)
            {
                albums.Remove(albumDaEliminare);
                SaveAlbums(albums);
            }
        }

        // SAVE
        // Andiamo a salvare le modifiche che facciamo con i metodi (Add,Update) agli album che sono presenti all'intenro del file
        private void SaveAlbums(List<Album> albums)
        {
            // serializzo l'album creato con il metodo Add all'interno del file Json 
            var Json = JsonConvert.SerializeObject(albums, Formatting.Indented);
            File.WriteAllText(_albumFile, Json);
        }
    }
}

