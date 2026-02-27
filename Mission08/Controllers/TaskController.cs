using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission08.Models;

namespace Mission08.Controllers
{
    public class TaskController : Controller
    {
        private ITasksRepository _repo;

        public TaskController(ITasksRepository temp)
        {
            _repo = temp;
        }

        // DISPLAY QUADRANTS
        [HttpGet]
        public IActionResult Quadrants()
        {
            var tasks = _repo.Tasks
                .Where(t => !t.Completed)
                .OrderBy(t => t.DueDate)
                .ToList();

            return View(tasks);
        }

        // =======================
        // ADD TASK
        // =======================

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _repo.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View(new TaskItem());
        }

        [HttpPost]
        public IActionResult Add(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(task);
                return RedirectToAction("Quadrants");
            }

            // Reload categories if validation fails
            ViewBag.Categories = _repo.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View(task);
        }

        // =======================
        // EDIT TASK
        // =======================

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);

            ViewBag.Categories = _repo.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(task);
                return RedirectToAction("Quadrants");
            }

            ViewBag.Categories = _repo.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View(task);
        }

        // =======================
        // DELETE TASK
        // =======================

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(TaskItem task)
        {
            _repo.DeleteTask(task);
            return RedirectToAction("Quadrants");
        }
    }
}