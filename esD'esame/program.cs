
string path = @"studenti.txt";

    Console.WriteLine("Ciao! Nome?"); // chiedo il nome allo studente
    string nomeAllievo = Console.ReadLine();// acquisisco la rispost
    Console.WriteLine("Voto");
    int votoAllievo = int.Parse(Console.ReadLine());

Studente nuovoAllievo = new Studente(nomeAllievo, votoAllievo); // creato nuovo oggetto Allievo

Console.WriteLine("Salvato {nuovoAllievo} in {path}");
string contenuto = $"Nome: \n{nuovoAllievo.Nome} \n Voto:{nuovoAllievo.Voto}";

File.AppendAllText(path, contenuto);
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