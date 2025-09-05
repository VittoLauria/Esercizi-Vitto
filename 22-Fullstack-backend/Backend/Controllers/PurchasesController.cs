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
        // Controlla se il modello è valido
        // ModelState.IsValid verifica se il modello passato è valido secondo le regole di validazione definite
        // se non è valido, restituisce un BadRequest con gli errori di validazione
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        Purchase created = _service.Add(purchase);
        return CreatedAtAction("Get", new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Purchase purchase)
    {
        // Controlla se il modello è valido
        // ModelState.IsValid verifica se il modello passato è valido secondo le regole di validazione definite
        // se non è valido, restituisce un BadRequest con gli errori di validazione
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
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