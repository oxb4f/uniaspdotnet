using lr8.Models;

namespace lr8.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var products = new List<Product>
        {
            new() { ID = 1, Name = "Product 1", Price = 100 },
            new() { ID = 2, Name = "Product 2", Price = 200 },
            new() { ID = 3, Name = "Product 3", Price = 300 }
        };
        
        return View(products);
    }
}
