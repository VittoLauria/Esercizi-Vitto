# FullStack Versione 2
In questa versione l'obbiettivo è implementare un servizio che prenda i contenuti da un file Json invece che da una lista interna(attualmente i dati vengono presi da ProductService quindi ogni volta che lanciamo l'applicazione le modifiche gli inserimenti ecc vengono resettati),quindi assicurare la persistenza dei dati in questa app.
Il file json che contiene i dati è organizzato come una lista di oggetti(simili a dizionari).
Il file json verra deserializzato una classe Album con le seguenti proprietà(ID(int,generato automaticamente),Titolo(string),  Anno(int), Autore(string), canzoni(List<string>), Genere(string), Ascoltato(bool))
In questa versione non e necessario avere una gestione dell input dell'utente dato che lo scopo e quello di servire i dati al frontend tramite un servizio http
L'applicazione deve essere in grado di generare un id progressivo basandosi sugli album presenti nel file json(ultimo id + 1) 
Il servizio ovra implementare i seguenti endpoint:
-GET/albums = ottenere elenco album
-GET/albums/{id}
-POST/album = aggiunge nuovo album
-PUT/albums = aggiorna un album
-DELETE/albums/{id} = cancella un album

CURL
Devono essere implementati i comandi principali per testare il servizio
POST/Get/PUT/DELETE
Es comandi curl
curl -X POST http://localhost:5000/albums
-H "Content-Type: application/json"\
-d '{
    "id": 1,
    "titolo": "Album",
    "anno": 2023,
    "autore": "Artista Test",
    "canzoni": ["Canzone1", "Canzone 2"],
    "genere": "Pop",
    "acoltato": false
}