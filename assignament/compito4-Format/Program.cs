/*
string [] nomi = { "Alberto", "Luca", "Alessio" };
int [] eta = { 18, 35, 80, };
int i = 0;
string frase;

foreach (var n in nomi)
{
    frase = string.Format("{0} ha {1} anni", nomi[i], eta[i]);
    Console.WriteLine(frase);
    i++;
}
*/

Dictionary<string, int> classe = new Dictionary<string, int>()

{
  { "Alberto", 18 },
  { "Luca",  35 },
  { "Alessio", 80 }
};
foreach (var c in classe)
{
    string frase = string.Format("{0} ha {1} anni.", c.Key, c.Value);
    Console.WriteLine(frase);
}