using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AcquistoController : ControllerBase
    {
        private readonly AcquistoService _acquistoService;
        private readonly UtenteService _utenteService;
        private readonly AlbumService _albumService;

        public AcquistoController(AlbumService albumService, AcquistoService acquistoService, UtenteService utenteService)
        {
                _albumService = albumService ?? throw new ArgumentNullException(nameof(albumService));
                _acquistoService = acquistoService ?? throw new ArgumentNullException(nameof(acquistoService));
                _utenteService = utenteService ?? throw new ArgumentNullException(nameof(utenteService));    
        }

        [HttpGet]
        public ActionResult<List<AcquistoDTO>> GetAllAcquisti()
        {
            List<Acquisto> acquisti = _acquistoService.GetAllAcquisti();
            List<Utente> utenti = _utenteService.GetAllUtenti();
            List<Album> albums = _albumService.GetAllAlbums();
            List<AcquistoDTO> result = new List<AcquistoDTO>();

            foreach (Acquisto acquisto in acquisti)
            {
                Utente utente = null;
                Album album = null;
                foreach (Utente u in utenti)
                {
                    if (u.Id == acquisto.UtenteId)
                    {
                        utente = u;
                        break;
                    }
                }
                foreach (Album a in albums)
                {
                    if (a.Id == acquisto.AlbumId)
                    {
                        album = a;
                        break;
                    }
                }

                AcquistoDTO dto = new AcquistoDTO
                {
                    Id = acquisto.Id,
                    NomeUtente = utente != null ? utente.Nome : "Sconosciuto",
                    TitoloAlbum = album != null ? album.Titolo : "Sconosciuto",
                    Canzoni = album != null ? album.Canzoni : new List<Canzone>(),
                    DataAcquisto = acquisto.DataAcquisto.ToString("dd/MM/yyyy")
                };
                // Aggiungo il DTO alla lista dei risultati
                result.Add(dto);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]

        public ActionResult<Acquisto> GetAcquisto(int id)
        {
            var acquisto = _acquistoService.GetAcquisto(id);
            if (acquisto == null)
            {
                return NotFound();
            }
            return Ok(acquisto);
        }

        [HttpPost]
        public ActionResult AddAcquisto(Acquisto acquisto)
        {
            _acquistoService.AddAcquisto(acquisto);
            return CreatedAtAction(nameof(GetAcquisto), new { id = acquisto.Id }, acquisto);
        }
        /*
            [HttpPut("{id}")]
            public ActionResult UpdateAcquisto(int id, Acquisto updatedAcquisto)
            {
                var acquisto = _acquistoService.GetAcquisto(id);
                if (acquisto == null)
                {
                    return NotFound("Errore nella modificazione del file");
                }

                _acquistoService.UpdateAcquisto(id, updatedAcquisto);
                    return Accepted(new { message = "Acquisto modificato" });
            }
            */

        [HttpDelete("{id}")]
        public ActionResult DeleteAcquistoById(int id)
        {
            var acquisto = _acquistoService.GetAcquisto(id);
            if (acquisto == null)
            {
                return NotFound("Errore nella cancellazione del file");
            }

            _acquistoService.DeleteAcquistoById(id);
            return NoContent();

        }

    }
}

