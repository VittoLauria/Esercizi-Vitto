// Prove di un dizionario con giocatori

Dictionary<int, List<string>> giocatoriSturla = new Dictionary <int, List<string>>()
{
    {1, new List<string> {"Vittorio", "19 anni", "sinisto", "attacante"} },
    {2, new List<string> {"Luca","22 anni", "destro", "portiere"} },
    {3, new List<string> {"Edoardo", "33 anni", "destro", "difensore"} },
    {4, new List<string> {"Sebastiano", "23 anni", "destro", "terzino"} }
};

giocatoriSturla[1].Add("Leader");
giocatoriSturla[2].Add("Promettente");
giocatoriSturla[3].Add("Gatto");
giocatoriSturla[4].Add("TrenoDaCorsa");

foreach (var caratteristiche in giocatoriSturla)
{
    Console.WriteLine($"Giocatore: {caratteristiche.Key}, Caratteristiche: {string.Join(", ", caratteristiche.Value)}");
} 
