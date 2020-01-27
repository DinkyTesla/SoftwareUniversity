


namespace TeisterMask.Controllers
{
    using System.Linq;
    using TeisterMask.Data;
    using TeisterMask.Models;
    using Microsoft.AspNetCore.Mvc;

    public class TaskController : Controller
    {
        [HttpGet]
        public IActionResult index()
        {
            using (var db = new TeisterMaskDbContext())
            {
                var allTasks = db.Tasks.ToList();
                return View(allTasks);
            }
        }

        [HttpGet]
        public IActionResult Create()
    }
}
