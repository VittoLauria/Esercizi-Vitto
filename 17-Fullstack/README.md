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

Eventuali errori HTTP (404, 500) vengono intercettati e mostrati all’user tramite un componente di alert.

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
### 1. Navigazione catalogo (user anonimo)

**Obiettivo:** l’user vede la lista prodotti.

> Flusso:

- Il componente CatalogoComponent invoca ProdottiService.getProdotti().
- HTTP GET a /api/prodotti.
- Ricezione JSON → assegnazione a this.prodotti.
- *ngFor="let p of prodotti" genera un card per ogni prodotto.

L’user clicca “Dettagli”.

### 2. Visualizzazione dettaglio prodotto

**Obiettivo:** mostrare descrizione estesa, immagini, prezzo.

> Flusso:

- DettaglioComponent legge route.params['id'].
- Chiama /api/prodotti/{id}.
- Si presenta la scheda prodotto con formattazione HTML/CSS.

### 3. Ricerca e filtraggio

**Obiettivo:** user filtra per categoria o range di prezzo.

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

Esperienza user: SPA client-side reattiva, reload minimizzato.

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

# Aggiunta entita User e Purchase
Dentro la folder Models creo il modello user.cs;(Modelli sempre al singolare)
 public class user
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
    }

 Creo il Service di user.fatto su file direttamente



# Frontend: Angular
Genera il progetto
Da root SimpleCatalog:

```bash
ng new Frontend --routing=false --style=css
```
## Components o modules

**Casi d’uso consigliati**

Scenario	| Consiglio
--- | ---
App nuova di medie/piccole dimensioni	| Standalone per rapidità e bundle più snello.
Grande applicazione enterprise	| Mantieni NgModules per chiara separazione feature.
Libreria di componenti riusabili	| Preferisci Standalone per import diretto e tree-shaking.
Integrazione con librerie legacy che usano moduli	| Usa NgModules per compatibilità.

**Pro e contro riassuntivi**

- Standalone Components semplificano sviluppo e ottimizzazione, specie in progetti più piccoli o librerie.
- NgModules restano utili per organizzare grandi codebase in feature module isolati e per garantire compatibilità con l’ecosistema

## Crea model e service

```bash
ng generate interface product --type=model
ng generate service product
```
In src/app/product.model.ts:

```ts
export interface Product {
  id: number;
  name: string;
  price: number;
}
```
In src/app/product.service.ts:

```ts
import { Injectable } from '@angular/core'; // Injectable indica che questa classe può essere iniettata come servizio
import { HttpClient } from '@angular/common/http'; // HttpClient è il modulo per effettuare richieste HTTP
import { Observable } from 'rxjs'; // Observable è un tipo di dato che rappresenta un flusso di dati asincrono
import { Product } from './product.model'; // Product è l'interfaccia classe che definisce la struttura dei prodotti

@Injectable({ providedIn: 'root' })
export class ProductService {
  private apiUrl = 'http://localhost:5296/api/products'; // !! <- Cambia la porta se necessario

  constructor(private http: HttpClient) {}

  // RITORNA (GET)
  // questo metodo restituisce un Observable di tipo Product[]
  getAll(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl);
  }

  // RITORNA (GET) per ID
  // questo metodo restituisce un Observable di tipo Product
  getById(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/${id}`);
  }

  // CREA (POST)
  // questo metodo restituisce un Observable di tipo Product
  add(prod: Product): Observable<Product> {
    return this.http.post<Product>(this.apiUrl, prod);
  }

  // AGGIORNA (PUT)
  // questo metodo restituisce un Observable di tipo void
  update(id: number, prod: Product): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, prod);
  }

  // ELIMINA (DELETE)
  // questo metodo restituisce un Observable di tipo void
  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
```
## Crea il componente di lista

```bash
ng generate component product-list
```
In src/app/product-list/product-list.component.ts:

```ts
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Product } from '../product.model';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [ CommonModule ],
  template: `
    <h2>Catalogo Prodotti</h2>
    <ul>
      <li *ngFor="let p of products">
        {{ p.name }} — € {{ p.price }}
      </li>
    </ul>
  `
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];

  constructor(private svc: ProductService) {}

  ngOnInit(): void {
    this.svc.getAll().subscribe(list => this.products = list);
  }
}
```
In product-list.component.html:

```html
<h2>Catalogo Prodotti</h2>
<ul>
  <li *ngFor="let p of products">
    {{p.name}} — € {{p.price}}
  </li>
</ul>
```
## Visualizza il componente
In src/app/app.component.html sostituisci con:

```html
<nav>
  <a routerLink="">Home</a>
  <a routerLink="admin">Admin</a>
</nav>
<router-outlet></router-outlet>
```
Avvia l’app

```bash
ng serve
```
Apri il browser su http://localhost:4200/

# Components

In un’app Angular “single-page” non ci sono file .cshtml o pagine separate come in MVC: tutte le “pagine” sono in realtà componenti con il loro template HTML.

Ecco dove e come trovarle (o crearle):

## 1. Il punto di partenza: index.html

Si trova in

```bash
src/index.html
```

ed è il contenitore generale della tua app.

Al suo interno c’è una riga come

```html
<app-root></app-root>
```
```html
<!doctype html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <title>Frontend</title>
  <base href="/">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="icon" type="image/x-icon" href="favicon.ico">
</head>
<body>
  <app-root></app-root>
</body>
</html>
```
che è il tag del tuo AppComponent.

## 2. Il “router outlet” o il AppComponent
Se stai usando il router (rotta /admin per l’amministrazione, / per il catalogo), nel template di AppComponent (src/app/app.component.html) troverai qualcosa tipo:

```html
<nav>
  <a routerLink="">Home</a>
  <a routerLink="admin">Admin</a>
</nav>
<router-outlet></router-outlet>
```

router-outlet è dove Angular inserisce il template del componente corrispondente alla rotta attiva.

Se invece non hai il router e stai semplicemente includendo i componenti direttamente, nel suo template vedrai:

```html
<app-product-list></app-product-list>
<!-- oppure -->
<app-admin></app-admin>
```

## 3. La pagina “Catalogo Prodotti”
Componente: ProductListComponent

File HTML:

src/app/product-list/product-list.component.html

Cosa contiene: di solito una <ul> o una <table> che ngFor-a su products per mostrarli.

Per esempio:

```html
<h2>Catalogo Prodotti</h2>
<ul>
  <li *ngFor="let p of products">
    {{p.name}} — € {{p.price}}
  </li>
</ul>
```

# 4. La pagina “Admin” (Aggiungi/Modifica/Elimina)
Componente: AdminComponent

```bash
ng generate component admin
```

File HTML:

```html
src/app/admin/admin.component.html
```

Esempio di template:

```html
<h2>Gestione Prodotti</h2>

<!-- Form di inserimento -->
<div>
  <input [(ngModel)]="newName" placeholder="Nome prodotto">
  <input [(ngModel)]="newPrice" type="number" placeholder="Prezzo">
  <button (click)="onAdd()">Aggiungi</button>
</div>

<!-- Lista con azioni -->
<ul>
  <li *ngFor="let p of products">
    {{p.name}} — € {{p.price}}
    <button (click)="onUpdate(p)">+1€</button>
    <button (click)="onDelete(p.id)">Elimina</button>
  </li>
</ul>
```
Il (click) su Aggiungi invoca onAdd() che chiama add() nel tuo ProductService.

Ogni riga ha un +1€ che chiama update(id, product), e un Elimina che chiama delete(id).

# 5. Il routing (opzionale)
In src/app/app-routing.module.ts:

```ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { ProductListComponent } from './product-list/product-list.component';

const routes: Routes = [
  { path: '',      component: ProductListComponent },
  { path: 'admin', component: AdminComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
```

In pratica

Apri src/app/product-list/product-list.component.html per vedere il catalogo.

Apri (o crea) src/app/admin/admin.component.html per vedere/la gestione CRUD.

Apri src/app/app.component.html (o il routing) per capire quale di questi due componenti viene mostrato al caricamento della tua SPA.

Così, collegando i pulsanti <button (click)> ai metodi onAdd(), onUpdate() e onDelete(), vedrai le chiamate POST, PUT e DELETE che hai già definito nel backend

## Implementazioni

Al momento la app permette di modificare il prezzo con un pulsante che incrementa di 1€

AdminComponent che ti permette di:

- Incrementare o decrementare il prezzo di € 1
- Modificare il nome direttamente nell’input
- Salvare automaticamente la modifica del nome quando esci dal campo (evento blur)

```ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../product.service';
import { Product } from '../product.model';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [ CommonModule, FormsModule ],
  template: `
    <h2>Gestione Prodotti</h2>

    <!-- Aggiungi nuovo prodotto -->
    <div>
      <input [(ngModel)]="newName" placeholder="Nome prodotto">
      <input [(ngModel)]="newPrice" type="number" placeholder="Prezzo">
      <button (click)="onAdd()">Aggiungi</button>
    </div>

    <!-- Lista prodotti con azioni -->
    <ul>
      <li *ngFor="let p of products">
        <!-- Modifica nome inline; al blur salva la modifica -->
        <input 
          [(ngModel)]="p.name" 
          (blur)="onNameChange(p)" 
        />

        — € {{ p.price }}

        <!-- Aggiungi o sottrai 1€ -->
        <button (click)="adjustPrice(p,  1)">+1€</button>
        <button (click)="adjustPrice(p, -1)">-1€</button>

        <!-- Elimina -->
        <button (click)="onDelete(p.id)">Elimina</button>
      </li>
    </ul>
  `
})
export class AdminComponent implements OnInit {
  products: Product[] = [];
  newName = '';
  newPrice = 0;

  constructor(private svc: ProductService) {}

  ngOnInit(): void {
    this.load();
  }

  private load(): void {
    this.svc.getAll().subscribe(list => this.products = list);
  }

  onAdd(): void {
    const prod: Product = { id: 0, name: this.newName, price: this.newPrice };
    this.svc.add(prod).subscribe(() => this.load());
  }

  adjustPrice(p: Product, delta: number): void {
    const updated: Product = { ...p, price: p.price + delta };
    this.svc.update(p.id, updated)
      .subscribe(() => this.load());
  }

  onNameChange(p: Product): void {
    // p.name è già aggiornato via ngModel
    this.svc.update(p.id, p)
      .subscribe(() => this.load());
  }

  onDelete(id: number): void {
    this.svc.delete(id)
      .subscribe(() => this.load());
  }
}
```
Cosa è cambiato:

Template

- Aggiunti due pulsanti per adjustPrice(p, +1) e adjustPrice(p, -1).

- L’input del nome ora usa (blur)="onNameChange(p)" per salvare la modifica quando perdi il fuoco.

Classe

- Metodo adjustPrice(p, delta) che costruisce un nuovo Product con prezzo modificato e chiama update.

- Metodo onNameChange(p) che sfrutta il binding ngModel su p.name e invia subito il PUT con il prodotto aggiornato.

Imports

- Hai già CommonModule e FormsModule per usare *ngFor, ngModel e blur.

