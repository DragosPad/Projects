﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestaurant.Models;
using System.Data.Entity;
using MvcRestaurant.ViewModel;
using System.Net;
using System.Data;


namespace MvcRestaurant.Controllers
{
    public class WaitersController : Controller
    {
        private RestaurantEntities db = new RestaurantEntities();
        //
        // GET: /Waiters/

        public ActionResult Index()
        {
            var wait = db.Waiters.Include(c => c.Tables);
            return View(wait);
        }

        public ActionResult WriteNote()
        {

            ViewBag.BookingFormId = new SelectList(db.Waiters, "WaiterId");
            return View();
        }

        [HttpPost]
        public ActionResult WriteNote(Waiter wait)
        {
            db.Waiters.Add(wait);
            db.SaveChanges();
            return View();
        }

        public ActionResult TablesView(Waiter wait, int? tabId)
        {
           wait = db.Waiters.Include(w => w.Tables).Single(w => w.WaiterId == tabId);
           // ViewBag.WaiterID = new SelectList(db.Waiters, "WaiterId", "Name", listWaiter.WaiterId);

            return View(wait);
        }
    }
}
