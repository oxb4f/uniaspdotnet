using System.ComponentModel.DataAnnotations;

namespace lr5.Models;

public class User
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Ім'я є обов'язковим")]
    public string Name { get; set; }

    [Required]
    [Range(1, 120, ErrorMessage = "Вік повинен бути між 1 та 120 роками")]
    public int Age { get; set; }}
