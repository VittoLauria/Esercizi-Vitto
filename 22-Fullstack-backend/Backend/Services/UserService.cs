using Backend.Models;
using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper

namespace Backend.Services
{
    public class UserService
    {
        private readonly List<User> _users;
        public UserService()
        {
            // Carica gli utenti dal file JSON
            _users = JsonFileHelper.LoadList<User>("Data/users.json");
        }

        public void Save()
        {
            // Serializza la lista degli utenti in formato JSON e la salva nel file
            JsonFileHelper.SaveList("Data/users.json", _users);
        }

        public List<User> GetAll()
        {
            List<User> result = new List<User>();
            foreach (User user in _users)
            {
                result.Add(user);
            }
            return result;
        }

        public User GetById(int id)
        {
            foreach (User user in _users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public User Add(User newUser)
        {
            newUser.Id = IdGenerator.GetNextId(_users); // Usa IdGenerator per ottenere il prossimo ID
            _users.Add(newUser);
            // Log aggiunta dell'utente
            LoggerHelper.Log($"Aggiunto utente ID: {newUser.Id} ({newUser.Name})");
            Save(); // salvo i cambiamenti nel file JSON
            return newUser;
        }

        public bool Delete(int id)
        {
            User existing = null;
            foreach (User user in _users)
            {
                if (user.Id == id)
                {
                    existing = user;
                    break;
                }
            }
            if (existing == null)
            {
                return false;
            }
            bool removed = _users.Remove(existing);
            if (removed)
            {
                LoggerHelper.Log($"Cancellato utente ID: {id}");
            }
            else
            {
                LoggerHelper.Log($"Tentativo di cancellazione fallito per utente ID: {id}");
            }
            Save(); // salvo i cambiamenti nel file JSON
            return removed;
        }

        public bool Update(int id, User updatedUser)
        {
            User existing = null;
            foreach (User user in _users)
            {
                if (user.Id == id)
                {
                    existing = user;
                    break;
                }
            }
            if (existing == null)
            {
                return false;
            }
            existing.Name = updatedUser.Name;
            existing.Address = updatedUser.Address; // aggiorno l'indirizzo dell'utente esistente con quello dell'utente aggiornato
            LoggerHelper.Log($"Aggiornato utente ID: {id} con nuovo nome: {updatedUser.Name}");
            Save(); // salvo i cambiamenti nel file JSON
            return true;
        }
    }
}