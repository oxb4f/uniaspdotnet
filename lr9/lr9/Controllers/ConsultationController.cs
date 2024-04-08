using System.Text.Json;
using lr9.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lr9.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class ConsultationController : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        ViewBag.Products = new List<string> { "JavaScript", "C#", "Java", "Python", "Основи" };
        var model = new ConsultationRegistration();
        return View(model);
    }

    [HttpPost]
    public IActionResult Register(ConsultationRegistration model)
    {
        if (model is { Product: "Основи", DesiredDate.DayOfWeek: DayOfWeek.Monday })
        {
            ModelState.AddModelError("", "Консультація по 'Основи' не може бути по понеділках.");
        }

        if (ModelState.IsValid)
        {
            return RedirectToAction("Success");
        }

        return View(model);
    }

    public IActionResult Success()
    {
        return View();
    }
}