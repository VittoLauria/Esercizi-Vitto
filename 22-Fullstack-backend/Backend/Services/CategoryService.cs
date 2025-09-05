using Backend.Models;
using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper

namespace Backend.Services
{
    public class CategoryService
    {
        private readonly List<Category> _categories;

        public CategoryService()
        {
            // Carica le categorie dal file JSON
            _categories = JsonFileHelper.LoadList<Category>("Data/categories.json");
        }

        public void Save()
        {
            // Serializza la lista delle categorie in formato JSON e la salva nel file
            JsonFileHelper.SaveList("Data/categories.json", _categories);
        }

        public List<Category> GetAll()
        {
            List<Category> result = new List<Category>();
            foreach (var cat in _categories)
            {
                result.Add(cat);
            }
            return result;
        }

        public Category GetById(int id)
        {
            foreach (var cat in _categories)
            {
                if (cat.Id == id)
                    return cat;
            }
            return null;
        }

        public Category Add(Category newCategory)
        {
            newCategory.Id = IdGenerator.GetNextId(_categories); // Usa IdGenerator per ottenere il prossimo ID
            _categories.Add(newCategory); // aggiungo la nuova categoria alla lista delle categorie
            // Log aggiunta della categoria
            LoggerHelper.Log($"Aggiunta categoria ID: {newCategory.Id} ({newCategory.Name})");
            Save(); // salvo i cambiamenti nel file JSON
            return newCategory; // restituisco la nuova categoria aggiunta
        }

        public bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing == null)
                return false;

            bool removed = _categories.Remove(existing); // rimuovo la categoria esistente dalla lista delle categorie
            if (removed)
            {
                LoggerHelper.Log($"Cancellata categoria ID: {id}");
            }
            else
            {
                LoggerHelper.Log($"Tentativo di cancellazione fallito per categoria ID: {id}");
            }
            Save(); // salvo i cambiamenti nel file JSON
            return removed; // restituisco true se la categoria è stata rimossa con successo, altrimenti false
        }
        
        public bool Update(int id, Category updatedCategory)
        {
            var existing = GetById(id);
            if (existing == null)
                return false;

            // Sovrascrivo i campi desiderati
            existing.Name = updatedCategory.Name; // aggiorno il nome della categoria esistente con quello della categoria aggiornata
            LoggerHelper.Log($"Aggiornata categoria ID: {id} con nuovo nome: {updatedCategory.Name}");
            Save(); // salvo i cambiamenti nel file JSON
            return true; // restituisco true se la categoria è stata aggiornata con successo
        }
    }
}