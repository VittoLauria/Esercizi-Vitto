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
        // Controlla se il modello è valido
        // ModelState.IsValid verifica se il modello passato è valido secondo le regole di validazione definite
        // se non è valido, restituisce un BadRequest con gli errori di validazione
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        User created = _service.Add(user);
        return CreatedAtAction("Get", new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] User user)
    {
        // Controlla se il modello è valido
        // ModelState.IsValid verifica se il modello passato è valido secondo le regole di validazione definite
        // se non è valido, restituisce un BadRequest con gli errori di validazione
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
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