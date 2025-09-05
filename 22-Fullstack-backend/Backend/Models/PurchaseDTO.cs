namespace Backend.Models
{
    public class PurchaseDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }

        public string ProductCategory { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}