# FullStack Versione 2
In questa versione l'obbiettivo è implementare un servizio che prenda i contenuti da un file Json invece che da una lista interna(attualmente i dati vengono presi da ProductService quindi ogni volta che lanciamo l'applicazione le modifiche gli inserimenti ecc vengono resettati)
Quindi assicurare la persistenza dei dati in questa app.
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
    "ascoltato": false
}

// SPIEGAZIONE PROGRAMMA
Questo programma legge i dati di una collezione di Album musicali da un file Json
-Utilizziamo le classi Album.cs e Canzone.cs per rappresentare i dati 
-Creiamo i servizi che il programma sara in grado di gestire.(Albumservice,AlbumController)
-I servizi all'intenro contengono le varie funzioni che servono al computer per far funzionare correttamente il programma 

#  Album – Gestione Album Musicali

Questo progetto è una Web API realizzata in **C#** con **ASP.NET Core**, che permette la gestione di una libreria di **album musicali** e delle rispettive **canzoni**, con funzionalità per aggiungere, modificare, rimuovere e marcare le canzoni come *preferite*.

---

## 🛠️ Funzionalità principali

###  Album
- `GET /api/albums`  
  Restituisce l'elenco completo degli album presenti.

- `GET /api/albums/{id}`  
  Restituisce un singolo album in base al suo `id`.

- `POST /api/albums`  
  Aggiunge un nuovo album. Richiede un oggetto `Album` con campi `Titolo`, `Autore`, `Anno`, `Genere`, ecc.

- `PUT /api/albums/{id}`  
  Aggiorna i dati di un album esistente.

- `DELETE /api/albums/{id}`  
  Elimina un album in base all’`id`.

---

###  Utenti
- `GET /api/utenti`  
  Restituisce l'elenco completo degli utenti presenti.

- `GET /api/utenti/{id}`  
  Restituisce un singolo utente in base al suo `id`.

- `POST /api/utenti`  
  Aggiunge un nuovo utente. Richiede un oggetto `Utente` con campi `Nome`, `Eta`, `Anno Di Nascita`, `Indirizzo`, ecc.

- `PUT /api/utenti/{id}`  
  Aggiorna i dati di un utente esistente.

- `DELETE /api/utenti/{id}`  
  Elimina un utente in base all’`id`.

---

```csharp
public bool InPreferiti { get; set; }
```

Questa proprietà può essere utilizzata per marcare una canzone come *preferita*.

---

###  Funzionalità preferiti(In fase di lavoro)

- `POST /api/albums/preferiti`  
  Questo endpoint salva tutte le **canzoni preferite** (cioè quelle con `InPreferiti == true`) in un file JSON chiamato `Preferiti.json`. Il file viene salvato all’interno del progetto (nella cartella `Data` ).

Esempio di struttura del file:

```json
[
  {
    "Id": 2,
    "Titolo": "Cleanin' Out My Closet",
    "Durata": 4.6,
    "InPreferiti": true
  },
  {
    "Id": 3,
    "Titolo": "Stavo pensando a te",
    "Durata": 3.47,
    "InPreferiti": true
  }
]
```

---

## 🧱 Struttura del progetto

- `Models/Album.cs`  
  Definizione della classe `Album`.

- `Models/Canzone.cs`  
  Definizione della classe `Canzone`.

  - `Models/Utente.cs`  
  Definizione della classe `Utente`.

- `Services/AlbumService.cs`  
  Logica di gestione dei dati degli album e delle canzoni.

- `Services/UtenteService.cs`  
  Logica di gestione dei dati degli utenti e delle specifiche del suo indirizzo.

- `Controllers/AlbumController.cs`  
  Espone tutti gli endpoint della Web API per quanto riguarda gli album.

- `Controllers/UtenteController.cs`  
  Espone tutti gli endpoint della Web API per quanto riguarda gli utenti.

- `Album.json`  
  File generato con tutti gli album e le relative canzoni.

- `Utenti.json`  
  File generato con tutti gli utenti.

- `Preferiti.json`  
  File generato con le canzoni preferite.

---

## 📦 Requisiti

- .NET 6.0 o superiore
- Visual Studio o VS Code
- Postman o altro client per testare le API

---