using Microsoft.AspNetCore.Mvc;
using test_retake.Services;

namespace test_retake.Controllers;

[Route("api/musician")]
[ApiController]
public class MusicianController : ControllerBase
{
    private IDbService _service;

    public MusicianController(IDbService service)
    {
        _service = service;
    }

    [HttpDelete("idMusician")]
    public IActionResult DeleteMusician(int idMusician)
    {
        _service.DeleteMusician(idMusician);
        return NoContent();
    }
}