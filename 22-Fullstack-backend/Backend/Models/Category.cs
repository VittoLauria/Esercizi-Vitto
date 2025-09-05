using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper
using System.ComponentModel.DataAnnotations; // Importa il namespace per i decoratori
namespace Backend.Models // Backend/Models/Product.cs
{
    public class Category : IIdentifiable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome della categoria è obbligatorio.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Il nome deve essere lungo almeno 2 caratteri.")]
        public string Name { get; set; }
    }
}