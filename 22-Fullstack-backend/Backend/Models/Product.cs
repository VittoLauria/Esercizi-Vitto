using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper
using System.ComponentModel.DataAnnotations; // Importa il namespace per i decoratori
namespace Backend.Models // Backend/Models/Product.cs
{
    public class Product : IIdentifiable // public indica che la classe è accessibile a tutto il programma
    {
        // i metodi get e set sono utilizzati per accedere e modificare le proprietà della classe (i valori)
        [Key]
        public int Id { get; set; } // i metodi e le proprietà sono pubblici per essere accessibili da altri componenti
        
        [Required(ErrorMessage = "Il nome è obbligatorio.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Il nome non può superare i 20 caratteri.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Il prezzo è obbligatorio.")]
        [Range(0.01, 10000, ErrorMessage = "Il prezzo deve essere compreso tra 0.01 e 10000.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La categoria è obbligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La categoria deve essere valida.")]
        public int CategoryId { get; set; }
    }
}