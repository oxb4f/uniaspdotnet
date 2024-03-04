namespace lr4.Controller;

using Microsoft.AspNetCore.Mvc;

[Route("cookie")]
public class CookieController : Controller
{
    [HttpPost("set")]
    public IActionResult Set(string value, string expiration)
    {
        if (!DateTime.TryParse(expiration, out var exp)) return BadRequest("Invalid date format.");
        var option = new CookieOptions
        {
            Expires = exp
        };
        Response.Cookies.Append("MyCookie", value, option);
        return Ok("Cookie has been set.");
    }

    [HttpGet("check")]
    public IActionResult Check()
    {
        string cookieValue = Request.Cookies["MyCookie"] ?? string.Empty;
        return Ok($"Cookie Value: {cookieValue}");
    }
    
    [HttpGet("error")]
    public IActionResult TriggerError()
    {
        throw new Exception("This is a test exception.");
    }
}
