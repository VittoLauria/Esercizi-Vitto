
namespace Backend.Utils
{
    public static class IdGenerator
    {
        // questo metotdo calcola il prossimo id disponibile per una lista di oggetti generici che implemenatano IIdntifialbe
        // sfrutto lereditarieta per evitare di ripetere il codice in ogni servizio
        public static int GetNextId<T>(List<T> items) where T : IIdentifiable
        {
            // se la lista e vuota
            if (items.Count == 0)
                return 1;
            // altrimennti trova il masssimo id esistente
            int maxId = 0;
            foreach (var item in items)
            {
                if (item.Id > maxId)
                    maxId = item.Id;
            }
            return maxId + 1;
        }

    }
      // questo modello deve essere implemenatato da tutti i modelli che hanno un Id
        public interface IIdentifiable
        {
            int Id { get; set; }
        }
}
