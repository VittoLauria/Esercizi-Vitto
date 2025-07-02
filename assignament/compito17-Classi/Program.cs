// SENZA CLASSE
/*using Newtonsoft.Json.Linq;

string json = @"{
""AnnoImmatricolazione"": 2023,
""Marca"": ""Fiat"",
""Modello"": ""500X"",                                                          Punto1
""Assicurazione"": true,
}";

JObject auto1 = JObject.Parse(json);

Console.WriteLine($"Anno di immatricolazione: {auto1["AnnoImmatricolazione"]}");
Console.WriteLine($"Marca: {auto1["Marca"]}");
Console.WriteLine($"Modello: {auto1["Modello"]}");
Console.WriteLine($"L'assicurazione è: {auto1["Assicurazione"]}");
*/
// CON CLASSE
/*
using Newtonsoft.Json;



string json2 = @"{
""AnnoImmatricolazione"": 2022,                                                        Punto2
""Marca"": ""BMW"",
""Modello"": ""M3"",
""Assicurazione"": true,
}";

Console.WriteLine($"Anno di immatricolazione : {auto2.AnnoImmatricolazione}");
Console.WriteLine($"Anno di pubblicazione : {auto2.Marca}");
Console.WriteLine($"Genere : {auto2.Modello}");
Console.Writeline($"L'Assicurazione è: {(auto2.Assicurazione ? "Valida" : "Scaduta")}");

Automobile auto2 = JsonConvert.DeserializeObject<Automobile>(json2);
public class Automobile
{
    public int AnnoImmatricolazione { get; set; }
    public string Marca { get; set; }
    public string Modello { get; set; }
    public bool Assicurazione { get; set; }
}
*/
// CON COSTRUTTORI
using Newtonsoft.Json;

Automobile auto3 = new Automobile(2015, "AlfaRomeo", "Giulia", false) ;

 // creo un auto personalizzata

Console.WriteLine($"Anno di immatricolazione : {auto3.AnnoImmatricolazione}");
Console.WriteLine($"Marca : {auto3.Marca}");
Console.WriteLine($"Modello : {auto3.Modello}");
Console.WriteLine($"L'Assicurazione è: {(auto3.Assicurazione ? "Valida" : "Scaduta")}");





public class Automobile
{
    public int AnnoImmatricolazione { get; set; }
    public string Marca { get; set; }               // Proprieta pubbliche accessibile tramite i metodi get e set
    public string Modello { get; set; }
    public bool Assicurazione { get; set; }

    // costruttore di default
    public Automobile()
    {
        // inizializza i valori di default deve essere senza parametri
        AnnoImmatricolazione = 0;
        Marca = "auto";
        Modello = "N/A";
        Assicurazione = false;
    }
     // definiscio il costruttore che si chiamera come la classe senza pero il tipo di ritorno
    public Automobile(int annoImmatricolazione, string marca, string modello , bool assicurazione)
    {//qui inizializzo le proprieta con i valori passati
        AnnoImmatricolazione = annoImmatricolazione;
        Marca = marca;
        Modello = modello;
        Assicurazione = assicurazione;
    }
}