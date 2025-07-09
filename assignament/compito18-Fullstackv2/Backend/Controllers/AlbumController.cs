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

        [HtppPost]
        public ActionResult AddAlbum(Album album)
        {
            _albumService.AddAlbum(album);
            return CreatedAtAction(nameof(GetAlbum),
             new { id = album.Id },
            album);
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteAlbum(int id)
        {
            _albumService.DeleteAlbum(id);
        }

    }
}