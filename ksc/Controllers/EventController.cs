﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ksc.Models;

namespace ksc.Controllers
{
    public class EventController : BaseController
    {
    
        public ActionResult Index()
        {
            var activities = db.Activities.Select(u => u);
            ViewBag.Activity = activities.ToList();
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.categories = db.Categories.ToList();
            ViewBag.payment_methods = db.PaymentMethods.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Add(Activity model)
        {
            db.Activities.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            ViewBag.categories = db.Categories.ToList();
            ViewBag.payment_methods = db.PaymentMethods.ToList();
            var Activity = db.Activities.Where(e => e.id == Id).FirstOrDefault();
            return View(Activity);
        }

        [HttpPost]
        public ActionResult Edit(Activity model)
        {
            Activity nActivity = db.Activities.Single(u => u.id == model.id);
            nActivity.name = model.name;
            nActivity.description = model.description;
            nActivity.fee = model.fee;
            nActivity.date = model.date;
            nActivity.eligibility_criteria = model.eligibility_criteria;
            nActivity.guest_name = model.guest_name;
            nActivity.apply_procedure = model.apply_procedure;
            nActivity.prize_details = model.prize_details;
            nActivity.terms = model.terms;
            nActivity.topic = model.topic;
            nActivity.payment_methods_id = model.payment_methods_id;
            nActivity.category_id = model.category_id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            Activity nActivity = db.Activities.Single(u => u.id == Id);
            db.Activities.Remove(nActivity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewUser(int Id)
        {
            var ActivityUsers = db.ActivityUsers.Where(e => e.activity_id == Id);
            ViewBag.ActivityUsers = ActivityUsers.ToList();
            
            //foreach (var item in ActivityUsers)
            //{
            //    var Users = db.Users.Where(e => e.Id== item.user_id).FirstOrDefault();
            //}
            return View();
        }

        public ActionResult MarkWinner(int userId, int activityId)
        {
            ActivityWinner winner = new ActivityWinner();
            winner.user_id = userId;
            winner.activity_id = activityId;
            db.ActivityWinners.Add(winner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}