using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoneShope.Data;
using StoneShope.Models;
using System.Collections.Generic;
using System.Data;

namespace StoneShope.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;

        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = this.db.Category;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                this.db.Category.Add(obj);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = this.db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                this.db.Category.Update(obj);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = this.db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = this.db.Category.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            this.db.Category.Remove(obj);
            this.db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
