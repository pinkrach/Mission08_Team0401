using Microsoft.AspNetCore.Mvc;
using Mission08.Models;

public class TaskController : Controller
{
    private ITasksRepository _repo;

    public TaskController(ITasksRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult Add()
    {
        ViewBag.Categories = _repo.Categories.ToList();
        return View();
    }

    [HttpPost]
    public IActionResult Add(TaskItem task)
    {
        if (ModelState.IsValid)
        {
            _repo.AddTask(task);
            return RedirectToAction("Quadrants");
        }

        ViewBag.Categories = _repo.Categories.ToList();
        return View(task);
    }

    public IActionResult Quadrants()
    {
        var tasks = _repo.Tasks
            .Where(t => t.Completed == false)
            .ToList();

        return View(tasks);
    }
}