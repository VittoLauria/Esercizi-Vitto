# JSON MANAGER
Il programma deve permettere di gestire una serie di file json dentro ad una folder specifica.

## il programma deve permettere di:
-Aggiungere un nuovo file json
-Modificare i campi disponibile e quantita di un file json specifico
-Eliminare un file json specifico
-Visualizzare un elenco dei file json presenti nella cartella 
-Visualizzare il contenuto di un file json specifico
-Visualizzare i prodotti disponibili divisi per categoria e per magazzino

## Requisiti:
-Il programma deve chiedere all'utente un azione tra quelle disponibili (quindi deve esserci un menu delle azioni disponibili)
-Il programma deve essere organizzato in funzioni 
-il programma deve deserializzare i dati dei files in oggetti json 
-Gli oggetti devono essere rappresentati da classi con le proprieta accessibili tramite i get e set
-Il programma deve usare i metodi di file in modo da poter leggere e scrivere i file
-Ogni file json deve avere come nome l'id univoco del prodotto
-Una funzione deve essere dedicata alla generazione di un id univoco per il file json
-Il programma deve essere in grado di gestire eventuali errori 
-Il programma deve essere in grado di visualizzare i prodotti disponibili divisi per categoria e per magazzino
-Deve essre presente un file readme con la descrizione di cosa fa ogni funzine e di come lo fa

## Esempio file json
```json
prodotti/12345.json
{
    "codice": "12345",
    "nome" : "Prodotto 1",
    "disponibile": true,
    "quantita": 100,
    "categorie" : ["Elettroncia", "Computer"]
    "posizione" : {
        "magazzino": "magazzino-1",
        "scaffale": 20
    }
}

Descrizione funzioni e utilizzi

Inserisco per prime le funzioni che mi servono:
1 Aggiungi un nuovo prodotto:dove chiedo all'utente di inserire le varie informazioni sul prodotto e crea l'oggetto.
2 Modifica disponibilita e quantita: chiedo l'id del prodotto controllo che il file esista,se esiste legge il file json e deserializzo loggetto,poi chiede i nuovi valori e li aggiorna
3 Elimina prodotto: chiedo l'id e verrifico se esiste il file,se esiste lo cancella
4 Elenco prodotti; mostra tutti i file json presenti nella cartella
5 Visualizza contenuto di un prodotto:Chiedo l'id poi lo legge e stampa il contenuto del file json formattato
6 Visualizza prodotti per categoria: Carica i prodotti, se un prodotto è disponibile lo aggiuge ad una lista per categoria,poi stampa ogni categoria con i prodotti
7 Visualizza per magazzino: Carica i prodotti, se un prodotto è disponibile lo aggiunge e stmpa ogni magazzino con i prodotti e le quantità