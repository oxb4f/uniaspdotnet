using lr7.Models;

namespace lr7.Controllers;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        var products = new List<Product>();
        var random = new Random();

        for (int i = 1; i <= 10; i++)
        {
            products.Add(new Product
            {
                ID = i,
                Name = $"Product {i}",
                Price = random.Next(50, 500),
                CreatedDate = DateTime.Now.AddDays(-random.Next(0, 30))
            });
        }

        return View(products);
    }
}