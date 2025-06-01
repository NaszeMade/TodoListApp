using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TodoListApp.Data;
using ModelTodoItem = TodoListApp.Model.TodoItem; // Alias to resolve ambiguity

namespace TodoListApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string filter = null)
        {
            var todoItems = string.IsNullOrWhiteSpace(filter)
                ? _context.TodoItems.ToList()
                : _context.TodoItems.Where(t => t.Category == filter).ToList();

            ViewBag.Categories = _context.TodoItems.Select(t => t.Category).Distinct().ToList();
            return View(todoItems);
        }

        [HttpPost]
        public IActionResult Add(string task, string category)
        {
            if (!string.IsNullOrWhiteSpace(task))
            {
                _context.TodoItems.Add(new ModelTodoItem { Task = task, IsCompleted = false, Category = category });
                _context.SaveChanges(); // Ensure changes are saved to the database
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var todoItem = _context.TodoItems.Find(id);
            if (todoItem != null)
            {
                _context.TodoItems.Remove(todoItem);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}