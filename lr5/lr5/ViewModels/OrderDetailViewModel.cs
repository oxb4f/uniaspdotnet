namespace lr5.ViewModels;

using System.Collections.Generic;

public class OrderDetailViewModel
{
    public int Quantity { get; set; }
    public List<ProductOrderDetail> Products { get; set; }

    public OrderDetailViewModel()
    {
        Products = new List<ProductOrderDetail>();
    }
}

public class ProductOrderDetail
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
