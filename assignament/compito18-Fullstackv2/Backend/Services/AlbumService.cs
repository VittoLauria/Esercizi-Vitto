using Newtonsoft.Json;
using Backend.Models;

namespace Backend.Services
{
    public class AlbumService
    {
        private readonly string _albumFile;

        public AlbumService(string albumFile = "Album.json")
        {
            _albumFile = albumFile;
        }
        //-----------------------METODI CRUD(Create(aggiungi)-Read(leggi/Visualizza)-Update(modifica)Delete(elimina)--------------------------
        // CREATE
        public void AddAlbum(Album album)
        {
            int netxId;
            if (album.Count > 0)
            {
                maxId = 0;
                foreach (var a in _albumFile)
                {
                    if (a.Id > maxId) // Se l id è maggiore del massimo ID trovato
                    {
                        maxId = a.Id; // imposto il massimo ID a quello del prodotto corrente
                    }
                }
                nextId = maxId + 1;
            }
            else
            {
                nextId = 1;
            }

            var album = GetAllAlbums();

            album.Id = netxId;

            album.Add(albums);
            
            SaveAlbums(albums);
        }
        // READ
        public List<Album> GetAllAlbums()
        {
            if (!File.Exist(_albumFile))
            {
                throw new FileNotFoundException("File non trovato");
            }
            var json = File.ReadAllText(_albumFile);
            var albums = JsonConvert.DeserializeObject<List<Album>>(json);
            return albums ?? new List<Album>();
        }

        public Album GetAlbum(int id)
        {
            foreach (var album in _albumFile)
            {
                if (album.Id == id)
                {
                    return album;
                }
            }
            return null;
        }

        // UPDATE
        public void UpdateAlbum(int id, Album Updatealbum)
        {
            var album = GetAllAlbums(id);
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
                albumScelto.Canzoni = Updatealbum.Canzoni;
                albumScelto.Ascoltato = Updatealbum.Ascoltato;
                SaveAlbums(albums); 
            }
        }

        // DELETE
        public void DeleteAlbum(int id)
        {
            var album = GetAllAlbums(id);
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
                albumScelto.Remove(albumScelto);
                SaveAlbums(albums);
            }
        }

        // SAVE
        private void SaveAlbums(List<Album> albums)
        {
            var Json = JsonConvert.SerializeObject(albums, Formatting.Indented);
            File.WriteAllText(_albumFile, Json);
        }
    }
}

