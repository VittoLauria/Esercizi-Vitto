using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

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
        {
            return NotFound();
        }
        return cat;
    }

    [HttpPost]
    public ActionResult<Category> Post([FromBody] Category newCategory)
    {
        // Controlla se il modello è valido
        // ModelState.IsValid verifica se il modello passato è valido secondo le regole di validazione definite
        // se non è valido, restituisce un BadRequest con gli errori di validazione
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (newCategory == null)
            return BadRequest("Category cannot be null");
        if (string.IsNullOrWhiteSpace(newCategory.Name))
            return BadRequest("Category name cannot be empty");
        Category addedCategory = _service.Add(newCategory);
        return CreatedAtAction(nameof(Get), new { id = addedCategory.Id }, addedCategory);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        bool removed = _service.Delete(id);
        if (!removed)
        {
            return NotFound($"Category with ID {id} not found");
        }
        return NoContent(); // 204 No Content
    }
}