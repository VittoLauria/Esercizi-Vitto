using Backend.Models; // Importa il namespace Backend.Models per accedere ai modelli definiti in esso
using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper

namespace Backend.Services
{
    public class ProductService
    {
        // Inizializza una lista di prodotti in memoria
        private readonly List<Product> _products; // Inizializza una lista di prodotti in memoria
        private readonly List<Category> _categories; // Inizializza una lista di categorie in memoria
        public ProductService()
        {
            // Carica i prodotti dal file JSON
            _products = JsonFileHelper.LoadList<Product>("Data/products.json");
            // Carica le categorie dal file JSON
            _categories = JsonFileHelper.LoadList<Category>("Data/categories.json");
        }

        // metodo per salvare i prodotti in un file JSON (serializzazione)
        public void Save()
        {
            // Serializza la lista dei prodotti in formato JSON e la salva nel file
            JsonFileHelper.SaveList("Data/products.json", _products);
        }

        // Restituisce tutti i prodotti dato che erano privati _products li rendo pubblici
        // public List<Product> GetAll() => _products; // lambda expression per restituire la lista dei prodotti
        // ciclo in modo da restituire tutti i prodotti

            // metodo per ottenere tutti i prodotti sotto forma di lista
        public List<Product> GetAll()
        //public -> è ul modificatore d accesso che indica che il metodo è accessibile da qualsiasi parte del programma
        // List<Product> -> indica che il metodo restituisce una lista di oggetti di tipo Product
        // GetAll() -> è il nome del metodo che restituisce tutti i prodotti
        {
            List<Product> result = new List<Product>(); // creo una nuova lista di prodotti per restituire i risultati
            foreach (var product in _products)
            {
                result.Add(product); // aggiungo ogni prodotto alla lista dei risultati
            }
            return result;
        }

        // metodo per ottenere un prodotto specifico in base all'ID o null se non lo trova
        // public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id); // lambda expression per trovare il primo prodotto con l'ID specificato
        // oppure con for each invece di LINQ
        public Product? GetById(int id) // metodo per ottenere un prodotto specifico in base all'ID
        {
            foreach (var product in _products)
            {
                if (product.Id == id) // controllo se l'ID del prodotto corrisponde a quello cercato
                {
                    return product; // restituisco il prodotto se trovato
                }
            }
            return null; // Restituisce null se non trovato
        }

        // metodo per aggiungere un nuovo prodotto alla lista
        // CREA (Create)
        public Product Add(Product newProduct)
        {
            // Validazione dei campi del prodotto

            // uso ValidationHelper per validare i campi del prodotto
            /*
            if (newProduct == null)
            {
                throw new ArgumentNullException(nameof(newProduct), "Il prodotto non può essere null");
            }
            if (!ValidationHelper.IsNotNullOrWhiteSpace(newProduct.Name))
            {
                throw new ArgumentException("Il nome del prodotto non può essere vuoto", nameof(newProduct.Name));
            }
            if (!ValidationHelper.IsPositiveDecimal(newProduct.Price))
            {
                throw new ArgumentException("Il prezzo del prodotto deve essere positivo", nameof(newProduct.Price));
            }
            if (newProduct.CategoryId <= 0)
            {
                throw new ArgumentException("Il CategoryId del prodotto deve essere maggiore di 0", nameof(newProduct.CategoryId));
            }
            */
            newProduct.Id = IdGenerator.GetNextId(_products); // Usa IdGenerator per ottenere il prossimo ID
            _products.Add(newProduct); // aggiungo il nuovo prodotto alla lista dei prodotti
            LoggerHelper.Log($"Aggiunto prodotto ID: {newProduct.Id} ({newProduct.Name})");
            Save(); // salvo i cambiamenti nel file JSON
            return newProduct; // restituisco il nuovo prodotto aggiunto
        }

        // metodo per eliminare un prodotto specifico in base all'ID
        // ELIMINA (Delete)
        public bool Delete(int id)
        {
            // Cerco il prodotto da rimuovere
            Product? existing = null; // dichiaro una variabile per il prodotto esistente
            foreach (var p in _products)
            {
                if (p.Id == id) // controllo se l'ID del prodotto corrisponde a quello cercato
                {
                    existing = p; // se trovato, assegno il prodotto esistente alla variabile
                    break; // interrompo il ciclo
                }
            }

            if (existing == null)
            {
                // Non trovato
                return false; // se il prodotto non è stato trovato, restituisco false
            }

            // Rimuovo e ritorno il risultato della rimozione
            bool removed = _products.Remove(existing); // rimuovo il prodotto esistente dalla lista dei prodotti
            if (removed)
            {
                LoggerHelper.Log($"Cancellato prodotto ID: {id}");
            }
            else
            {
                LoggerHelper.Log($"Tentativo di cancellazione fallito per prodotto ID: {id}");
            }
            Save(); // salvo i cambiamenti nel file JSON
            return removed; // restituisco true se il prodotto è stato rimosso con successo, altrimenti false
        }

        // metodo per modificare un prodotto specifico in base all'ID
        // AGGIORNA (Update)
        public bool Update(int id, Product updatedProduct)
        {
            // Cerco il prodotto manualmente
            Product? existing = null; // dichiaro una variabile per il prodotto esistente
            foreach (var p in _products)
            {
                if (p.Id == id) // controllo se l'ID del prodotto corrisponde a quello cercato
                {
                    existing = p; // se trovato, assegno il prodotto esistente alla variabile
                    break; // interrompo il ciclo
                }
            }

            if (existing == null)
            {
                // Non trovato
                return false; // se il prodotto non è stato trovato, restituisco false
            }
            // Sovrascrivo i campi desiderati
            existing.Name = updatedProduct.Name; // aggiorno il nome del prodotto esistente con quello del prodotto aggiornato
            existing.Price = updatedProduct.Price; // aggiorno il prezzo del prodotto esistente con quello del prodotto aggiornato
            LoggerHelper.Log($"Aggiornato prodotto ID: {id} con nuovo nome: {updatedProduct.Name}");
            Save(); // salvo i cambiamenti nel file JSON
            return true; // restituisco true se il prodotto è stato aggiornato con successo
        }

    }
}