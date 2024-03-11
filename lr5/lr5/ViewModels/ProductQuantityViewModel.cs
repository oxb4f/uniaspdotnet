namespace lr5.ViewModels;

using System.ComponentModel.DataAnnotations;

public class ProductQuantityViewModel
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Будь ласка, введіть коректну кількість товарів.")]
    public int Quantity { get; set; }
}
