namespace Mission08.Models;

// Models/TaskItem.cs
using System.ComponentModel.DataAnnotations;

public class TaskItem
{
    [Key]
    public int TaskId { get; set; }

    [Required]
    public string TaskName { get; set; }

    public DateTime? DueDate { get; set; }

    [Required]
    public int Quadrant { get; set; }   // 1–4

    // FK to Category
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public bool Completed { get; set; }
}
