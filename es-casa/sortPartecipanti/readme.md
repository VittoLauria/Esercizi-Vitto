###SORTEGGIO PARTECIPANTI
Il programma deve permettere di:

Aggiungere un partecipante con nome e data di nascita acquisendolo dall input dell utente.
//La data di nascita deve essere convertita da stringa ad oggetto DateTime in modo da poter essere utilizzata successivamente.
Sorteggiare un partecipante tra quelli inseriti con la condizione che il partecipante deve avere almeno 18 anni.
Visualizzare il nome del partecipante sorteggiato e la sua data di nascita.
L utente deve digiitare la parola fine per terminare l inserimento dei partecipanti.

#Concetti chiave

-Utilizzo della classe DateTime per gestire le date.
-Utilizzo di un dizionario <string, DateTime> per memorizzare i partecipanti.
-Utilizzo dei cicli per gestire le operazioni di aggiunta e sorteggio.
-Utilizzo di metodi per aggiungere Add e sorteggiare Random i partecipanti.
-Utilizzo di condizioni per verificare l'età del partecipante.
-Utilizzo dei metodi di console per acquisire input dall'utente e visualizzare i risultati.

#Suggerimenti

-Usare i metodi di manipolazione delle stringhe tipo ToLower() per gestire l'input dell'utente.
-Usare Key e Value del dizionario per accedere ai partecipanti.
-Considerare solo l'anno corrente includendo i partecipanti che compiono 21 anni a dicembre, anche se oggi è maggio.