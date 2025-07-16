using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UserService _service;

    public UsersController(UserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    // GET api/users
    [HttpGet]
    public ActionResult<List<User>> Get()
    {
        List<User> users = _service.GetAll();
        return Ok(users);
    }

    // GET api/users/2
    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        var u = _service.GetById(id);
        if (u is null)
        {
            return NotFound();
        }
        return u;
    }

    // POST api/users
    [HttpPost]
    public ActionResult<User> Post([FromBody] User user)
    {
        User created = _service.Add(user);
        return CreatedAtAction(
            actionName: nameof(Get),
            routeValues: new { id = created.Id },
            value: created
        );
    }

    // PUT api/users/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] User user)
    {
        bool success = _service.Update(id, user);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }

    // DELETE api/users/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool success = _service.Delete(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}