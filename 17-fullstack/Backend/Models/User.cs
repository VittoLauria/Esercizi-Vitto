using Backend.Utils;

namespace Backend.Models

{
    public class User : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Indirizzo { get; set; }
    }
}