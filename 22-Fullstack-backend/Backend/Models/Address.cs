using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper
using System.ComponentModel.DataAnnotations; // Importa il namespace per i decoratori
namespace Backend.Models
{
    public class Address
    {
        [Required(ErrorMessage = "La città è obbligatoria.")]
        [StringLength(50)]
        public string Citta { get; set; }

        [Required(ErrorMessage = "La via è obbligatoria.")]
        [StringLength(100)]
        public string Via { get; set; }

        [Required(ErrorMessage = "Il CAP è obbligatorio.")]
        [StringLength(5, ErrorMessage = "Il CAP non può superare i 5 caratteri.")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Il CAP deve essere un numero di 5 cifre.")]
        [DataType(DataType.PostalCode)]
        public string CAP { get; set; }
    }
}