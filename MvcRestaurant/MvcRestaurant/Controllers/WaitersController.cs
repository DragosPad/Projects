using System;
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

        [Authorize]
        public ActionResult TablesView( int waiterId)
        {
          Waiter wait = db.Waiters.Include(w => w.Tables).Single(w => w.WaiterId == waiterId);
          var enumStatus = from Status e in Enum.GetValues(typeof(Status))
                         select new
                         {
                             ID = (int)e,
                             Name = e.ToString()
                         };
          ViewBag.EnumList = new SelectList(enumStatus, "ID", "Name");
           // ViewBag.WaiterID = new SelectList(db.Waiters, "WaiterId", "Name", listWaiter.WaiterId);

            return View(wait);
        }
    }
}
