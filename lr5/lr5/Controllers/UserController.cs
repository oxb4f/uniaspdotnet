namespace lr5.Controllers;

using Microsoft.AspNetCore.Mvc;
using lr5.Models;

public class UserController : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            if (user.Age > 16)
            {
                return RedirectToAction("SelectQuantity", "Product");
            }
        }
        return View(user);
    }
}
