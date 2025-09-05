namespace Backend.Utils
{
    public static class IdGenerator
    {
        // Questo metodo calcola il prossimo ID disponibile per una lista di oggetti che implementano IIdentifiable
        // sfrutto l ereditarieta per evitare di ripetere il codice in ogni servizio
        public static int GetNextId<T>(List<T> items) where T : IIdentifiable
        {
            // Se la lista è vuota, il prossimo ID sarà 1
            if (items.Count == 0)
                return 1;

            // Altrimenti, trova il massimo ID esistente e restituisci il prossimo ID
            int maxId = 0;
            foreach (var item in items)
            {
                // Controlla se l'ID dell'elemento corrente è maggiore del massimo trovato finora
                if (item.Id > maxId)
                    maxId = item.Id;
            }
            // Restituisco il prossimo ID disponibile
            return maxId + 1;
        }
    }
    // questo modello deve essere implementato da tutti i modelli che hanno un ID
    public interface IIdentifiable
    {
        int Id { get; set; }
    }
}