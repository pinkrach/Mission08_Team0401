namespace Mission08.Models;

// Models/Category.cs
using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; }
}
