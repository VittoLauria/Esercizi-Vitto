// iniziallizzo un dizionaro per i partecipanti

Dictionary<string, DateTime> partecipanti = new Dictionary<string, DateTime>();

string nome;
string dataNascita;

while (true)
{
    // chiedo all'utente di inserire nome e data di nascita
    Console.WriteLine("Ciao,come ti chiami ?");
    nome = Console.ReadLine();
    Console.WriteLine("Quando sei nato?");
    dataNascita = Console.ReadLine();

    if (nome == "fine")
    {
        break;
    }
    partecipanti.Add(nome, dataNascita);

}
foreach(var caratteristiche in partecipanti)
{
    Console.WriteLine($"Nome: {caratteristiche.Key}, Data di nascita: {DateTime.Parse(", ", caratteristiche.Value)}");
}
