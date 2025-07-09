public class Calcolatrice
{
    public int Somma(int a, int b)
    {
        return a + b;
    }
    public int Sottrazione(int a, int b)
    {
        return a - b;
    }
    public int Moltiplicazione(int a, int b)
    {
        return a * b;
    }
    public int Divisione(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Divisione per zero non è permessa.");
        }
        return a / b;
    }
}