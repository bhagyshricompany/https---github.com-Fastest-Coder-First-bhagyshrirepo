using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Azurecopilothackthon.Models;

namespace Azurecopilothackthon.Controllers
{
    public class TasksController : Controller
    {
        private static List<Azurecopilothackthon.Models.Taskh> tasks = new List<Azurecopilothackthon.Models.Taskh>();

        private int nextId = 1;
        public IActionResult Index()
        {
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(Azurecopilothackthon.Models.Taskh task)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        tasks.Add(task);
        //        return RedirectToAction("Index");
        //    }

        //    return View(task);
        //}
        [HttpPost]
        public IActionResult Create(Azurecopilothackthon.Models.Taskh task)
        {
            if (ModelState.IsValid)
            {
                task.Id = nextId;
                nextId++;
                tasks.Add(task);
                return RedirectToAction("Index");
            }

            return View(task);
        }

        public IActionResult Edit(int id)
        {
            Azurecopilothackthon.Models.Taskh task = tasks.FirstOrDefault(t => t.Id == id);
           
            if (task != null)
            {
                return View(task);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Azurecopilothackthon.Models.Taskh task)
        {
            if (ModelState.IsValid)
            {
                Azurecopilothackthon.Models.Taskh existingTask = tasks.FirstOrDefault(t => t.Id == task.Id);
               
                if (existingTask != null)
                {
                    existingTask.TaskName = task.TaskName;
                    return RedirectToAction("Index");
                }
            }

            return View(task);
        }

        public IActionResult Delete(int id)
        {
            Azurecopilothackthon.Models.Taskh task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Complete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
            }

            return RedirectToAction("Index");
        }

    }
}
