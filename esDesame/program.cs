
string path = @"studenti.txt";
bool continua = true;
while (continua)
{
    Console.WriteLine("Ciao! Nome?"); // chiedo il nome allo studente
    string nomeAllievo = Console.ReadLine();// acquisisco la rispost
    Console.WriteLine("Voto");
    int votoAllievo = int.Parse(Console.ReadLine());
    Studente nuovoAllievo = new Studente(nomeAllievo, votoAllievo); // creato nuovo oggetto Allievo

    Console.WriteLine($"Salvato {nuovoAllievo.Nome} voto: {nuovoAllievo.Voto} in {path}");
    string contenuto = $"\nNome: {nuovoAllievo.Nome} \n Voto:{nuovoAllievo.Voto}";

    File.AppendAllText(path, contenuto);
    Console.WriteLine("Vuoi continuare? si/no");
    string risposta = Console.ReadLine().ToLower();
    if (risposta == "n" || risposta == "no")
    {
        continua = false;
    }
}
    Console.WriteLine("Inserimento terminato!");

public class Studente
{
    public string Nome { get; set; }
    public int Voto { get; set; }

    public Studente(string nome, int voto)
    {
        this.Nome = nome;
        this.Voto = voto;
    }
}