using Backend.Models;
using Backend.Utils;

namespace Backend.Services
{
    public class PurchaseService
    {
        // Lista privata di acquisti (in memoria)
        private readonly List<Purchase> _purchases = new List<Purchase>();
        public PurchaseService()
        {
            _purchases = JsonFileHelper.LoadList<Purchase>("Data/Purchase.json");
        }
        public void Save()
        {
            JsonFileHelper.SaveList<Purchase>("Data/purchases.json", _purchases);
        }
        // Restituisce tutti gli acquisti
        public List<Purchase> GetAll()
        {
            List<Purchase> purchaseList = new List<Purchase>();
            foreach (var purchase in _purchases)
            {
                purchaseList.Add(purchase);
            }

            return purchaseList;// restituisce una copia della lista
        }

        // Restituisce un acquisto specifico per ID
        public Purchase? GetById(int id)
        {
            foreach (var p in _purchases)
            {
                if (p.Id == id)
                    return p;
            }
            return null;
        }

        // Aggiunge un nuovo acquisto
        public Purchase Add(Purchase newPurchase)
        {
            // Calcolo nuovo ID
            int nextId = _purchases.Count > 0 ? _purchases.Max(p => p.Id) + 1 : 1;
            newPurchase.Id = nextId;
            newPurchase.PurchaseDate = DateTime.Now;
            _purchases.Add(newPurchase);
            LoggerHelper.Log($"aggiunto purchase: ID: {newPurchase.Id} {newPurchase.UserId})");
            Save();
            return newPurchase;
        }

        // Elimina un acquisto per ID
        public bool Delete(int id)
        {
            var purchase = GetById(id);
            if (purchase == null)
                return false;
            bool removed = _purchases.Remove(purchase);
            if (removed)
            {
                LoggerHelper.Log($"Cancellato prodotto Id: {id}");
            }
            else
            {
                LoggerHelper.Log($"Prodotto non cancellato Id: {id}");
            }
             return _purchases.Remove(purchase);
        }

        // Aggiorna un acquisto esistente
        public bool Update(int id, Purchase updatedPurchase)
        {
            var existing = GetById(id);
            if (existing == null)
                return false;

            existing.UserId = updatedPurchase.UserId;
            existing.ProductId = updatedPurchase.ProductId;
            existing.Quantity = updatedPurchase.Quantity;
            existing.PurchaseDate = updatedPurchase.PurchaseDate;
             LoggerHelper.Log($"Aggiornato purchase : {id}");
            Save();
            return true;
        }
    }
}