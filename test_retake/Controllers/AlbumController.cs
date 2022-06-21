using Microsoft.AspNetCore.Mvc;
using test_retake.Services;

namespace test_retake.Controllers;

[Route("api/album")]
[ApiController]
public class AlbumController : ControllerBase
{
    private IDbService _service;

    public AlbumController(IDbService service)
    {
        _service = service;
    }

    [HttpGet("IdAlbum")]
    public IActionResult GetAlbum(int IdAlbum)
    {
        if (_service.CheckIdAlbum(IdAlbum) == false)
            return BadRequest("FALSE ID");
        
        var result = _service.GetAlbum(IdAlbum);
        return Ok(result);
    }
}