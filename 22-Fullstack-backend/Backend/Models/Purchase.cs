using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper
using System.ComponentModel.DataAnnotations; // Importa il namespace per i decoratori
namespace Backend.Models
{
    public class Purchase : IIdentifiable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'utente è obbligatorio.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Il prodotto è obbligatorio.")]
        public int ProductId { get; set; }

        [Range(1, 9999, ErrorMessage = "La quantità deve essere almeno 1.")]
        public int Quantity { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PurchaseDate { get; set; }
    }
}