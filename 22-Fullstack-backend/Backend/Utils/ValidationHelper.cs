namespace Backend.Utils
{
    public static class ValidationHelper
    {
        // Verifica che una stringa non sia null o vuota
        public static bool IsNotNullOrWhiteSpace(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        // verifica che la stringa sia un indirizzo email valido
        public static bool IsValidEmail(string email)
        {
            return email.Contains("@"); // Semplice esempio verifica che contenga '@'
        }

        // Verifica che un prezzo sia positivo
        public static bool IsPositiveDecimal(decimal value)
        {
            return value > 0;
        }

        // Verifica che un CAP sia valido (5 cifre)
        // verifica che non sia vuoto
        // verifica che sia lunghezza 5
        // verifica che sia un numero
        public static bool IsValidCAP(string cap)
        {
            // se voglio uso Parse senza out _ ma in questo caso non mi serve perche non mi interessa il valore numerico
            return !string.IsNullOrWhiteSpace(cap) &&
            cap.Length == 5 &&
            int.TryParse(cap, out _);
        }
    }
}