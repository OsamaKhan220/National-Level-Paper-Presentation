using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ksc.Models;

namespace ksc.Controllers
{
    public class UsersController : BaseController
    {
        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Select(u => u);
            ViewBag.Users = users.ToList();
            return View();
        }

        public ActionResult Edit(int Id) {
            ViewBag.roles = db.Roles.ToList();
            var user = db.Users.Where(e => e.Id == Id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User model)
        {
            User nUser = db.Users.Single(u => u.Id == model.Id);
            nUser.email = model.email;
            nUser.name = model.name;
            nUser.role_id = model.role_id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Add() {
            ViewBag.roles = db.Roles.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Add(User model)
        {
            db.Users.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            User nUser = db.Users.Single(u => u.Id == Id);
            db.Users.Remove(nUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}