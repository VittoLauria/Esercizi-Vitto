using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/utenti")]

    public class UtenteController : ControllerBase
    {
        private readonly UtenteService _utenteService;
        public UtenteController(UtenteService utenteService)
        {
            _utenteService = utenteService;
        }


        [HttpGet]

        public ActionResult<List<Utente>> GetAllUtenti()
        {
            return _utenteService.GetAllUtenti();
        }

        [HttpGet("{id}")]

        public ActionResult<Utente> GetUtente(int id)
        {
            var utente = _utenteService.GetUtente(id);
            if (utente == null)
            {
                return NotFound();
            }
            return Ok(utente);
        }

        [HttpPost]
        public ActionResult AddUtente(Utente utente)
        {
            _utenteService.AddUtente(utente);
            return CreatedAtAction(nameof(GetUtente),new { id = utente.Id },utente);
        }

   
        [HttpPut("{id}")]
        public ActionResult UpdateUtente(int id, Utente updatedUtente)
        {
            var utente = _utenteService.GetUtente(id);
            if (utente == null)
            {
                return NotFound("Errore nella modificazione del file");
            }
          
            _utenteService.UpdateUtente(id, updatedUtente);
                return Accepted(new { message = "Utente modificato" });
        }
        

        [HttpDelete("{id}")]
        public ActionResult DeleteUtenteById(int id)
        {
            var utenti = _utenteService.GetUtente(id);
            if (utenti == null)
            {
                return NotFound("Errore nella cancellazione del file");
            }
            
            _utenteService.DeleteUtenteById(id);
            return Accepted(new { message = "Utente eliminato" });
            
        }

    }
}