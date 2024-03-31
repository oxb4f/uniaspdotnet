using lr8.Models;

namespace lr8.Components;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class ProductsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(IEnumerable<Product> products)
    {
        return View(products);
    }
}
