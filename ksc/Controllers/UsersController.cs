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
            
            var users = db.Users.ToList();
            return View(users);
        }

        public ActionResult Edit(int Id) {
            ViewBag.roles = db.Roles.ToList();
            var user = db.Users.Where(e => e.Id == Id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User model)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Add() {
            ViewBag.roles = db.Roles.ToList();
            return View();
        }
    }
}