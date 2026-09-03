namespace lesson4.Models;
using System.ComponentModel.DataAnnotations;

public class Order
{
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string? Title { get; set; }

    public string? Description { get; set; }

    [Range(1,10000)]
    public decimal Price { get; set;}

    [Range(1,100)]
    public int Quantity { get; set; }

    public decimal TotalPrice => Price * Quantity;
}
