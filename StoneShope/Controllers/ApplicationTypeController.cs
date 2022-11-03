using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoneShope.Data;
using StoneShope.Models;
using System.Collections.Generic;
using System.Data;

namespace StoneShope.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext db;

        public ApplicationTypeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = this.db.ApplicationType;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                this.db.ApplicationType.Add(obj);
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

            var obj = this.db.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                this.db.ApplicationType.Update(obj);
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

            var obj = this.db.ApplicationType.Find(id);
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
            var obj = this.db.ApplicationType.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            this.db.ApplicationType.Remove(obj);
            this.db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
