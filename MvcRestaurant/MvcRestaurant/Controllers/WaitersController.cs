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
        [Authorize]
        public ActionResult Index()
        {
            var waiter = db.Waiters.Include(c => c.Tables);
            return View(waiter);
        }

        public ActionResult WriteNote(int waiterId)
        {
            WaiterTableViewModel viewModel = new WaiterTableViewModel();
            Waiter waiter = db.Waiters.Include(w => w.Tables).Single(w => w.WaiterId == waiterId);

            ViewBag.BookingFormId = new SelectList(db.Waiters, "WaiterId");
            var enumStatus = from Status e in Enum.GetValues(typeof(Status))
                             select new
                             {
                                 ID = (int)e,
                                 Name = e.ToString()
                             };
            ViewBag.EnumList = new SelectList(enumStatus, "ID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult WriteNote()
        {
            WaiterTableViewModel viewModel = new WaiterTableViewModel();
           // Waiter waiter = db.Waiters.Include(w => w.Tables).Single(w => w.WaiterId == waiterId);
           // viewModel.Waiter = waiter;
           
            //db.Waiters.Add(viewModel);
            //db.SaveChanges();
            return View(viewModel);
        }

       // [Authorize]
        public ActionResult TablesView( int waiterId)
        {
            WaiterTableViewModel viewModel = new WaiterTableViewModel();
          Waiter waiter = db.Waiters.Include(w => w.Tables).Single(w => w.WaiterId == waiterId);
          viewModel.Waiter = waiter;
          var enumStatus = from Status e in Enum.GetValues(typeof(Status))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
          ViewBag.EnumList = new SelectList(enumStatus, "ID", "Name");
           // ViewBag.WaiterID = new SelectList(db.Waiters, "WaiterId", "Name", listWaiter.WaiterId);

          return View(viewModel);
        }

        public ActionResult Coordinator()
        {
            TablesAndWaterView viewModel = new TablesAndWaterView();
            viewModel.Table1 = (from o in db.Tables select o).ToList();
            //viewModel.Waiter1 = from or in db.Waiters select or;
            return View(viewModel);
            
        }
    }
}
