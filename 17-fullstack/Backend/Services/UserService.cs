using Backend.Models;

namespace Backend.Services
{
    public class UserService
    {
        private readonly List<User> _users = new()
        {
            new User { Id = 1, Name = "User uno", Indirizzo = "Via roma 1" },
            new User { Id = 2, Name = "User due", Indirizzo = "Via milano 2" },
        };
        private int _nextId = 3;
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
            int nextId;
            if (_users.Count > 0)
            {
                int maxId = 0;
                foreach (var u in _users)
                {
                    if (u.Id > maxId)
                    {
                        maxId = u.Id;
                    }
                }
                nextId = maxId + 1;
            }
            else
            {
                nextId = 1;
            }

            newUser.Id = nextId;
            _users.Add(newUser);
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
            return removed;
        }

        public bool Update(int id, User updatedUser)
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

            existing.Name = updatedUser.Name;
            existing.Indirizzo = updatedUser.Indirizzo;

            return true;
        }
    }
}