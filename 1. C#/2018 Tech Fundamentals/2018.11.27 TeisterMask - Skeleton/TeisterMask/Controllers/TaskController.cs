using System.Linq;
using TeisterMask.Data;
using TeisterMask.Models;
using Microsoft.AspNetCore.Mvc;

namespace TeisterMask.Controllers
{
    public class TaskController : Controller
    {
        //Read
        [HttpGet]
        public IActionResult Index()
        {
            using (var db = new TeisterMaskDbContext())
            {
                var allTasks = db.Tasks.ToList();
                return View(allTasks);
            }
        }

        // Create
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string title, string status)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(status))
            {
                return RedirectToAction("Index");
            }
            Task task = new Task
            {
                Title = title,
                Status = status
            };
            using (var db = new TeisterMaskDbContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new TeisterMaskDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(t => t.Id == id);
                if (taskToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(taskToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Task task)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new TeisterMaskDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(t => t.Id == task.Id);
                taskToEdit.Title = task.Title;
                taskToEdit.Status = task.Status;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Delete

        //public IActionResult Details(int id)
        //{
        //    using (var db = new TeisterMaskDbContext())
        //    {
        //        Task taskDetails = db.Tasks.FirstOrDefault(t => t.Id == id);
        //        if (taskDetails == null)
        //        {
        //            RedirectToAction("Index");
        //        }
        //        return View(taskDetails);
        //    }
        //}

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new TeisterMaskDbContext())
            {
                Task taskDetails = db.Tasks.FirstOrDefault(t => t.Id == id);
                if (taskDetails == null)
                {
                    RedirectToAction("Index");
                }
                return View(taskDetails);
            }
        }

        [HttpPost]
        public IActionResult Delete(Task task)
        {
            using (var db = new TeisterMaskDbContext())
            {
                
                db.Tasks.Remove(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
