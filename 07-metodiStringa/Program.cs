string numeroDaConvertire = "10";
int numeroConvertito;
bool conversione = int.TryParse(numeroDaConvertire, out numeroConvertito);
Console.WriteLine(conversione); // output: true
Console.WriteLine(numeroConvertito); // output: 10