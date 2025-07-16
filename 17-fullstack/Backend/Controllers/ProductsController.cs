using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController] // le direttive tra parentesi quadre sono un attributo che in questo caso permette di definire la classe come un controller API
[Route("api/products")] // indica il percorso base per le richieste a questo controller
public class ProductsController : ControllerBase // i due punti indicano che la classe ProductsController estende la classe ControllerBase
// quindi la classe derivata ricevera le proprieta ed i comportamenti della classe base
{
    // istanza di ProductService per gestire le operazioni sui prodotti
    private readonly ProductService _service; // private è il modificatore di accesso
                                              // readonly indica che il campo può essere assegnato solo nel costruttore in pratica è di sola lettura
                                              // ProductService è il tipo del campo, che rappresenta il servizio per la gestione dei prodotti
                                              // _service è il nome del campo, che segue la convenzione di denominazione per i campi privati (inizia con un underscore)

    // costruttore della classe ProductsController
    // accetta un parametro di tipo ProductService e lo assegna al campo _service
    // il costruttore viene chiamato quando si crea un'istanza della classe
    // in questo modo il controller può utilizzare il servizio per gestire le operazioni sui prodotti
    // public ProductsController(ProductService service) => _service = service;
    public ProductsController(ProductService service) // l argomento del costruttore è il servizio che gestisce i prodotti in questo caso ProductService
    {
        // il throw serve a lanciare un'eccezione se il servizio è null
        // in pratica se il servizio non viene passato al costruttore l'applicazione non può funzionare
        // nameof service restituisce il nome della variabile service come stringa in modo da evitare errori
        // ?? è l'operatore di coalescenza null, che restituisce il valore a sinistra se non è null, altrimenti restituisce il valore a destra
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    // GET api/products
    // metodo per ottenere tutti i prodotti
    [HttpGet] // indica che questo metodo risponde alle richieste HTTP GET
              // ci possono essere vari tipi di richieste HTTP come GET, POST, PUT, DELETE
              // GET indica che il metodo recupera dati dal server passandoli come risposta in formato JSON
              // POST indica che i dati vengono passati in chiaro cioe attraverso il corpo della richiesta oppure il campo url del browser

    // metodo Get che restituisce una lista di prodotti
    // ActionResult<List<Product>> indica che il metodo restituisce un risultato di tipo List<Product
    // public ActionResult<List<Product>> Get() => _service.GetAll(); // lambda expression
    public ActionResult<List<Product>> Get() // metodo per ottenere tutti i prodotti
    // ActionResult<List<Product>> indica che il metodo restituisce un'azione HTTP con una lista di prodotti
    {
        List<Product> products = _service.GetAll(); // chiama il servizio per ottenere tutti i prodotti
        return Ok(products); // restituisce i prodotti con lo stato HTTP 200 OK
                             // e una convenzione di ASP.NET in modo da restituire un risultato di tipo ActionResult cioe una risposta HTTP 200 ok
    }

    // GET api/products/2
    // metodo per ottenere un prodotto specifico in base all'ID
    [HttpGet("{id}")] // DATA BINDING indica che questo metodo risponde alle richieste HTTP GET con un parametro di percorso {id}
    public ActionResult<Product> Get(int id)
    {
        // devo costruire il prodotto in base all'ID passato come parametro
        var p = _service.GetById(id);
        if (p is null)
        {
            return NotFound();
        }
        return p;
    }

    // POST api/products
    [HttpPost]
    public ActionResult<Product> Post([FromBody] Product prod)
    {
        // Aggiunge il prodotto e ottiene l’istanza creata
        Product created = _service.Add(prod);

        // Restituisce 201 Created con header Location che punta a GET api/products/{id}
        return CreatedAtAction(
            actionName: nameof(Get), // nome dell'azione che gestisce la richiesta GET per ottenere un prodotto
            routeValues: new { id = created.Id }, // valori della rotta che includono l'ID del prodotto creato
            value: created // il valore restituito è il prodotto creato
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

}
