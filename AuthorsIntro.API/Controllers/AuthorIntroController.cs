using Microsoft.AspNetCore.Mvc;

namespace AuthorsIntro.API.Controllers;

[Route("api/authorcovers")]
[ApiController]
public class AuthorIntroController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookCover(string id, bool returnFault = false)
    {
        if (returnFault)
        {
            await Task.Delay(100);
            return new StatusCodeResult(500);
        }

        var random = new Random();
        int fakeCoverBytes = random.Next(5097152, 10485760);
        byte[] fakeCover = new byte[fakeCoverBytes];
        random.NextBytes(fakeCover);

        return Ok(new
        {
            Id = id,
            Content = fakeCover
        });
    }
}

