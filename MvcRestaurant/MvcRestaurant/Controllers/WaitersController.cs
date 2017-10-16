using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestaurant.Models;
using System.Data.Entity;

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

    }
}
