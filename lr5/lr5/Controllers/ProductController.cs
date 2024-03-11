namespace lr5.Controllers;

using Microsoft.AspNetCore.Mvc;
using lr5.ViewModels;

public class ProductController : Controller
{
    [HttpGet]
    public IActionResult SelectQuantity()
    {
        return View(new ProductQuantityViewModel());
    }

    [HttpPost]
    public IActionResult SelectQuantity(ProductQuantityViewModel model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("OrderDetails", new { quantity = model.Quantity });
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult OrderDetails(int quantity)
    {
        var model = new OrderDetailViewModel
        {
            Quantity = quantity
        };

        for (int i = 0; i < quantity; i++)
        {
            model.Products.Add(new ProductOrderDetail());
        }

        return View(model);
    }

    [HttpPost]
    public IActionResult OrderConfirmation(OrderDetailViewModel model)
    {
        if (ModelState.IsValid)
        {
            return View(model);
        }

        return RedirectToAction("OrderDetails", new { quantity = model.Quantity });
    }
}
