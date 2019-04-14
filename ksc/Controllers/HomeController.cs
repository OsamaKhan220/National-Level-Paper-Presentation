using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ksc.Models.AppModels;

namespace ksc.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var categories = db.Categories.Select(c=>c);
            ViewBag.Categories = categories.ToList();
            var activity = db.Activities.Select(a => a);
            ViewBag.Activity= activity.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginRequest model) {
            Session["LoggedIn"] = true;
            return RedirectToAction("index", "dashboard");
            //var user = db.Users.Where(e => e.email == model.Email && e.password == model.Password).FirstOrDefault();
            //if (user != null) {
            //    return RedirectToAction("Index","Dashboard");
            //}
            //ViewBag.Message = "Invalid Credentials";
            //return RedirectToAction("Index");
        }


        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterRequest model) {
            var user = db.Users.Where(e => e.email == model.Email).FirstOrDefault();
            if (user == null)
            {
                ViewBag.Message = "User Registered.";
            }
            else {
                ViewBag.Message = "User Already Exist.";
            }
            return RedirectToAction("Index", "Dashboard");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string GotoEvent(string activityId)
        {
            //db.Activities.
            return activityId;
        }
    }
}