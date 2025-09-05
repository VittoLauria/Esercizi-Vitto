# FULLSTACK

Prerequisiti

Node.js (v18+) + Angular CLI (npm install -g @angular/cli)

# Come funziona

**Architettura generale della mini-app**

La soluzione si compone di due progetti distinti, ognuno con responsabilità proprie:

## Backend (.NET Core Web API)

- Espone endpoint REST che operano su risorse “Prodotti”.
- Si occupa di business logic, validazione, accesso ai dati (Entity Framework Core verso un database relazionale, ad esempio SQL Server o SQLite).
- Restituisce e riceve payload JSON.

## Frontend (Angular)

- Applicazione single-page (SPA) scritta in TypeScript + HTML + CSS.
- Invoca gli endpoint del backend via HttpClient e popola componenti con i dati ricevuti.
- Si occupa di user experience, routing lato client, validazione form, responsive design.

**Separazione tra Frontend e Backend**

## Backend Frontend

**Linguaggio:** C#	Linguaggio: TypeScript (+ JavaScript compilato)

**Framework:** ASP.NET Core	Framework: Angular

Esegue su Kestrel/IIS/Kubernetes	Esegue su un web server statico (es. Nginx) o ng serve

**Responsabilità:**
Responsabilità:
- Persistenza dati	- Navigazione client-side
- Autenticazione/Autorizzazione (opzionale)	- Rendering UI
- Validazione e logica business	- Gestione stati e servizi Angular
- Formattazione e serializzazione JSON	- Styling (CSS, SCSS) e template (HTML)

## Benefici principali:

**Manutenibilità:** ogni parte si evolve in modo indipendente.

**Scalabilità:** il backend può essere distribuito e scalato orizzontalmente a prescindere dal front.

**Team specialization:** frontend-developer si concentra su UX/CSS/HTML/TypeScript, backend-developer su C#/.NET e database.

## Comunicazione dati: come avviene

**Chiamata HTTP**

```typescript
// Angular service (prodotti.service.ts)
getProdotti(): Observable<Prodotto[]> {
  return this.http.get<Prodotto[]>('/api/prodotti');
}
```
**Serializzazione/Deserializzazione JSON**

Il backend restituisce [{ id:1, nome:"Sedia", prezzo:49.9 }, …].

Angular deserializza in oggetti TypeScript conformi all’interfaccia Prodotto.

**Gestione asincrona**

Angular utilizza RxJS (Observable, subscribe) per gestire la risposta.

Eventuali errori HTTP (404, 500) vengono intercettati e mostrati all’utente tramite un componente di alert.

**State management (opzionale)**

Per app più complesse si introduce un store (NgRx) che centralizza lo stato “prodotti”, “carrello”, ecc.

## Perché conoscere JavaScript, TypeScript, HTML e CSS

**HTML:** struttura semantica dei componenti, binding, direttive (*ngFor, *ngIf).

**CSS/SCSS:** styling responsivo, layout a griglia, media query, gestione temi.

**JavaScript:** runtime browser, manipolazione DOM, gestione asincrona (Promise, fetch).

**TypeScript:** superset di JS che aggiunge tipizzazione statica, interfacce, classi; migliora refactoring, autocompletion ed evita errori a runtime.

In Angular il codice TS viene “transpilato” in JS; i browser eseguono solo JS.

La differenza tra TS e JS è critica per la manutenzione di progetti di media-grandezza.

## Scenari e casi d’uso
### 1. Navigazione catalogo (utente anonimo)

**Obiettivo:** l’utente vede la lista prodotti.

> Flusso:

- Il componente CatalogoComponent invoca ProdottiService.getProdotti().
- HTTP GET a /api/prodotti.
- Ricezione JSON → assegnazione a this.prodotti.
- *ngFor="let p of prodotti" genera un card per ogni prodotto.

L’utente clicca “Dettagli”.

### 2. Visualizzazione dettaglio prodotto

**Obiettivo:** mostrare descrizione estesa, immagini, prezzo.

> Flusso:

- DettaglioComponent legge route.params['id'].
- Chiama /api/prodotti/{id}.
- Si presenta la scheda prodotto con formattazione HTML/CSS.

### 3. Ricerca e filtraggio

**Obiettivo:** utente filtra per categoria o range di prezzo.

> Implementazione:

- Il frontend invia query string (?categoria=sedie&prezzoMin=10).
- Backend applica filtri su DbSet con LINQ (.Where(p=>p.Categoria==categoria)).

### 4. Amministrazione (CRUD, autenticazione)

> Flusso di creazione prodotto:

- Form Angular con ReactiveFormsModule valida campi (Validators.required).
- POST JSON a /api/prodotti.
- Backend valida ModelState, salva entità e restituisce 201 Created con header Location.
- Frontend intercetta e reindirizza alla lista.

### 5. Gestione errori e retry

**Scenario:** timeout o 500 interno.

> Soluzioni:

- Angular: HttpInterceptor che logga errori.
- .NET: middleware UseExceptionHandler per formattare ProblemDetails.

## Riassunto dei vantaggi full-stack
Decoupling: il frontend non dipende da implementazioni .NET, comunica solo via HTTP/JSON.

Produttività: .NET Core e Angular CLI generano template di base con scaffolding.

Esperienza utente: SPA client-side reattiva, reload minimizzato.

Tipizzazione end-to-end: definendo interfacce sia in C# (DTO) sia in TS (model), si riduce il rischio di mismatch dei dati.

Con questa struttura modulare, è semplice estendere la mini-app: aggiungere pagine, servizi

# Backend

```bash
dotnet new webapi -o Backend
```

## Definisci il modello
Nel file Backend/Models/Product.cs:
```csharp
namespace Backend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
```
## In-memory “repository”

In pratica creiamo un servizio che simula un database in memoria per i prodotti.

Aggiungi in Backend/Services/ProductService.cs:

```csharp
using Backend.Models; // Importa il namespace Backend.Models per accedere ai modelli definiti in esso
namespace Backend.Services
{
    public class ProductService
    {
        // Inizializza una lista di prodotti in memoria
        private readonly List<Product> _products = new() // Inizializza una lista di prodotti in memoria
        // definisco privata la _list di prodotti perche voglio che sia accessibile solo all'interno di questa classe
        // in pratica voglio che l elenco dei prodotti sia accessibile solo all'interno di questa classe
        // uso l underscore prima del nome dell oggetto _products per indicare che è un campo privato (è una convenzione)
        {
            // elenco dei prodotti iniziali
            new Product { Id = 1, Name = "Penna", Price = 1.20M },
            new Product { Id = 2, Name = "Quaderno", Price = 2.50M }
        };

        // Restituisce tutti i prodotti dato che erano privati _products li rendo pubblici
        // public List<Product> GetAll() => _products; // lambda expression per restituire la lista dei prodotti
        // ciclo in modo da restituire tutti i prodotti

        // metodo per ottenere tutti i prodotti sotto forma di lista
        public List<Product> GetAll()
        // public -> è ul modificatore d accesso che indica che il metodo è accessibile da qualsiasi parte del programma
        // List<Product> -> indica che il metodo restituisce una lista di oggetti di tipo Product
        // GetAll() -> è il nome del metodo che restituisce tutti i prodotti
        {
            List<Product> result = new List<Product>(); // creo una nuova lista di prodotti per restituire i risultati
            foreach (var product in _products)
            {
                result.Add(product); // aggiungo ogni prodotto alla lista dei risultati
            }
            return result;
        }

        // metodo per ottenere un prodotto specifico in base all'ID o null se non lo trova
        // public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id); // lambda expression per trovare il primo prodotto con l'ID specificato
        // oppure con for each invece di LINQ
        public Product? GetById(int id) // metodo per ottenere un prodotto specifico in base all'ID
        {
            foreach (var product in _products)
            {
                if (product.Id == id) // controllo se l'ID del prodotto corrisponde a quello cercato
                {
                    return product; // restituisco il prodotto se trovato
                }
            }
            return null; // Restituisce null se non trovato
        }

        // metodo per aggiungere un nuovo prodotto alla lista

        // metodo per eliminare un prodotto specifico in base all'ID

        // metodo per modificare un prodotto specifico in base all'ID
    }
}
```

## Registra il servizio e crea il controller
In Backend/Program.cs, registra il ProductService:
```csharp
using Backend.Services; // Importa il namespace Backend.Services per accedere ai servizi definiti in esso
using Microsoft.AspNetCore.Builder; // Importa il namespace Microsoft.AspNetCore.Builder per configurare l'applicazione ASP.NET Core
using Microsoft.Extensions.DependencyInjection; // Importa il namespace Microsoft.Extensions.DependencyInjection per configurare i servizi dell'applicazione
using Microsoft.Extensions.Hosting; // Importa il namespace Microsoft.Extensions.Hosting per configurare l'hosting dell'applicazione

// CREAZIONE DELL'APPLICAZIONE

var builder = WebApplication.CreateBuilder(args); // Crea un nuovo builder per l'applicazione ASP.NET Core

// 1. Aggiungi i controller
// i controller sono responsabili della gestione delle richieste HTTP e della restituzione delle risposte
builder.Services.AddControllers();

// 2. Registra il servizio in-memory per i prodotti
// in pratica vado a simulare un archivio di dati dato che non posso farlo nel program principale lo faccio in una folders servizi
builder.Services.AddSingleton<ProductService>();

// 3. Configura CORS per permettere tutte le origini (sviluppo locale)
// CORS (Cross-Origin Resource Sharing) è una politica di sicurezza che permette o blocca le richieste tra domini diversi
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin() // Permette richieste da qualsiasi origine (utile in fase di sviluppo)
            .AllowAnyHeader() // Permette qualsiasi header (intestazione) nelle richieste cioè le informazioni inviate con la richiesta
            .AllowAnyMethod(); // Permette qualsiasi metodo HTTP (GET, POST, PUT, DELETE, ecc.)
    });
});

var app = builder.Build(); // Costruisce l'applicazione ASP.NET Core

// CONFIGURAZIONE DELL'APPLICAZIONE

// il middleware è un componente che gestisce una funzionalita' specifica dell'applicazione

// 4. Middleware HTTPS e CORS
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Mostra errori dettagliati in sviluppo
}

app.UseHttpsRedirection(); // Reindirizza le richieste HTTP a HTTPS verso HTTPS

app.UseCors(); // Applica le politiche CORS definite in precedenza

// 5. Mappa i controller API
// in pratica mappa le rotte dei controller API per gestire le richieste HTTP
// mappare le rotte significa associare le richieste HTTP a specifici metodi nei controller
app.MapControllers();

app.Run(); // Avvia l'applicazione e inizia ad ascoltare le richieste HTTP
```

In Backend/Controllers/ProductsController.cs:
```csharp
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _service;
    // public ProductsController(ProductService service) => _service = service;
    // oppure con il foreach invece della lambda expression
    public ProductsController(ProductService service) // l argomento del costruttore è il servizio che gestisce i prodotti in questo caso ProductService
    {
      // il throw serve a lanciare un'eccezione se il servizio è null
      // in pratica se il servizio non viene passato al costruttore l'applicazione non può funzionare
      // nameof service restituisce il nome della variabile service come stringa in modo da evitare errori
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    // public ActionResult<List<Product>> Get() => _service.GetAll();
    public ActionResult<List<Product>> Get() // metodo per ottenere tutti i prodotti
    {
        List<Product> products = _service.GetAll(); // chiama il servizio per ottenere tutti i prodotti
        return Ok(products); // restituisce i prodotti con lo stato HTTP 200 OK
        // e una convenzione di ASP.NET Core per restituire una risposta HTTP 200 OK con i dati specificati
    }

    // metodo per ottenere un prodotto specifico in base all'ID
    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
      // devo costruire il prodotto in base all'ID passato come parametro
        var p = _service.GetById(id);
        if (p is null) return NotFound();
        return p;
    }
}
```
L’API sarà su https://localhost:5296/api/products (port variabile)

Il singolo prodotto è accessibile su: https://localhost:5296/api/products/{id}

## Implementazione metodi

[HttpPost] riceve il Product nel corpo della richiesta ([FromBody])→ POST /api/products.

[HttpPut("{id}")] aggiorna il prodotto esistente → PUT /api/products/{id}.

[HttpDelete("{id}")] rimuove il prodotto → DELETE /api/products/{id}

In Backend/Services/ProductService.cs:

```csharp
// metodo per aggiungere un nuovo prodotto alla lista
// CREA (Create)
public Product Add(Product newProduct)
{
    // Calcola il prossimo ID
    int nextId; // dichiaro una variabile per il prossimo ID
    // Se la lista dei prodotti non è vuota, calcolo il massimo ID esistente
    // altrimenti imposto il prossimo ID a 1
    if (_products.Count > 0)
    {
        // Trovo il massimo ID con un semplice ciclo
        int maxId = 0; // imposto il massimo ID a 0
        foreach (var p in _products)
        {
            if (p.Id > maxId) // Se l id è maggiore del massimo ID trovato
            {
                maxId = p.Id; // imposto il massimo ID a quello del prodotto corrente
            }
        }
        nextId = maxId + 1; // imposto il prossimo ID come il massimo ID trovato + 1
    }
    else
    {
        nextId = 1; // Se la lista è vuota, imposto il prossimo ID a 1
    }

    newProduct.Id = nextId; // assegno il prossimo ID al nuovo prodotto
    _products.Add(newProduct); // aggiungo il nuovo prodotto alla lista dei prodotti
    return newProduct; // restituisco il nuovo prodotto aggiunto
}

// metodo per eliminare un prodotto specifico in base all'ID
// ELIMINA (Delete)
public bool Delete(int id)
{
    // Cerco il prodotto da rimuovere
    Product? existing = null; // dichiaro una variabile per il prodotto esistente
    foreach (var p in _products)
    {
        if (p.Id == id) // controllo se l'ID del prodotto corrisponde a quello cercato
        {
            existing = p; // se trovato, assegno il prodotto esistente alla variabile
            break; // interrompo il ciclo
        }
    }

    if (existing == null)
    {
        // Non trovato
        return false; // se il prodotto non è stato trovato, restituisco false
    }

    // Rimuovo e ritorno il risultato della rimozione
    bool removed = _products.Remove(existing); // rimuovo il prodotto esistente dalla lista dei prodotti
    return removed; // restituisco true se il prodotto è stato rimosso con successo, altrimenti false
}

// metodo per modificare un prodotto specifico in base all'ID
// AGGIORNA (Update)
public bool Update(int id, Product updatedProduct)
{
    // Cerco il prodotto manualmente
    Product? existing = null; // dichiaro una variabile per il prodotto esistente
    foreach (var p in _products)
    {
        if (p.Id == id) // controllo se l'ID del prodotto corrisponde a quello cercato
        {
            existing = p; // se trovato, assegno il prodotto esistente alla variabile
            break; // interrompo il ciclo
        }
    }

    if (existing == null)
    {
        // Non trovato
        return false; // se il prodotto non è stato trovato, restituisco false
    }

    // Sovrascrivo i campi desiderati
    existing.Name = updatedProduct.Name; // aggiorno il nome del prodotto esistente con quello del prodotto aggiornato
    existing.Price = updatedProduct.Price; // aggiorno il prezzo del prodotto esistente con quello del prodotto aggiornato
    return true; // restituisco true se il prodotto è stato aggiornato con successo
}
```
In Backend/Controllers/ProductsController.cs:

```csharp
// POST api/products
[HttpPost]
public ActionResult<Product> Post([FromBody] Product prod)
{
    // Aggiunge il prodotto e ottiene l’istanza creata
    Product created = _service.Add(prod);

    // Restituisce 201 Created con header Location che punta a GET api/products/{id}
    return CreatedAtAction(
        actionName: nameof(Get),
        routeValues: new { id = created.Id },
        value: created
    );
}

// PUT api/products/5
[HttpPut("{id}")]
public IActionResult Put(int id, [FromBody] Product prod)
{
    // Prova ad aggiornare il prodotto
    bool success = _service.Update(id, prod);

    // Se non esiste, restituisci 404
    if (success == false)
    {
        return NotFound();
    }
    else
    {
        // Se l’aggiornamento è andato a buon fine, restituisci 204 No Content
        return NoContent();
    }
}

// DELETE api/products/5
[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    // Prova a eliminare il prodotto
    bool success = _service.Delete(id);

    // Se non trovato, 404
    if (success == false)
    {
        return NotFound();
    }
    else
    {
        // Se eliminato correttamente, 204 No Content
        return NoContent();
    }
}
```

# Testing

Per prima cosa, assicurati che il tuo backend .NET sia in esecuzione e ascolti su un indirizzo HTTP (per evitare ancora problemi SSL): ad esempio:

```bash
cd Backend
dotnet run
```

Nella console vedrai qualcosa come:

```bash
Now listening on: http://localhost:5296
```

Prendi nota della porta http://localhost:5296 (o qualunque altra ti venga mostrata).

## 1. Testare con curl

1.1 Creare un prodotto (POST)

MAC WINDOWS GITBASH
```bash
curl -X POST \
  http://localhost:5296/api/products \
  -H "Content-Type: application/json" \
  -d '{"name":"Matita","price":0.50}'
```
-H imposta l’header Content-Type a application/json.

-d passa il JSON del nuovo prodotto.

Se va a buon fine riceverai in risposta l’oggetto creato, incluso il suo nuovo id.

## 1.2 Modificare un prodotto (PUT)

Supponiamo di voler aggiornare il prodotto con id=3:

```bash
curl -X PUT http://localhost:5296/api/products/3 \
  -H "Content-Type: application/json" \
  -d '{"id":3,"name":"Matita HB","price":0.60}'
```
-X PUT cambia il metodo HTTP in PUT.

L’URL include .../api/products/3 per indicare l’id da aggiornare.

Se il prodotto non esiste riceverai 204 No Content.

## 1.3 Cancellare un prodotto (DELETE)

Per rimuovere lo stesso prodotto:

```bash
curl -X DELETE http://localhost:5296/api/products/3
```
-X DELETE invia la richiesta di eliminazione.

Se il prodotto viene trovato ed eliminato riceverai 204 No Content.

## 2. Testare con Postman (o strumenti simili)

Apri Postman e crea una nuova richiesta.

Seleziona il metodo (POST, PUT o DELETE).

Inserisci l’URL:

POST → http://localhost:5295/api/products

PUT → http://localhost:5295/api/products/{id}

DELETE → http://localhost:5295/api/products/{id}

Nella sezione “Headers” aggiungi

```makefile
Key:   Content-Type
Value: application/json
```

Nella sezione “Body” (solo per POST/PUT):

Seleziona “raw” → “JSON”

Incolla il JSON:

```json
{ "name": "NuovoProdotto", "price": 9.99 }
```
Invia la richiesta e guarda la risposta in basso

Riepilogo

POST crea un nuovo prodotto:

```http
POST /api/products
Content-Type: application/json

{ "name": "...", "price": ... }
```
PUT aggiorna un prodotto esistente:

```http
PUT /api/products/{id}
Content-Type: application/json

{ "id": {id}, "name": "...", "price": ... }
```
DELETE rimuove il prodotto:

```http
DELETE /api/products/{id}
```
Usando uno di questi strumenti potrai verificare subito il funzionamento dei tuoi endpoint CRUD. Buon testing

# Aggiunta entità User e Purchase

Dentro la folder Models creo il modello User.cs:

```csharp
namespace Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
```

## Creo il Service di User

```csharp
using Backend.Models;

namespace Backend.Services
{
   public class UserService
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "User Uno", Address = "Via Roma 1" },
            new User { Id = 2, Name = "User Due", Address = "Corso Italia 10" }
        };

        public List<User> GetAll()
        {
            List<User> result = new List<User>();
            foreach (User user in _users)
            {
                result.Add(user);
            }
            return result;
        }

        public User GetById(int id)
        {
            foreach (User user in _users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public User Add(User newUser)
        {
            int nextId = 1;
            if (_users.Count > 0)
            {
                int maxId = 0;
                foreach (User user in _users)
                {
                    if (user.Id > maxId)
                    {
                        maxId = user.Id;
                    }
                }
                nextId = maxId + 1;
            }

            newUser.Id = nextId;
            _users.Add(newUser);
            return newUser;
        }

        public bool Delete(int id)
        {
            User existing = null;
            foreach (User user in _users)
            {
                if (user.Id == id)
                {
                    existing = user;
                    break;
                }
            }
            if (existing == null)
            {
                return false;
            }
            bool removed = _users.Remove(existing);
            return removed;
        }

        public bool Update(int id, User updatedUser)
        {
            User existing = null;
            foreach (User user in _users)
            {
                if (user.Id == id)
                {
                    existing = user;
                    break;
                }
            }
            if (existing == null)
            {
                return false;
            }

            existing.Name = updatedUser.Name;
            existing.Address = updatedUser.Address;
            return true;
        }
    }
}
```
## Creo il controller UserController.cs

```csharp
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _service;

    public UsersController(UserService service)
    {
        if (service == null)
        {
            throw new ArgumentNullException("service");
        }
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<User>> Get()
    {
        List<User> users = _service.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        User user = _service.GetById(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    [HttpPost]
    public ActionResult<User> Post([FromBody] User user)
    {
        User created = _service.Add(user);
        return CreatedAtAction("Get", new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] User user)
    {
        bool success = _service.Update(id, user);
        if (success == false)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool success = _service.Delete(id);
        if (success == false)
        {
            return NotFound();
        }
        return NoContent();
    }
}
```
## Aggiungo il servizio UserService in Program.cs
In `Backend/Program.cs`, registra il UserService:
```csharp
builder.Services.AddSingleton<UserService>();
```
## Creo il modello Purchase.cs:
```csharp
namespace Backend.Models
{
    public class Purchase
    {
        public int Id { get; set; } // identificativo univoco del purchase
        public int UserId { get; set; } // identificativo dell'utente che ha effettuato l'acquisto
        public int ProductId { get; set; } // identificativo del prodotto acquistato
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
```
## Creo il servizio PurchaseService.cs:
```csharp
using Backend.Models;
namespace Backend.Services
{
    public class PurchaseService
    {
      // questa proprieta verra popolata in fase di purchase
      private readonly List<Purchase> _purchases = new();

      public List<Purchase> GetAll()
        {
            List<Purchase> result = new List<Purchase>();
            foreach (var purchase in _purchases)
            {
                result.Add(purchase);
            }
            return result;
        }

        public Purchase? GetById(int id)
        {
            foreach (var p in _purchases)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }
            return null;
        }

        public Purchase Add(Purchase newPurchase)
        {
            int nextId;
            if (_purchases.Count > 0)
            {
                int maxId = 0;
                foreach (var p in _purchases)
                {
                    if (p.Id > maxId)
                        maxId = p.Id;
                }
                nextId = maxId + 1;
            }
            else
            {
                nextId = 1;
            }

            newPurchase.Id = nextId;
            if (newPurchase.PurchaseDate == default)
                newPurchase.PurchaseDate = DateTime.UtcNow;
            _purchases.Add(newPurchase);
            return newPurchase;
        }

        public bool Delete(int id)
        {
            Purchase? existing = null;
            foreach (var p in _purchases)
            {
                if (p.Id == id)
                {
                    existing = p;
                    break;
                }
            }
            if (existing == null)
                return false;

            bool removed = _purchases.Remove(existing);
            return removed;
        }

        public bool Update(int id, Purchase updatedPurchase)
        {
            Purchase? existing = null;
            foreach (var p in _purchases)
            {
                if (p.Id == id)
                {
                    existing = p;
                    break;
                }
            }
            if (existing == null)
                return false;

            existing.UserId = updatedPurchase.UserId;
            existing.ProductId = updatedPurchase.ProductId;
            existing.Quantity = updatedPurchase.Quantity;
            existing.PurchaseDate = updatedPurchase.PurchaseDate;
            return true;
        }
    }
}
```
## Creo il controller PurchaseController.cs:
Posso fare il controller in modo simile a quello di User e Product, ma con le specifiche per gli acquisti.
```csharp
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PurchasesController : ControllerBase
{
    private readonly PurchaseService _service;

    public PurchasesController(PurchaseService service)
    {
        if (service == null)
        {
            throw new ArgumentNullException("service");
        }
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Purchase>> Get()
    {
        List<Purchase> purchases = _service.GetAll();
        return Ok(purchases);
    }

    [HttpGet("{id}")]
    public ActionResult<Purchase> Get(int id)
    {
        Purchase purchase = _service.GetById(id);
        if (purchase == null)
        {
            return NotFound();
        }
        return purchase;
    }

    [HttpPost]
    public ActionResult<Purchase> Post([FromBody] Purchase purchase)
    {
        Purchase created = _service.Add(purchase);
        return CreatedAtAction("Get", new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Purchase purchase)
    {
        bool success = _service.Update(id, purchase);
        if (success == false)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool success = _service.Delete(id);
        if (success == false)
        {
            return NotFound();
        }
        return NoContent();
    }
}
```
## Aggiungo il servizio PurchaseService in Program.cs
In `Backend/Program.cs`, registra il PurchaseService:
```csharp
builder.Services.AddSingleton<PurchaseService>();
```
## Creo il comando curl in modo da inserire un acquisto:
```bash
curl -X POST http://localhost:5296/api/purchases \
  -H "Content-Type: application/json" \
  -d '{
    "userId": 1,
    "productId": 2,
    "quantity": 3
  }'
```
## comando curl per il post di Product
```bash
curl -X POST http://localhost:5296/api/products \
  -H "Content-Type: application/json" \
    -d '{
    "name": "Penna",
    "price": 1.20
    }'
```
## VERSIONE MIGLIORATA (DTO/ViewModel)
Versione Base (solo ID):
Se usi solo la tua lista Purchase, il modello contiene solo gli ID, quindi la risposta sarà così:

```json
{
  "id": 1,
  "userId": 1,
  "productId": 2,
  "quantity": 3,
  "purchaseDate": "2025-07-16T13:05:00"
}
```
Data Transfer Object

## Creo il DTO PurchaseDTO.cs:
```csharp
namespace Backend.Models
{
    public class PurchaseDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
```
Nel controller invece di restituire la lista di Purchase, devo combinare i dati di UserService e ProductService per creare una lista di PurchaseDTO.

- Carica la lista di acquisti (purchases)
- Carica la lista di utenti (users) e prodotti (products)
- Per ogni acquisto, cerca l’utente e il prodotto con l’ID corrispondente
- Se li trova, valorizza i campi del DTO
- Se non li trova, assegna "Sconosciuto" o altro valore di default

## HttpGet del controller PurchasesController.cs
Quindi bastera semplicemente modificare il metodo HttpGet del controller PurchasesController.cs:

```csharp
[HttpGet]
public ActionResult<List<PurchaseDTO>> Get()
{
  // elenco dei purchases
  List<Purchase> purchases = _service.GetAll();
  // elenco degli utenti
  List<User> users = _userService.GetAll();
  // elenco dei prodotti
  List<Product> products = _productService.GetAll();
  // creo una lista di PurchaseDTO
  List<PurchaseDTO> result = new List<PurchaseDTO>();

  // ciclo per ogni acquisto in modo da cercare lo user e il prodotto associati
  foreach (Purchase p in purchases)
  {
      User user = null; // definisco una variabile user inizialmente a null perche non so se esiste
      Product product = null; // definisco una variabile product inizialmente a null perche non so se esiste
      // cerco l'utente associato all'acquisto
      foreach (User u in users)
      {
          if (u.Id == p.UserId) // controllo se l ID dell'utente corrisponde a quello dell'acquisto
          {
              user = u;
              break;
          }
      }
      // cerco il prodotto associato all'acquisto
      foreach (Product prod in products)
      {
          if (prod.Id == p.ProductId) // controllo se l ID del prodotto corrisponde a quello dell'acquisto
          {
              product = prod;
              break;
          }
      }
      // costruisco il PurchaseDTO con i dati che ho trovato
      PurchaseDTO dto = new PurchaseDTO
      {
        Id = p.Id,
        UserName = user != null ? user.Name : "Sconosciuto",
        ProductName = product != null ? product.Name : "Sconosciuto",
        Quantity = p.Quantity,
        PurchaseDate = p.PurchaseDate
      };
      // aggiungo il PurchaseDTO alla lista dei risultati
      result.Add(dto);
  }
  // restituisco la lista dei PurchaseDTO
  return Ok(result); // Ok restituisce 200 OK con i dati specificati
}
```
## Aggiungi i campi privati per i servizi UserService e ProductService
```csharp
private readonly PurchaseService _service;
private readonly UserService _userService;
private readonly ProductService _productService;
```
## Aggiorno il costruttore di PurchasesController.cs
```csharp
public PurchasesController(PurchaseService service, UserService userService, ProductService productService)
{
  // Controllo che i servizi non siano null se lo sono lancio un'eccezione
  if (service == null)
      throw new ArgumentNullException("service");
  if (userService == null)
      throw new ArgumentNullException("userService");
  if (productService == null)
      throw new ArgumentNullException("productService");
  // Assegno i servizi ai campi privati
  _service = service;
  _userService = userService;
  _productService = productService;
}
```
## Files json invece di hardcoding
Per evitare di hardcodare i dati, puoi usare file JSON per contenere i dati iniziali di prodotti, utenti e acquisti.
## Crea i file JSON
Crea una cartella `Data` in `Backend` e aggiungi i seguenti file:
### products.json
```json
[
  { "Id": 1, "Name": "Penna", "Price": 1.20 },
  { "Id": 2, "Name": "Quaderno", "Price": 2.50 }
]
```
### users.json
```json
[
  { "Id": 1, "Name": "User Uno", "Address": "Via Roma 1" },
  { "Id": 2, "Name": "User Due", "Address": "Corso Italia 10" }
]
```
### purchases.json
```json
[
  { "Id": 1, "UserId": 1, "ProductId": 2, "Quantity": 3, "PurchaseDate": "2025-07-16T13:05:00" },
  { "Id": 2, "UserId": 2, "ProductId": 1, "Quantity": 1, "PurchaseDate": "2025-07-16T14:00:00" }
]
```
## Modifica i servizi per caricare i dati dai file JSON
In `Backend/Services/ProductService.cs`, modifica il costruttore per caricare i dati da `products.json`:
```csharp
namespace Backend.Services
{
    public class ProductService
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            // Carica i prodotti dal file JSON
            string json = File.ReadAllText("Data/products.json");
            _products = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        // Altri metodi rimangono invariati...
    }
}
```
In `Backend/Services/UserService.cs`, modifica il costruttore per caricare i dati da `users.json`:
```csharp
namespace Backend.Services
{
    public class UserService
    {
        private readonly List<User> _users;
        public UserService()
        {
            // Carica gli utenti dal file JSON
            string json = File.ReadAllText("Data/users.json");
            _users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }
        // Altri metodi rimangono invariati...
    }
}
```
In `Backend/Services/PurchaseService.cs`, modifica il costruttore per caricare i dati da `purchases.json`:
```csharp
namespace Backend.Services
{
    public class PurchaseService
    {
        private readonly List<Purchase> _purchases;

        public PurchaseService()
        {
            // Carica gli acquisti dal file JSON
            string json = File.ReadAllText("Data/purchases.json");
            _purchases = JsonSerializer.Deserialize<List<Purchase>>(json) ?? new List<Purchase>();
        }

        // Altri metodi rimangono invariati...
    }
}
```
## Aggiunta di modelli collegati
Vediamo come strutturare Product con una Category collegata, e User con un Address collegato
## Modello Category.cs
Crea un nuovo file `Category.cs` in `Backend/Models`:
```csharp
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```
## Modifica Product.cs per includere CategoryId
```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
```
## Modello Address.cs
Crea un nuovo file `Address.cs` in `Backend/Models`:
```csharp
public class Address
{
    public string Citta { get; set; }
    public string Via { get; set; }
    public string CAP { get; set; }
}
```
## Modifica User.cs per includere Address
```csharp
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
}
```
## Modifica i file JSON per includere Category e Address
### products.json
```json
[
  { "Id": 1, "Name": "Penna", "Price": 1.20, "CategoryId": 1 },
  { "Id": 2, "Name": "Quaderno", "Price": 2.50, "CategoryId": 2 }
]
```
### users.json
```json
[
    { "Id": 1, "Name": "User Uno", "Address": { "Citta": "Roma", "Via": "Via Roma 1", "CAP": "00100" } },
    { "Id": 2, "Name": "User Due", "Address": { "Citta": "Milano", "Via": "Corso Italia 10", "CAP": "20100" } }
]
```
### categories.json
Crea un nuovo file `categories.json` in `Backend/Data`:
```json
[
  { "Id": 1, "Name": "Cancelleria" },
  { "Id": 2, "Name": "Libri" }
]
```
## Modifica ProductService per caricare le categorie
In `Backend/Services/ProductService.cs`, aggiungi il caricamento delle categorie:
```csharp
using Backend.Models;
using System.Text.Json;
using System.IO;
namespace Backend.Services
{
    public class ProductService
    {
        private readonly List<Product> _products;
        private readonly List<Category> _categories;

        public ProductService()
        {
            // Carica i prodotti dal file JSON
            string productsJson = File.ReadAllText("Data/products.json");
            _products = JsonSerializer.Deserialize<List<Product>>(productsJson) ?? new List<Product>();

            // Carica le categorie dal file JSON
            string categoriesJson = File.ReadAllText("Data/categories.json");
            _categories = JsonSerializer.Deserialize<List<Category>>(categoriesJson) ?? new List<Category>();
        }

        // Altri metodi rimangono invariati...
    }
}
```
## Category Service
Crea un nuovo file `CategoryService.cs` in `Backend/Services`:
```csharp
using Backend.Models;
using System.Text.Json;

namespace Backend.Services
{
    public class CategoryService
    {
        private readonly List<Category> _categories;

        public CategoryService()
        {
            string json = File.ReadAllText("Data/categories.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _categories = JsonSerializer.Deserialize<List<Category>>(json, options) ?? new List<Category>();
        }

        public List<Category> GetAll()
        {
            List<Category> result = new List<Category>();
            foreach (var cat in _categories)
            {
                result.Add(cat);
            }
            return result;
        }

        public Category GetById(int id)
        {
            foreach (var cat in _categories)
            {
                if (cat.Id == id)
                    return cat;
            }
            return null;
        }
    }
}
```
## Aggiungi il CategoryService in Program.cs
In `Backend/Program.cs`, registra il CategoryService:
```csharp
builder.Services.AddSingleton<CategoryService>();
```
## Aggiungi il controller CategoryController.cs
Crea un nuovo file `CategoryController.cs` in `Backend/Controllers`:
```csharp
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly CategoryService _service;

    public CategoriesController(CategoryService service)
    {
        if (service == null)
            throw new ArgumentNullException("service");
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Category>> Get()
    {
        List<Category> categories = _service.GetAll();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public ActionResult<Category> Get(int id)
    {
        Category cat = _service.GetById(id);
        if (cat == null)
            return NotFound();
        return cat;
    }
}
```
## Modifica il controller di Purchase in modo da includere Category
In `Backend/Controllers/PurchasesController.cs`, modifica il metodo `Get` per includere le categorie:
```csharp
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PurchasesController : ControllerBase
{
    private readonly PurchaseService _service;
    private readonly UserService _userService;
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;

    public PurchasesController(PurchaseService service, UserService userService, ProductService productService, CategoryService categoryService)
    {
        // Controllo che i servizi non siano null se lo sono lancio un'eccezione
        if (service == null)
            throw new ArgumentNullException("service");
        if (userService == null)
            throw new ArgumentNullException("userService");
        if (productService == null)
            throw new ArgumentNullException("productService");
        if (categoryService == null)
            throw new ArgumentNullException("categoryService");

        _service = service;
        _userService = userService;
        _productService = productService;
        _categoryService = categoryService;
    }

    [HttpGet]
public ActionResult<List<PurchaseDTO>> Get()
{
    List<Purchase> purchases = _service.GetAll();
    List<User> users = _userService.GetAll();
    List<Product> products = _productService.GetAll();
    List<Category> categories = _categoryService.GetAll();

    List<PurchaseDTO> result = new List<PurchaseDTO>();
    foreach (Purchase p in purchases)
    {
        User user = null;
        Product product = null;
        // Cerca user e product associati
        foreach (User u in users)
        {
            if (u.Id == p.UserId)
            {
                user = u;
                break;
            }
        }
        // Cerca il prodotto associato
        foreach (Product prod in products)
            {
                if (prod.Id == p.ProductId)
                {
                    product = prod;
                    break;
                }
            }
        // Cerca la categoria associata al prodotto
        string categoryName = "Sconosciuto";
        if (product != null)
        {
            foreach (Category cat in categories)
            {
                if (cat.Id == product.CategoryId)
                {
                    categoryName = cat.Name;
                    break;
                }
            }
        }

        PurchaseDTO dto = new PurchaseDTO
        {
            Id = p.Id,
            UserName = user != null ? user.Name : "Sconosciuto",
            ProductName = product != null ? product.Name : "Sconosciuto",
            Quantity = p.Quantity,
            PurchaseDate = p.PurchaseDate,
            ProductCategory = categoryName
        };
        result.Add(dto);
    }

    return Ok(result);
}

    [HttpPost]
    public ActionResult<Purchase> Post([FromBody] Purchase purchase)
    {
        Purchase created = _service.Add(purchase);
        return CreatedAtAction("Get", new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Purchase purchase)
    {
        bool success = _service.Update(id, purchase);
        if (success == false)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool success = _service.Delete(id);
        if (success == false)
        {
            return NotFound();
        }
        return NoContent();
    }
}
```
## Creazione modello ProductDTO.cs
Al momento nella pagina
http://localhost:5296/api/products/2
mostra solo i campi di Product, ma non il nome della categoria associata.
Per risolvere questo, possiamo creare un DTO (Data Transfer Object) che includa anche il nome della categoria.
## Crea il file ProductDTO.cs
Crea un nuovo file `ProductDTO.cs` in `Backend/Models`:
```csharp
public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; }
}
```
Nel ProductController, modifichiamo il metodo `Get` per restituire una lista di `ProductDTO` invece di `Product`.
## Modifica il metodo Get in ProductsController.cs
In `Backend/Controllers/ProductsController.cs`, modifica il metodo `Get`:
```csharp
[HttpGet]
public ActionResult<List<ProductDTO>> Get()
{
    List<Product> products = _service.GetAll();
    List<Category> categories = _categoryService.GetAll();

    List<ProductDTO> result = new List<ProductDTO>();
    foreach (Product prod in products)
    {
        Category cat = null;
        foreach (Category c in categories)
        {
            if (c.Id == prod.CategoryId)
            {
                cat = c;
                break;
            }
        }

        ProductDTO dto = new ProductDTO();
        dto.Id = prod.Id;
        dto.Name = prod.Name;
        dto.Price = prod.Price;
        dto.CategoryName = cat != null ? cat.Name : "Sconosciuta";
        result.Add(dto);
    }

    return Ok(result);
}
```
Aggiungi la proprietà `CategoryService` al controller:
```csharp
private readonly CategoryService _categoryService;
```
E modifica il costruttore per accettare `CategoryService`:
```csharp
public ProductsController(ProductService service, CategoryService categoryService)
{
    if (service == null)
        throw new ArgumentNullException("service");
    if (categoryService == null)
        throw new ArgumentNullException("categoryService");
    _service = service;
    _categoryService = categoryService;
}
```
## Modifica il metodo GetById in ProductsController.cs
Modifica anche il metodo `GetById` per restituire un `ProductDTO`:
```csharp
[HttpGet("{id}")] // DATA BINDING indica che questo metodo risponde alle richieste HTTP GET con un parametro di percorso {id}
    public ActionResult<ProductDTO> Get(int id)
    {
        // devo costruire il prodotto in base all'ID passato come parametro
        Product p = _service.GetById(id);
        if (p is null)
        {
            return NotFound();
        }

        Category cat = _categoryService.GetById(p.CategoryId);
        ProductDTO dto = new ProductDTO
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            CategoryName = cat != null ? cat.Name : "Sconosciuta"
        };

        return Ok(dto);
    }
```
# Utils

## JsonFileHelper
Organizzare la serializzazione/deserializzazione in una classe statica separata è una best practice per tenere il codice pulito e riusabile.
Così il caricamento e il salvataggio dei dati dai file JSON sarà gestito da un'unica utility

## Crea la classe statica JsonFileHelper
Crea un nuovo file `JsonFileHelper.cs` in `Backend/Utils`:
```csharp
using System.Text.Json;

namespace Backend.Utils
{
    public static class JsonFileHelper
    {
        // questa classe fornisce metodi per caricare e salvare liste di oggetti in file JSON
        // questa è una classe statica che non può essere istanziata

        // configuro le impostazioni di serializzazione
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            // Imposta le opzioni di serializzazione per gestire i nomi delle proprietà in modo case-insensitive
            PropertyNameCaseInsensitive = true,
            // Imposta l'indentazione per una migliore leggibilità del file JSON
            WriteIndented = true
        };

        // metodo per caricare una lista di oggetti da un file JSON (deserializzazione)
        // T indica che il metodo può essere utilizzato con qualsiasi tipo di oggetto ad esempio List<User>, List<Category>, List<Product>
        public static List<T> LoadList<T>(string filePath)
        {
            // Controlla se il file esiste, se non esiste restituisce una lista vuota
            if (!File.Exists(filePath))
                // Restituisce una lista vuota
                return new List<T>();
            // Legge il contenuto del file JSON
            string json = File.ReadAllText(filePath);
            // Deserializza il JSON in una lista di oggetti del tipo T
            return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
        }

        // metodo per salvare una lista di oggetti in un file JSON (serializzazione)
        public static void SaveList<T>(string filePath, List<T> list)
        {
            string json = JsonSerializer.Serialize(list, options);
            File.WriteAllText(filePath, json);
        }
    }
}
```
## Usa l’utility in service
In `Backend/Services/ProductService.cs`, modifica il costruttore per usare `JsonFileHelper`:
```csharp
using Backend.Models;
using Backend.Utils;
using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper

namespace Backend.Services
{
    public class ProductService
    {
        // questa proprietà conterrà la lista dei prodotti caricati dal file JSON
        private readonly List<Product> _products;
        public ProductService()
        {
            _products = JsonFileHelper.LoadList<Product>("Data/products.json");
        }

        // ... altri metodi ...
    }
}
```
In `Backend/Services/UserService.cs`, modifica il costruttore per usare `JsonFileHelper`:
```csharp
using Backend.Models;
using Backend.Utils;
using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper

namespace Backend.Services
{
    public class UserService
    {
        private readonly List<User> _users;
        public UserService()
        {
            _users = JsonFileHelper.LoadList<User>("Data/users.json");
        }

        // ... altri metodi ...
    }
}
```
In `Backend/Services/PurchaseService.cs`, modifica il costruttore per usare `JsonFileHelper`:
```csharp
using Backend.Models;
using Backend.Utils;
using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper

namespace Backend.Services
{
    public class PurchaseService
    {
        private readonly List<Purchase> _purchases;
        public PurchaseService()
        {
            _purchases = JsonFileHelper.LoadList<Purchase>("Data/purchases.json");
        }

        // ... altri metodi ...
    }
}
```
In `Backend/Services/CategoryService.cs`, modifica il costruttore per usare `JsonFileHelper`:
```csharp
using Backend.Models;
using Backend.Utils;
using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper

namespace Backend.Services
{
    public class CategoryService
    {
        private readonly List<Category> _categories;
        public CategoryService()
        {
            _categories = JsonFileHelper.LoadList<Category>("Data/categories.json");
        }

        // ... altri metodi ...
    }
}
```
## Salvataggio dei dati
Per salvare i dati modificati, puoi aggiungere un metodo `Save` in ogni service
## Aggiungi il metodo Save in ProductService
```csharp
public void Save()
{
    JsonFileHelper.SaveList("Data/products.json", _products);
}
```
## Aggiungi il metodo Save in UserService
```csharp
public void Save()
{
    JsonFileHelper.SaveList("Data/users.json", _users);
}
```
## Aggiungi il metodo Save in PurchaseService
```csharp
public void Save()
{
    JsonFileHelper.SaveList("Data/purchases.json", _purchases);
}
```
## Aggiungi il metodo Save in CategoryService
```csharp
public void Save()
{
    JsonFileHelper.SaveList("Data/categories.json", _categories);
}
```
## Modifica i metodi Add, Update e Delete per chiamare Save
In ogni metodo `Add`, `Update` e `Delete`, chiama il metodo `Save` dopo aver modificato la lista:
### In ProductService.cs
```csharp
public Product Add(Product newProduct)
{
    // ... codice esistente ...
    _products.Add(newProduct);
    Save(); // Salva i dati dopo l'aggiunta
    return newProduct;
}
public bool Update(int id, Product updatedProduct)
{
    // ... codice esistente ...
    Save(); // Salva i dati dopo l'aggiornamento
    return true;
}
public bool Delete(int id)
{
    // ... codice esistente ...
    Save(); // Salva i dati dopo la cancellazione
    return removed;
}
```
Allo stesso modo in `UserService.cs`, `PurchaseService.cs` e `CategoryService.cs`, aggiungi le chiamate a `Save()` nei metodi `Add`, `Update` e `Delete`.
## LoggerHelper
Scrive log su file o su console.

Utile per debug, errori, operazioni importanti

```csharp
public static class LoggerHelper
{
    public static void Log(string message)
    {
        // Crea una stringa di log con timestamp
        string logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
        // Scrive il log su console
        Console.WriteLine(logLine);
        // Puoi anche scrivere su file con File.AppendAllText("log.txt", logLine + Environment.NewLine);
        File.AppendAllText("log.txt", logLine + Environment.NewLine);
    }
}
```
## Usa LoggerHelper nei servizi
In ogni service, puoi usare `LoggerHelper` per registrare eventi importanti:
```csharp
public Product Add(Product newProduct)
{
    // ... codice esistente ...
    LoggerHelper.Log($"Aggiunto prodotto ID: {newProduct.Id} ({newProduct.Name})");
    Save(); // Salva i dati dopo l'aggiunta
    return newProduct;
}
public bool Update(int id, Product updatedProduct)
{
    // ... codice esistente ...
    LoggerHelper.Log($"Aggiornato prodotto ID: {id} con nuovo nome: {updatedProduct.Name}");
    Save(); // Salva i dati dopo l'aggiornamento
    return true;
}
public bool Delete(int id)
{
    // ... codice esistente ...
    if (removed)
    {
        LoggerHelper.Log($"Cancellato prodotto ID: {id}");
    }
    else
    {
        LoggerHelper.Log($"Tentativo di cancellazione fallito per prodotto ID: {id}");
    }
    Save(); // Salva i dati dopo la cancellazione
    return removed;
}
```
## Comando curl per testare i log
Puoi usare il comando `curl` per testare le operazioni e vedere i log generati:
### Aggiungi un prodotto
```bash
curl -X POST http://localhost:5296/api/products \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Penna",
    "price": 1.20,
    "categoryId": 0
  }'
```
the category field is required quindi devi prima creare una categoria con il comando:
### Aggiungi una categoria
```bash
curl -X POST http://localhost:5296/api/categories \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Usdfsdfsfdsfs"
  }'
```
### Elimina una categoria
```bash
curl -X DELETE http://localhost:5296/api/categories/3
```
### Aggiorna un prodotto
```bash
curl -X PUT http://localhost:5296/api/products/1 \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Penna Rossa",
    "price": 1.50,
    "categoryId": 1
  }'
```
### Cancella un prodotto
```bash
curl -X DELETE http://localhost:5296/api/products/1
```
In `UserService.cs`, `PurchaseService.cs` e `CategoryService.cs`, fai lo stesso

## IdGenerator
Al momento ogni entita ha il metodo Add che duplica il codice di creazione dell id:
```csharp
public Product Add(Product newProduct)
    {
        // Calcola il prossimo ID
        int nextId; // dichiaro una variabile per il prossimo ID
        // Se la lista dei prodotti non è vuota, calcolo il massimo ID esistente
        // altrimenti imposto il prossimo ID a 1
        if (_products.Count > 0)
        {
            // Trovo il ID con un semplice ciclo
            int maxId = 0; // imposto ID a 0
            foreach (var p in _products)
            {
                if (p.Id > maxId) // Se l id è maggiore del massimo ID trovato
                {
                    maxId = p.Id; // imposto il massimo ID a quello del prodotto corrente
                }
            }
            nextId = maxId + 1; // imposto il prossimo ID come il massimo ID trovato + 1
        }
        else
        {
            nextId = 1; // Se la lista è vuota, imposto il prossimo ID a 1
        }

        newProduct.Id = nextId; // assegno il prossimo ID al nuovo prodotto
        _products.Add(newProduct); // aggiungo il nuovo prodotto alla lista dei prodotti
        return newProduct; // restituisco il nuovo prodotto aggiunto
    }
```
Per evitare di duplicare questo codice in ogni service, possiamo creare una classe `IdGenerator` che gestisce la generazione degli ID.
## Crea la classe IdGenerator
Crea un nuovo file `IdGenerator.cs` in `Backend/Utils`:
```csharp
namespace Backend.Utils
{
    public static class IdGenerator
    {
        // Questo metodo calcola il prossimo ID disponibile per una lista di oggetti che implementano IIdentifiable
        public static int GetNextId<T>(List<T> items) where T : IIdentifiable
        {
            // Se la lista è vuota, il prossimo ID sarà 1
            if (items.Count == 0)
                return 1;

            // Altrimenti, trova il massimo ID esistente e restituisci il prossimo ID
            int maxId = 0;
            foreach (var item in items)
            {
                // Controlla se l'ID dell'elemento corrente è maggiore del massimo trovato finora
                if (item.Id > maxId)
                    maxId = item.Id;
            }
            // Restituisco il prossimo ID disponibile
            return maxId + 1;
        }
    }
    // questo modello deve essere implementato da tutti i modelli che hanno un ID
    public interface IIdentifiable
    {
        int Id { get; set; }
    }
}
```
## Modifica i modelli per implementare IIdentifiable
In `Backend/Models/Product.cs`, `User.cs`, `Purchase.cs` e `Category.cs`, fai in modo che i modelli implementino l'interfaccia `IIdentifiable`:
```csharp
public class Product : IIdentifiable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}
public class User : IIdentifiable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
}
public class Purchase : IIdentifiable
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime PurchaseDate { get; set; }
}
public class Category : IIdentifiable
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```
## Modifica i metodi Add nei servizi per usare IdGenerator
In `Backend/Services/ProductService.cs`, modifica il metodo `Add`:
```csharp
public Product Add(Product newProduct)
{
    // Usa IdGenerator per ottenere il prossimo ID
    newProduct.Id = IdGenerator.GetNextId(_products);
    _products.Add(newProduct);
    LoggerHelper.Log($"Aggiunto prodotto: {newProduct.Name} (ID: {newProduct.Id})");
    Save(); // Salva i dati dopo l'aggiunta
    return newProduct;
}
```
In `Backend/Services/UserService.cs`, modifica il metodo `Add`:
```csharp
public User Add(User newUser)
{
    // Usa IdGenerator per ottenere il prossimo ID
    newUser.Id = IdGenerator.GetNextId(_users);
    _users.Add(newUser);
    LoggerHelper.Log($"Aggiunto utente: {newUser.Name} (ID: {newUser.Id})");
    Save(); // Salva i dati dopo l'aggiunta
    return newUser;
}
```
In `Backend/Services/PurchaseService.cs`, modifica il metodo `Add`:
```csharp
public Purchase Add(Purchase newPurchase)
{
    // Usa IdGenerator per ottenere il prossimo ID
    newPurchase.Id = IdGenerator.GetNextId(_purchases);
    if (newPurchase.PurchaseDate == default)
        newPurchase.PurchaseDate = DateTime.UtcNow;
    _purchases.Add(newPurchase);
    LoggerHelper.Log($"Aggiunto acquisto ID: {newPurchase.Id} per utente ID: {newPurchase.UserId}");
    Save(); // Salva i dati dopo l'aggiunta
    return newPurchase;
}
```
In `Backend/Services/CategoryService.cs`, modifica il metodo `Add`:
```csharp
public Category Add(Category newCategory)
{
    // Usa IdGenerator per ottenere il prossimo ID
    newCategory.Id = IdGenerator.GetNextId(_categories);
    _categories.Add(newCategory);
    LoggerHelper.Log($"Aggiunta categoria: {newCategory.Name} (ID: {newCategory.Id})");
    Save(); // Salva i dati dopo l'aggiunta
    return newCategory;
}
```
## Modifica i metodi Update nei servizi per usare IdGenerator
In `Backend/Services/ProductService.cs`, modifica il metodo `Update`:
```csharp
public bool Update(int id, Product updatedProduct)
{
    foreach (var p in _products)
    {
        if (p.Id == id)
        {
            existing = p;
            break;
        }
    }
    if (existing == null)
        return false;
    existing.Name = updatedProduct.Name;
    existing.Price = updatedProduct.Price;
    existing.CategoryId = updatedProduct.CategoryId;
    existing.Category = updatedProduct.Category; // Aggiorna la categoria se necessario
    LoggerHelper.Log($"Aggiornato prodotto ID: {id} con nuovo nome: {updatedProduct.Name}");
    Save(); // Salva i dati dopo l'aggiornamento
    return true;
}
```
Lo stesso con `UserService.cs`, `PurchaseService.cs` e `CategoryService.cs`:
## ValidationHelper
Funzioni per validare dati di input (es: controlla che una stringa non sia vuota, che un prezzo sia positivo, che un indirizzo sia valido ecc.)
```csharp
public static class ValidationHelper
{
    // verifica che la stringa sia un indirizzo email valido
    public static bool IsValidEmail(string email)
    {
        return email.Contains("@"); // Semplice esempio verifica che contenga '@'
    }
    
    // Verifica che una stringa non sia null o vuota
    public static bool IsNotNullOrWhiteSpace(string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    // Verifica che un prezzo sia positivo
    public static bool IsPositiveDecimal(decimal value)
    {
        return value > 0;
    }

    // Verifica che un CAP sia valido (5 cifre)
    public static bool IsValidCAP(string cap)
    {
        // uso out _ per ignorare il valore restituito da int.TryParse perche controllo solo la validità del formato
        // se voglio uso Parse senza out _ ma in questo caso non mi serve perche non mi interessa il valore numerico
        return !string.IsNullOrWhiteSpace(cap) && cap.Length == 5 && int.TryParse(cap, out _);
    }

    // Verifica che un indirizzo sia valido
    // Un indirizzo è valido se ha città, via e CAP non nulli e non vuoti
    public static bool IsValidAddress(Models.Address address)
    {
        return address != null &&
        IsNotNullOrWhiteSpace(address.Citta) &&
        IsNotNullOrWhiteSpace(address.Via) &&
        IsValidCAP(address.CAP);
    }
}
```
## Usa ValidationHelper nei servizi
In `Backend/Services/ProductService.cs`, usa `ValidationHelper` per validare i dati
```csharp
public Product Add(Product newProduct)
{
    // uso ValidationHelper per validare i campi del prodotto
    if (newProduct == null)
    {
        throw new ArgumentNullException(nameof(newProduct), "Il prodotto non può essere null");
    }
    if (!ValidationHelper.IsNotNullOrWhiteSpace(newProduct.Name))
    {
        throw new ArgumentException("Il nome del prodotto non può essere vuoto", nameof(newProduct.Name));
    }
    if (!ValidationHelper.IsPositiveDecimal(newProduct.Price))
    {
        throw new ArgumentException("Il prezzo del prodotto deve essere positivo", nameof(newProduct.Price));
    }
    if (newProduct.CategoryId <= 0)
    {
        throw new ArgumentException("Il CategoryId del prodotto deve essere maggiore di 0", nameof(newProduct.CategoryId));
    }
    newProduct.Id = IdGenerator.GetNextId(_products);
    _products.Add(newProduct);
    LoggerHelper.Log($"Aggiunto prodotto: {newProduct.Name} (ID: {newProduct.Id})");
    Save(); // Salva i dati dopo l'aggiunta
    return newProduct;
}
public bool Update(int id, Product updatedProduct)
{
    // Validazione dei campi del prodotto aggiornato
    if (updatedProduct == null)
    {
        throw new ArgumentNullException(nameof(updatedProduct), "Il prodotto aggiornato non può essere null");
    }
    if (!ValidationHelper.IsNotNullOrWhiteSpace(updatedProduct.Name))
    {
        throw new ArgumentException("Il nome del prodotto non può essere vuoto", nameof(updatedProduct.Name));
    }
    if (!ValidationHelper.IsPositiveDecimal(updatedProduct.Price))
    {
        throw new ArgumentException("Il prezzo del prodotto deve essere positivo", nameof(updatedProduct.Price));
    }
    if (updatedProduct.CategoryId <= 0)
    {
        throw new ArgumentException("Il CategoryId del prodotto deve essere maggiore di 0", nameof(updatedProduct.CategoryId));
    }
    Product existing = null;
    if (_products.Count == 0)
        return false; // Se non ci sono prodotti, non posso aggiornare
    // Trova il prodotto esistente
    foreach (var p in _products)
    {
        if (p.Id == id)
        {
            existing = p;
            break;
        }
    }
    if (existing == null)
        return false;

    existing.Name = updatedProduct.Name;
    existing.Price = updatedProduct.Price;
    existing.CategoryId = updatedProduct.CategoryId;
    existing.Category = updatedProduct.Category; // Aggiorna la categoria se necessario
    LoggerHelper.Log($"Aggiornato prodotto ID: {id} con nuovo nome: {updatedProduct.Name}");
    Save(); // Salva i dati dopo l'aggiornamento
    return true;
}
```
`UserService.cs`
```csharp
public User Add(User newUser)
{
    if (newUser == null)
    {
        throw new ArgumentNullException(nameof(newUser), "L'utente non può essere null");
    }
    if (!ValidationHelper.IsNotNullOrWhiteSpace(newUser.Name))
    {
        throw new ArgumentException("Il nome dell'utente non può essere vuoto", nameof(newUser.Name));
    }
    if (!ValidationHelper.IsValidAddress(newUser.Address))
    {
        throw new ArgumentException("L'indirizzo dell'utente non è valido", nameof(newUser.Address));
    }
    newUser.Id = IdGenerator.GetNextId(_users);
    _users.Add(newUser);
    LoggerHelper.Log($"Aggiunto utente: {newUser.Name} (ID: {newUser.Id})");
    Save(); // Salva i dati dopo l'aggiunta
    return newUser;
}
```
`PurchaseService.cs`
```csharp
public Purchase Add(Purchase newPurchase)
{
    if (newPurchase == null)
    {
        throw new ArgumentNullException(nameof(newPurchase), "L'acquisto non può essere null");
    }
    if (newPurchase.UserId <= 0)
    {
        throw new ArgumentException("L'UserId dell'acquisto deve essere maggiore di 0", nameof(newPurchase.UserId));
    }
    if (newPurchase.ProductId <= 0)
    {
        throw new ArgumentException("Il ProductId dell'acquisto deve essere maggiore di 0", nameof(newPurchase.ProductId));
    }
    if (newPurchase.Quantity <= 0)
    {
        throw new ArgumentException("La quantità dell'acquisto deve essere maggiore di 0", nameof(newPurchase.Quantity));
    }
    if (newPurchase.PurchaseDate == default)
    {
        newPurchase.PurchaseDate = DateTime.UtcNow; // Imposta la data di acquisto se non è specificata
    }
    newPurchase.Id = IdGenerator.GetNextId(_purchases);
    _purchases.Add(newPurchase);
    LoggerHelper.Log($"Aggiunto acquisto ID: {newPurchase.Id} per utente ID: {newPurchase.UserId}");
    Save(); // Salva i dati dopo l'aggiunta
    return newPurchase;
}
public bool Update(int id, Purchase updatedPurchase)
{
    if (updatedPurchase == null)
    {
        throw new ArgumentNullException(nameof(updatedPurchase), "L'acquisto aggiornato non può essere null");
    }
    if (updatedPurchase.UserId <= 0)
    {
        throw new ArgumentException("L'UserId dell'acquisto deve essere maggiore di 0", nameof(updatedPurchase.UserId));
    }
    if (updatedPurchase.ProductId <= 0)
    {
        throw new ArgumentException("Il ProductId dell'acquisto deve essere maggiore di 0", nameof(updatedPurchase.ProductId));
    }
    if (updatedPurchase.Quantity <= 0)
    {
        throw new ArgumentException("La quantità dell'acquisto deve essere maggiore di 0", nameof(updatedPurchase.Quantity));
    }
    Purchase existing = null;
    if (_purchases.Count == 0)
        return false; // Se non ci sono acquisti, non posso aggiornare
    // Trova l'acquisto esistente
    foreach (var p in _purchases)
    {
        if (p.Id == id)
        {
            existing = p;
            break;
        }
    }
    if (existing == null)
        return false;
    existing.UserId = updatedPurchase.UserId;
    existing.ProductId = updatedPurchase.ProductId;
    existing.Quantity = updatedPurchase.Quantity;
    existing.PurchaseDate = updatedPurchase.PurchaseDate; // Aggiorna la data di
    // acquisto se necessario
    LoggerHelper.Log($"Aggiornato acquisto ID: {id} per utente ID: {updatedPurchase.UserId}");
    Save(); // Salva i dati dopo l'aggiornamento
    return true;
}
```
`CategoryService.cs`
```csharp
public Category Add(Category newCategory)
{
    if (newCategory == null)
    {
        throw new ArgumentNullException(nameof(newCategory), "La categoria non può essere null");
    }
    if (!ValidationHelper.IsNotNullOrWhiteSpace(newCategory.Name))
    {
        throw new ArgumentException("Il nome della categoria non può essere vuoto", nameof(newCategory.Name));
    }
    newCategory.Id = IdGenerator.GetNextId(_categories);
    _categories.Add(newCategory);
    LoggerHelper.Log($"Aggiunta categoria: {newCategory.Name} (ID: {newCategory.Id})");
    Save(); // Salva i dati dopo l'aggiunta
    return newCategory;
}
public bool Update(int id, Category updatedCategory)
{
    if (updatedCategory == null)
    {
        throw new ArgumentNullException(nameof(updatedCategory), "La categoria aggiornata non può essere null");
    }
    if (!ValidationHelper.IsNotNullOrWhiteSpace(updatedCategory.Name))
    {
        throw new ArgumentException("Il nome della categoria non può essere vuoto", nameof(updatedCategory.Name));
    }
    Category existing = null;
    if (_categories.Count == 0)
        return false; // Se non ci sono categorie, non posso aggiornare
    // Trova la categoria esistente
    foreach (var c in _categories)
    {
        if (c.Id == id)
        {
            existing = c;
            break;
        }
    }
    if (existing == null)
        return false;
    existing.Name = updatedCategory.Name;
    LoggerHelper.Log($"Aggiornata categoria ID: {id} con nuovo nome: {updatedCategory.Name}");
    Save(); // Salva i dati dopo l'aggiornamento
    return true;
}
public bool Delete(int id)
{
    Category existing = null;
    if (_categories.Count == 0)
        return false; // Se non ci sono categorie, non posso cancellare
    // Trova la categoria esistente
    foreach (var c in _categories)
    {
        if (c.Id == id) 
        {
            existing = c;
            break;
        }
    }
    if (existing == null)
        return false; // Se la categoria non esiste, non posso cancellare
    _categories.Remove(existing);
    LoggerHelper.Log($"Cancellata categoria ID: {id}");
    Save(); // Salva i dati dopo la cancellazione
    return true;
}
```
## Validazione alternativa con Decorators
Si possono validare i dati di input usando il pattern Decorator, che permette di aggiungere funzionalità a un oggetto in modo dinamico.
In questo caso, possiamo creare dei decoratori per validare i dati di input prima di passarli al service principale.
I decoratori sono integrati in dotnet si possono usare cosi:
```csharp
using System.ComponentModel.DataAnnotations;
```
Esempio di decorator di dato obbligatorio
```csharp
[Required]
public string Name { get; set; }
```
Si puo agggiungere un messaggio da trasmettere all utente:
```csharp
[Required(ErrorMessage = "Il nome della categoria è obbligatorio.")]
```
## Decorators piu usati
Nome | Descrizione
--- | ---
[Required] | Campo obbligatorio
[StringLength] | Lunghezza massima di una stringa
[MaxLength] / [MinLength] | Lunghezza massima/minima di una collezione
[Range] | Valore numerico compreso in un intervallo
[EmailAddress] | Verifica che una stringa sia un indirizzo email valido
[Url] | Verifica che una stringa sia un URL valido
[CreditCard] | Verifica che una stringa sia un numero di carta di credito valido
[DataType] | Specifica il tipo di dato (es. DataType.EmailAddress, DataType.Date, DataType.PhoneNumber)
[Compare] | Confronta due proprietà (es. per confermare password)
[Key] | Indica che una proprietà è una chiave primaria
[RegularExpression] | Verifica che una stringa rispetti un'espressione regolare specificata

## Esempi di Decorators
In `Backend/Models/Product.cs`, puoi usare i decoratori per validare i campi
```csharp
using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper
using System.ComponentModel.DataAnnotations; // Importa il namespace per i decoratori
namespace Backend.Models // Backend/Models/Product.cs
{
    public class Product : IIdentifiable // public indica che la classe è accessibile a tutto il programma
    {
        // i metodi get e set sono utilizzati per accedere e modificare le proprietà della classe (i valori)
        [Key]
        public int Id { get; set; } // i metodi e le proprietà sono pubblici per essere accessibili da altri componenti
        
        [Required(ErrorMessage = "Il nome è obbligatorio.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Il nome non può superare i 20 caratteri.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Il prezzo è obbligatorio.")]
        [Range(0.01, 10000, ErrorMessage = "Il prezzo deve essere compreso tra 0.01 e 10000.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La categoria è obbligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La categoria deve essere valida.")]
        public int CategoryId { get; set; }
    }
}

using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper
using System.ComponentModel.DataAnnotations; // Importa il namespace per i decoratori
namespace Backend.Models
{
    public class Purchase : IIdentifiable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'utente è obbligatorio.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Il prodotto è obbligatorio.")]
        public int ProductId { get; set; }

        [Range(1, 9999, ErrorMessage = "La quantità deve essere almeno 1.")]
        public int Quantity { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PurchaseDate { get; set; }
    }
}

using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper
using System.ComponentModel.DataAnnotations; // Importa il namespace per i decoratori
namespace Backend.Models // Backend/Models/Product.cs
{
    public class Category : IIdentifiable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome della categoria è obbligatorio.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Il nome deve essere lungo almeno 2 caratteri.")]
        public string Name { get; set; }
    }
}

using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper
using System.ComponentModel.DataAnnotations; // Importa il namespace per i decoratori
namespace Backend.Models
{
    public class User : IIdentifiable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Il nome deve essere lungo almeno 3 caratteri.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "L'indirizzo è obbligatorio.")]
        public Address Address { get; set; }
    }
}

using Backend.Utils; // Importa il namespace Backend.Utils per utilizzare JsonFileHelper
using System.ComponentModel.DataAnnotations; // Importa il namespace per i decoratori
namespace Backend.Models
{
    public class Address
    {
        [Required(ErrorMessage = "La città è obbligatoria.")]
        [StringLength(50)]
        public string Citta { get; set; }

        [Required(ErrorMessage = "La via è obbligatoria.")]
        [StringLength(100)]
        public string Via { get; set; }

        [Required(ErrorMessage = "Il CAP è obbligatorio.")]
        [StringLength(5, ErrorMessage = "Il CAP non può superare i 5 caratteri.")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Il CAP deve essere un numero di 5 cifre.")]
        [DataType(DataType.PostalCode)]
        public string CAP { get; set; }
    }
}
```
## Aggiungi i decoratori nei controller
In `Backend/Controllers/ProductsController.cs`, puoi usare i decoratori per validare i dati di input nei metodi `Add` e `Update` con ModelState.IsValid:
```csharp
// Controlla se il modello è valido
// ModelState.IsValid verifica se il modello passato è valido secondo le regole di validazione definite
// se non è valido, restituisce un BadRequest con gli errori di validazione
if (!ModelState.IsValid)
{
    return BadRequest(ModelState);
}
```
ModelState.IsValid controlla i dati lanciando un errore 400 indicando quali campi non sono validi e perché.
## DTOHelper
metodi statici per convertire da modello a DTO e viceversa
In `Backend/Utils/DTOHelper.cs`, crea una classe statica `DTOHelper`:
```csharp
using Backend.Models;
using Backend.DTOs;
using System.Collections.Generic;

namespace Backend.Utils
{
    public static class DTOHelper
    {
        public static ProductDTO ToProductDTO(Product product, Category category)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryName = category != null ? category.Name : "Sconosciuta"
            };
        }

        public static UserDTO ToUserDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Address = user.Address
            };
        }

        public static PurchaseDTO ToPurchaseDTO(Purchase purchase, User user, Product product, string categoryName)
        {
            return new PurchaseDTO
            {
                Id = purchase.Id,
                UserName = user != null ? user.Name : "Sconosciuto",
                ProductName = product != null ? product.Name : "Sconosciuto",
                Quantity = purchase.Quantity,
                PurchaseDate = purchase.PurchaseDate,
                ProductCategory = categoryName
            };
        }

        public static CategoryDTO ToCategoryDTO(Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
```
## Modifica i controller per usare DTOHelper
In `Backend/Controllers/ProductsController.cs`, modifica il metodo `Get`:
```csharp
[HttpGet]
public ActionResult<List<ProductDTO>> Get()
{
    List<Product> products = _service.GetAll();
    List<Category> categories = _categoryService.GetAll();
    List<ProductDTO> result = new List<ProductDTO>();
    
    foreach (Product prod in products)
    {
        foreach (Category cat in categories)
        {
            if (cat.Id == prod.CategoryId)
            {
                // Trovata la categoria associata
                ProductDTO dto = DTOHelper.ToProductDTO(prod, cat);
                result.Add(dto);
                break; // Esci dal ciclo una volta trovata la categoria
            }
        }
        ProductDTO dto = DTOHelper.ToProductDTO(prod, cat);
        result.Add(dto);
    }
    return Ok(result);
}
```
In `Backend/Controllers/ProductsController.cs`, modifica il metodo `GetById`:
```csharp
[HttpGet("{id}")]
public ActionResult<ProductDTO> Get(int id)
{
    Product p = _service.GetById(id);
    if (p == null)
    {
        return NotFound();
    }

    Category cat = _categoryService.GetById(p.CategoryId);
    ProductDTO dto = DTOHelper.ToProductDTO(p, cat);
    return Ok(dto);
}
```
Lo stesso con `UserController.cs`, `PurchaseController.cs` e `CategoryController.cs`