using Backend.Models;
using Backend.Utils;
namespace Backend.Services
{
    public class UserService
    {
        private readonly List<User> _users = new()
        {
            new User { Id = 1, Name = "User uno", Indirizzo = "Via roma 1" },
            new User { Id = 2, Name = "User due", Indirizzo = "Via milano 2" },
        };
        public UserService()
        {
            _users = JsonFileHelper.LoadList<User>("Data/Users.json");
        }
        public void Save()
        {
            JsonFileHelper.SaveList<User>("Data/users.json", _users);
        }
        
        public List<User> GetAll()
        {
           
            return new List<User>(_users);
        }

        public User? GetById(int id)
        {
            foreach (var user in _users)
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
           if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser), "L'Utente non puo essere null");
            }
            if (!ValidationHelper.IsNotNullOrWhiteSpace(newUser.Name))
            {
                throw new ArgumentNullException(nameof(newUser.Name), "Il nome del utente non puo essere vuoto");
            }
           
            newUser.Id = IdGenerator.GetNextId(_users);
            _users.Add(newUser);
            LoggerHelper.Log($"aggiunto utente: ID: {newUser.Id} ({newUser.Name})");
            // invoco il metodo Save
            Save();
            return newUser;
        }

        public bool Delete(int id)
        {
            User? existing = null;
            foreach (var u in _users)
            {
                if (u.Id == id)
                {
                    existing = u;
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
                LoggerHelper.Log($"Cancellato utente Id: {id}");
            }
            else
            {
            LoggerHelper.Log($"utente non cancellato Id: {id}");
           }
            Save();
            return removed;
        }

        public bool Update(int id, User updatedUser)
        {
            if (updatedUser == null)
            {
                throw new ArgumentNullException(nameof(updatedUser), "L'utente non puo essere null");
            }
            if (!ValidationHelper.IsNotNullOrWhiteSpace(updatedUser.Name))
            {
                throw new ArgumentNullException(nameof(updatedUser.Name), "Il nome del utente non puo essere vuoto");
            }
            
            User? existing = null;
            foreach (var u in _users)
            {
                if (u.Id == id)
                {
                    existing = u;
                    break;
                }
            }

            if (existing == null)
            {
                return false;
            }

            existing.Name = updatedUser.Name;
            existing.Indirizzo = updatedUser.Indirizzo;
            LoggerHelper.Log($"Aggiornato utente : {id}");
            Save();
            return true;
        }
    }
}