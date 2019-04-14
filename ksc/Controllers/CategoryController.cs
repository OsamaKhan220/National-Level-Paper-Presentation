using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ksc.Models;

namespace ksc.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Users
        public ActionResult Index()
        {
            var Categories = db.Categories.Select(u => u);
            ViewBag.Categories = Categories.ToList();
            return View();
        }

        public ActionResult Edit(int Id)
        {
            var Categories = db.Categories.Where(e => e.id == Id).FirstOrDefault();
            return View(Categories);
        }

        [HttpPost]
        public ActionResult Edit(Category model)
        {
            Category nCategories = db.Categories.Single(u => u.id == model.id);
            nCategories.name = model.name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category model)
        {
            db.Categories.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            Category nCategory = db.Categories.Single(u => u.id == Id);
            db.Categories.Remove(nCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}