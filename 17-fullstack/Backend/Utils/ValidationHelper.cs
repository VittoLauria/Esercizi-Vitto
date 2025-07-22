using Backend.Models;
namespace Backend.Utils
{
    public static class ValidationHelper
    {
        // metodo che verifica che la stringa non sia null o vuota
        public static bool IsNotNullOrWhiteSpace(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
        // metodo che verifica che la stringa sia un indirrizzo valido
        public static bool IsValidEmail(string email)
        {
            return email.Contains("@"); // semplice esempio che verifica se e presente la ghiocciola
        }
        // metodo che verifica che un prezzo sia positivo
        public static bool IsPostitiveDecimal(decimal value)
        {
            return value > 0;
        }
        // metodo che verifica che un CAP sia vlido (5 cifre)
        // verifica che non isa vuoto
        // verifica che sia di lunghezza 5
        // verifica che sia un numero
        public static bool IsValidCap(string cap)
        {
            return !string.IsNotNullOrWhiteSpace(cap) && cap.Length == 5 && int.TryParse(cap, out _);
        }
        // metodo che verifica che un inidrizzo cioe composto da citta,cap e via non nulli o vuoti

        /*
        public static bool IsValidAddress(Models.Indirizzo address)
        {
            IsNotNullOrWhiteSpace(address.Citta) &&
            IsNotNullOrWhiteSpace(address.Via) &&
            IsValidCap(address.Cap);
        }
        */
    }
}