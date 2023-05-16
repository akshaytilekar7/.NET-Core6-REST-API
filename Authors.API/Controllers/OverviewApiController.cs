using Authors.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace controllers.Controllers;

[ApiController]
[Route("OverviewApi")]
public class OverviewApiController : ControllerBase
{

    [HttpGet("getobject")]
    public object GetObject()
    {
        return GetAuthor();
    }

    // returns a 204 no content with no body
    // response type header is not set
    [HttpGet("getobjectnull")]
    public object GetObjectNull()
    {
        return null;
    }

    // Note - WILL SET RESPONSE TYPE TO TEXT/PLAIN
    [HttpGet("getstring")]
    public string GetString()
    {
        return JsonSerializer.Serialize(GetAuthor());
    }

    [HttpGet("getjson")]
    public JsonResult GetJson()
    {
        return new JsonResult(GetAuthor());
    }

    [HttpGet("getiactionresult")]
    public IActionResult GetIActionResult()
    {
        return Ok(GetAuthor());
    }

    [HttpGet("getiactionresult<T>")]
    public ActionResult<AuthorDto> GetActionResultOfT()
    {
        return Ok(GetAuthor());
    }

    private AuthorDto GetAuthor()
    {
        return new AuthorDto();
    }
}
