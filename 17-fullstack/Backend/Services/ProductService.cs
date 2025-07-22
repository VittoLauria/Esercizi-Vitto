using Backend.Models; // Importa il namespace Backend.Models per accedere ai modelli definiti in esso
using Backend.Utils;
namespace Backend.Services
{
    public class ProductService
    {
        // Inizializza una lista di prodotti in memoria
        private readonly List<Product> _products = new() // Inizializza una lista di prodotti in memoria
        // definisco privata la _list di prodotti perche voglio che sia accessibile solo all'interno di questa classe
        // in pratica voglio che l elenco dei prodotti sia accessibile solo all'interno di questa classe
        // uso l underscore prima del nome dell oggetto _products per indicare che è un campo privato (è una convenzione)
        {
            // elenco dei prodotti iniziali
            new Product { Id = 1, Name = "Penna", Price = 1.20M },
            new Product { Id = 2, Name = "Quaderno", Price = 2.50M }
        };
        public ProductService()
        {
            _products = JsonFileHelper.LoadList<Product>("Data/products.json");
        }
        public void Save()
        {
            JsonFileHelper.SaveList<Product>("Data/products.json", _products);
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
            // Uso ValidationHelper per validare i campi del prodotto
            if (newProduct == null)
            {
                throw new ArgumentNullException(nameof(newProduct), "Il prodotto non puo essere null");
            }
            if (!ValidationHelper.IsNotNullOrWhiteSpace(newProduct.Name))
            {
                throw new ArgumentNullException(nameof(newProduct.Name), "Il nome del prodotto non puo essere vuoto");
            }
             if (!ValidationHelper.IsPostitiveDecimal(newProduct.Price))
            {
                throw new ArgumentNullException(nameof(newProduct.Price), "Il prezzo del prodotto deve essere positivo");
            }
            newProduct.Id = IdGenerator.GetNextId(_products); // assegno il prossimo ID al nuovo prodotto
            _products.Add(newProduct); // aggiungo il nuovo prodotto alla lista dei prodotti
            LoggerHelper.Log($"aggiunto prodotto: ID: {newProduct.Id} ({newProduct.Name})");
            Save();
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
                LoggerHelper.Log($"Cancellato prodotto Id: {id}");
            }
            else
            {
            LoggerHelper.Log($"Prodotto non cancellato Id: {id}");
           }
            Save();

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
            if (updatedProduct == null)
            {
                throw new ArgumentNullException(nameof(updatedProduct), "Il prodotto non puo essere null");
            }
            if (!ValidationHelper.IsNotNullOrWhiteSpace(updatedProduct.Name))
            {
                throw new ArgumentNullException(nameof(updatedProduct.Name), "Il nome del prodotto non puo essere vuoto");
            }
             if (!ValidationHelper.IsPostitiveDecimal(updatedProduct.Price))
            {
                throw new ArgumentNullException(nameof(updatedProduct.Price), "Il prezzo del prodotto deve essere positivo");
            }
            // Sovrascrivo i campi desiderati
            existing.Name = updatedProduct.Name; // aggiorno il nome del prodotto esistente con quello del prodotto aggiornato
            existing.Price = updatedProduct.Price; // aggiorno il prezzo del prodotto esistente con quello del prodotto aggiornato
            LoggerHelper.Log($"Aggiornato prodotto : {id}");
            Save();
            return true; // restituisco true se il prodotto è stato aggiornato con successo
        }

    }
}