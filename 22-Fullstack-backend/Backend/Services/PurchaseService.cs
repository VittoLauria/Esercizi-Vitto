using Backend.Models;
using System.Collections.Generic;
using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper

namespace Backend.Services
{
    public class PurchaseService
    {
        private readonly List<Purchase> _purchases;
        public PurchaseService()
        {
            // Carica gli acquisti dal file JSON
            _purchases = JsonFileHelper.LoadList<Purchase>("Data/purchases.json");
        }

        public void Save()
        {
            // Serializza la lista degli acquisti in formato JSON e la salva nel file
            JsonFileHelper.SaveList("Data/purchases.json", _purchases);
        }

        public List<Purchase> GetAll()
        {
            List<Purchase> result = new List<Purchase>();
            foreach (Purchase purchase in _purchases)
            {
                result.Add(purchase);
            }
            return result;
        }

        public Purchase GetById(int id)
        {
            foreach (Purchase purchase in _purchases)
            {
                if (purchase.Id == id)
                {
                    return purchase;
                }
            }
            return null;
        }

        public Purchase Add(Purchase newPurchase)
        {
            _purchases.Add(newPurchase);
            // Log aggiunta dell'acquisto
            LoggerHelper.Log($"Aggiunto acquisto ID: {newPurchase.Id} (Utente ID: {newPurchase.UserId}, Prodotto ID: {newPurchase.ProductId}, Quantità: {newPurchase.Quantity})");
            Save(); // salvo i cambiamenti nel file JSON
            return newPurchase;
        }

        public bool Delete(int id)
        {
            Purchase existing = null;
            foreach (Purchase purchase in _purchases)
            {
                if (purchase.Id == id)
                {
                    existing = purchase;
                    break;
                }
            }
            if (existing == null)
            {
                return false;
            }
            bool removed = _purchases.Remove(existing);
            if (removed)
            {
                LoggerHelper.Log($"Cancellato acquisto ID: {id}");
            }
            else
            {
                LoggerHelper.Log($"Tentativo di cancellazione fallito per acquisto ID: {id}");
            }
            Save(); // salvo i cambiamenti nel file JSON
            return removed;
        }

        public bool Update(int id, Purchase updatedPurchase)
        {
            Purchase existing = null;
            foreach (Purchase purchase in _purchases)
            {
                if (purchase.Id == id)
                {
                    existing = purchase;
                    break;
                }
            }
            if (existing == null)
            {
                return false;
            }

            existing.UserId = updatedPurchase.UserId;
            existing.ProductId = updatedPurchase.ProductId;
            existing.Quantity = updatedPurchase.Quantity;
            existing.PurchaseDate = updatedPurchase.PurchaseDate;
            LoggerHelper.Log($"Aggiornato acquisto ID: {id} (Utente ID: {updatedPurchase.UserId}, Prodotto ID: {updatedPurchase.ProductId}, Quantità: {updatedPurchase.Quantity})");
            Save(); // salvo i cambiamenti nel file JSON
            return true;
        }
    }
}