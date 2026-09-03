using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace lesson4.Models;

public class UserModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(30)]
    public string? Name { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }

    [Phone]
    [RegularExpression(@"^0\d{2}-\d{3}-\d{2}-\d{2}$")]
    [Required]
    public string? PhoneNumber { get; set; }

    [Range(1, 100)]
    [Required]
    public int Age { get; set; }

    [Required]
    public string? Password { get; set; }

    [Compare(nameof(Password))]
    [Required]
    public string? ConfirmPassword { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z]+$")]
    public string? Line { get; set; }


    //[Url]
    //public string? Url { get; set; }
}
