using Microsoft.AspNetCore.Mvc;

namespace lr3;

[Route("Library")]
public class LibraryController(IConfiguration configuration) : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return Content("Welcome to the Library!");
    }

    [HttpGet("Books")]
    public IActionResult Books()
    {
        var books = configuration.GetSection("Books").Get<List<string>>();
        return Json(books);
    }

    [HttpGet("Profile/{id:int?}")]
    public IActionResult Profile(int? id)
    {
        if (id is not (>= 0 and <= 5)) return Content("Information about the current user.");
        var users = configuration.GetSection("Users").Get<List<string>>();
        if (users != null && id.Value < users.Count)
        {
            return Content($"User Information: {users[id.Value]}");
        }
        return NotFound("User not found.");
    }
}