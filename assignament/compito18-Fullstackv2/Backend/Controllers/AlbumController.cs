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
        public AlbumController(AlbumSerive albumService)
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
            if (album is null)
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

        [HttpDelete("{id}")]

        public ActionResult DeleteAlbum(int id)
        {
            _albumService.DeleteAlbum(id);
        }

        [HtppPost("{id}")]
        public ActionResult UpdateAlbum(int id)
        {
            bool success = _albumService.UpdateAlbum(id);
            if (success == false)
            {
                return NotFound("Errore nella modificazione del file");
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAlbum(int id)
        {
            bool success = _albumService.DeleteAlbum(id);
            if (success == false)
            {
                return NotFound("Errore nella cancellazione del file");
            }
            else
            {
                return NoContent();
            }
        }

    }
}