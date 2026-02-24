namespace Mission08.Models;
using Microsoft.EntityFrameworkCore;


public class TasksContext : DbContext
{
    public TasksContext(DbContextOptions<TasksContext> options) : base(options)
    {
    }

    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }
}