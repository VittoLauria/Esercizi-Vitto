using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper
using System.ComponentModel.DataAnnotations; // Importa il namespace per i decoratori
namespace Backend.Models
{
    public class User : IIdentifiable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Il nome deve essere lungo almeno 3 caratteri.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "L'indirizzo è obbligatorio.")]
        public Address Address { get; set; }
    }
}