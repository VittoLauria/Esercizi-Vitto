using Backend.Models;

namespace Backend.Services
{
    public class PurchaseService
    {
        // Lista privata di acquisti (in memoria)
        private readonly List<Purchase> _purchases = new();

        // Restituisce tutti gli acquisti
        public List<Purchase> GetAll()
        {
            return new List<Purchase>(_purchases); // restituisce una copia della lista
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
            return newPurchase;
        }

        // Elimina un acquisto per ID
        public bool Delete(int id)
        {
            var purchase = GetById(id);
            if (purchase == null)
                return false;

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

            return true;
        }
    }
}