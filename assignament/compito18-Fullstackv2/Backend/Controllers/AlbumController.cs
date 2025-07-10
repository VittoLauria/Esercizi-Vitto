using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/albums")]

    public class AlbumController : ControllerBase
    {
        private readonly AlbumService _albumService;
        public AlbumController(AlbumService albumService)
        {
            _albumService = albumService;
        }


        [HttpGet]

        public ActionResult<List<Album>> GetAllAlbums()
        {
            return _albumService.GetAllAlbums();
        }

        [HttpGet("{id}")]

        public ActionResult<Album> GetAlbum(int id)
        {
            var album = _albumService.GetAlbum(id);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        [HttpPost]
        public ActionResult AddAlbum(Album album)
        {
            _albumService.AddAlbum(album);
            return CreatedAtAction(nameof(GetAlbum),new { id = album.Id },album);
        }

   


        [HttpPut("{id}")]
        public ActionResult UpdateAlbum(int id, Album updatedAlbum)
        {
            var album = _albumService.GetAlbum(id);
            if (album == null)
            {
                return NotFound("Errore nella modificazione del file");
            }
          
            _albumService.UpdateAlbum(id, updatedAlbum);
                return Accepted(new { message = "Album modificato" });
        }
        

        [HttpDelete("{id}")]
        public ActionResult DeleteAlbumById(int id)
        {
            var album = _albumService.GetAlbum(id);
            if (album == null)
            {
                return NotFound("Errore nella cancellazione del file");
            }
            
            _albumService.DeleteAlbumById(id);
                return NoContent();
            
        }

    }
}