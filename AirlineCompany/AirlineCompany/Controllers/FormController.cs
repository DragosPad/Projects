using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineCompany.Models;
using System.Data.Entity;
using System.Data;
using System.Net;
using AirlineCompany.ViewModels;

namespace AirlineCompany.Controllers
{
    public class FormController : Controller
    {
        
        //
        // GET: /Form/
        private AirlineEntities db = new AirlineEntities();
        public ActionResult Index()
        {
            var fligth = db.Fligths.ToList();
            return View(fligth);
        }
        //[HttpPost]
        //public ActionResult Index()
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    //db.Forms.Add(form);
        //    //    //db.SaveChanges();
        //    //    form.Message = "Successful completion";
        //    //    return RedirectToAction("StartLocation");
        //    //}
            
            
        //    return View();
        
        //}

        public ActionResult ViewSeat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewSeat(InformationPassenger infoPassenger)
        {
            if (ModelState.IsValid)
            {
                db.InformationPassenger.Add(infoPassenger);
                db.SaveChanges();
                return RedirectToAction("ViewSeat");
            }
            return View();
        }

        public ActionResult FligthsFromLocation(string search, DateTime? date)
        {
            //FligthsFromLocationView fligthsView = new FligthsFromLocationView();
            ViewBag.CurrentFilter = search;
            var searchForm = from s in db.Fligths
                             select s;
            if (!String.IsNullOrEmpty(search) && date.HasValue)
            {
                //FligthsFromLocationView fligthsView = new FligthsFromLocationView();
                searchForm = searchForm.Where(s => s.Location.Contains(search) && s.DateFlight == date);
               // fligthsView.Fligths = searchForm;
            }
            //fligthsView.Fligths = searchForm;
            return View(searchForm.ToList());
        }

        public ActionResult FligthsToLocation(string search, DateTime? date)
        {
            ViewBag.CurrentFilter = search;
            var searchForm = from s in db.Fligths
                             select s;
            if (!String.IsNullOrEmpty(search) && date.HasValue)
            {
                searchForm = searchForm.Where(s => s.Location.Contains(search) && s.DateFlight == date);
                
            }
           
            return View(searchForm.ToList());
        }

        public ActionResult StartLocation()
        {
          //Fligth fligth = new Fligth();
            var fligth = db.Fligths.ToList();

            return View(fligth);
        }

    }
}
