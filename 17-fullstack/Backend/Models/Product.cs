using Backend.Utils;
namespace Backend.Models // Backend/Models/Product.cs
{
    public class Product : IIdentifiable// public indica che la classe è accessibile a tutto il programma
    {
        // i metodi get e set sono utilizzati per accedere e modificare le proprietà della classe (i valori)
        public int Id { get; set; } // i metodi e le proprietà sono pubblici per essere accessibili da altri componenti
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}