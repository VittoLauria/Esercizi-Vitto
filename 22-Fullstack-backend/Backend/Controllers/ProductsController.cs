using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController] // le direttive tra parentesi quadre sono un attributo che in questo caso permette di definire la classe come un controller API
[Route("api/[controller]")] // indica il percorso base per le richieste a questo controller
public class ProductsController : ControllerBase // i due punti indicano che la classe ProductsController estende la classe ControllerBase
// quindi la classe derivata ricevera le proprieta ed i comportamenti della classe base
{
    // istanza di ProductService per gestire le operazioni sui prodotti
    private readonly ProductService _service; // private è il modificatore di accesso
                                              // readonly indica che il campo può essere assegnato solo nel costruttore in pratica è di sola lettura
                                              // ProductService è il tipo del campo, che rappresenta il servizio per la gestione dei prodotti
                                              // _service è il nome del campo, che segue la convenzione di denominazione per i campi privati (inizia con un underscore)
    private readonly CategoryService _categoryService; // servizio per gestire le categorie dei prodotti
    // costruttore della classe ProductsController
    // accetta un parametro di tipo ProductService e lo assegna al campo _service
    // il costruttore viene chiamato quando si crea un'istanza della classe
    // in questo modo il controller può utilizzare il servizio per gestire le operazioni sui prodotti
    // public ProductsController(ProductService service) => _service = service;
    public ProductsController(ProductService service, CategoryService categoryService)
{
    if (service == null)
        throw new ArgumentNullException("service");
    if (categoryService == null)
        throw new ArgumentNullException("categoryService");
    _service = service;
    _categoryService = categoryService;
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

    // POST api/products
    [HttpPost]
    public ActionResult<Product> Post([FromBody] Product prod)
    {
        // Controlla se il modello è valido
        // ModelState.IsValid verifica se il modello passato è valido secondo le regole di validazione definite
        // se non è valido, restituisce un BadRequest con gli errori di validazione
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
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
        // Controlla se il modello è valido
        // ModelState.IsValid verifica se il modello passato è valido secondo le regole di validazione definite
        // se non è valido, restituisce un BadRequest con gli errori di validazione
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
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
