namespace lr9.Models;

using System;
using System.ComponentModel.DataAnnotations;

public class ConsultationRegistration
{
    [Required(ErrorMessage = "Ім'я та прізвище обов'язкові для заповнення.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Email обов'язковий для заповнення.")]
    [EmailAddress(ErrorMessage = "Некоректний формат Email.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Бажана дата консультації обов'язкова для заповнення.")]
    [FutureDate(ErrorMessage = "Дата консультації повинна бути у майбутньому і не на вихідних.")]
    public DateTime DesiredDate { get; set; }

    [Required(ErrorMessage = "Оберіть продукт для консультації.")]
    public string Product { get; set; }
}

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not DateTime dateTime)
        {
            return new ValidationResult("Некоректна дата.");
        }

        var currentDate = DateTime.Now.Date;
        if (dateTime.Date < currentDate)
        {
            return new ValidationResult("Дата консультації повинна бути у майбутньому.");
        }

        return dateTime.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday
            ? new ValidationResult("Дата консультації не може падати на вихідні.")
            : ValidationResult.Success;
    }
}