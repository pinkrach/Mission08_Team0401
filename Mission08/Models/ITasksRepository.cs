using Microsoft.EntityFrameworkCore;
namespace Mission08.Models;

public class EFTasksRepository : ITasksRepository
{
    private TasksContext _context;

    public EFTasksRepository(TasksContext temp)
    {
        _context = temp;
    }

    // Properties
    public List<TaskItem> Tasks => _context.Tasks
        .Include(t => t.Category)
        .ToList();

    public List<Category> Categories => _context.Categories
        .OrderBy(c => c.CategoryName)
        .ToList();

    // Methods
    public void AddTask(TaskItem task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public void UpdateTask(TaskItem task)
    {
        _context.Tasks.Update(task);
        _context.SaveChanges();
    }

    public void DeleteTask(TaskItem task)
    {
        _context.Tasks.Remove(task);
        _context.SaveChanges();
    }
}