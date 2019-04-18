using System;
using System.Collections.Generic;
using System.IO;
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

            var Winners = db.ActivityWinners.Select(c => c);
            ViewBag.Winners = Winners.ToList();
            var categories = db.Categories.Select(c=>c);
            ViewBag.Categories = categories.ToList();
            var activity = db.Activities.Select(a => a);
            ViewBag.Activity= activity.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginRequest model) {
            Session["LoggedIn"] = true;
            var user = db.Users.Where(e => e.email == model.Email && e.password == model.Password).FirstOrDefault();
            if (user != null && user.role_id == 1)
            {
                return RedirectToAction("Index", "Dashboard");
            }else if (user != null && user.role_id == 2)
            {
                Session["userId"] = user.Id;
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Invalid Credentials";
            return RedirectToAction("Index");
        }

        public ActionResult MyEvents(int userId)
        {
            var userActivity = db.ActivityUsers.Where(e => e.user_id == userId).ToList();
            ViewBag.userActivity = userActivity;
            return View();
        }
        public ActionResult MySubscription(int userId)
        {
            var userSubscription = db.Subscribes.Where(e => e.user_id == userId).ToList();
            ViewBag.userSubscription = userSubscription;
            return View();
        }
        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterRequest model, HttpPostedFileBase Images) {
            var user = db.Users.Where(e => e.email == model.Email).FirstOrDefault();
            if (user == null)
            {
                ViewBag.Message = "User Registered.";
                ksc.Models.User nUser = new ksc.Models.User();
                nUser.name = model.Name;
                nUser.email = model.Email;
                nUser.password = model.Password;
                nUser.role_id = 2;
                nUser.status = 1;

                string filename = Path.GetFileName(Images.FileName);
                string path = Path.Combine(Server.MapPath("~/assets/images/"), filename);
                nUser.image =filename;
                Images.SaveAs(path);
                
                db.Users.Add(nUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                ViewBag.Message = "User Already Exist.";
                return View();
            }
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

        public ActionResult GotoEvent(int id, int userId)
        {
            var nActivityUser = new ksc.Models.ActivityUser();
            nActivityUser.user_id = userId;
            nActivityUser.activity_id = id;
            nActivityUser.status = 0;
            db.ActivityUsers.Add(nActivityUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LeaveEvent(int id)
        {
            ksc.Models.ActivityUser Activity = db.ActivityUsers.Single(u => u.id == id);
            db.ActivityUsers.Remove(Activity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UnSubscribe(int id)
        {
            ksc.Models.Subscribe subscribe = db.Subscribes.Single(u => u.id == id);
            db.Subscribes.Remove(subscribe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Subscribe(int id, int userId)
        {
            var nSubscribe = new ksc.Models.Subscribe();
            nSubscribe.user_id = userId;
            nSubscribe.category_id = id;
            db.Subscribes.Add(nSubscribe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewEvent(int Id)
        {
            var eventt = db.Activities.Where(e => e.id == Id).FirstOrDefault();
            return View(eventt);
        }

        public ActionResult Logout() {
            Session.Clear();
            return RedirectToAction("Index");

        }
        public ActionResult UserProfile(int id)
        {
            var User = db.UserDetails.Where(e => e.user_id == id).FirstOrDefault();
            return View(User);

        }
        public ActionResult EditUserProfile(int id)
        {
            var User = db.UserDetails.Where(e => e.user_id == id).FirstOrDefault();
            ViewBag.city = db.Cities.Select(s => s).ToList();
            return View(User);

        }
        [HttpPost]
        public ActionResult EditUserProfile(ksc.Models.UserDetail model)
        {
            var User = db.UserDetails.Where(e => e.user_id == model.id).FirstOrDefault();
            User.first_name = model.first_name;
            User.last_name = model.last_name;
            User.phone = model.phone;
            User.city = model.city;
            User.address = model.address;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }   
}