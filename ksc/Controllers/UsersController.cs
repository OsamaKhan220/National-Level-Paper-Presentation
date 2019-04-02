using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var user = db.Users.Where(e => e.Id == Id).FirstOrDefault();
            return View(user);
        }
    }
}