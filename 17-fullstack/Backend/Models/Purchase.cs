namespace Backend.Models
{
    public class Purchase
    {
        public int Id { get; set; } // identificativo univoco del purchase
        public int UserId { get; set; } // identificativo dell'utente che ha effettuato l'acquisto
        public int ProductId { get; set; } // identificativo del prodotto acquistato
        public int Quantity { get; set; }  
        public DateTime PurchaseDate { get; set; }
    }
}