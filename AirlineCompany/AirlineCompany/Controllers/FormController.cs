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

        public ActionResult FligthsFromLocation(string search)
        {
            //FligthsFromLocationView fligthsView = new FligthsFromLocationView();
            ViewBag.CurrentFilter = search;
            var searchForm = from s in db.Fligths
                             select s;
            if (!String.IsNullOrEmpty(search))
            {
                //FligthsFromLocationView fligthsView = new FligthsFromLocationView();
                searchForm = searchForm.Where(s => s.Location.Contains(search));
               // fligthsView.Fligths = searchForm;
            }
            //fligthsView.Fligths = searchForm;
            return View(searchForm.ToList());
        }

        public ActionResult FligthsToLocation(string search)
        {
            ViewBag.CurrentFilter = search;
            var searchForm = from s in db.Fligths
                             select s;
            if (!String.IsNullOrEmpty(search))
            {
                searchForm = searchForm.Where(s => s.Destination.Contains(search));
                
            }
            //if (!String.IsNullOrEmpty(search))
            //{
            //    searchForm = searchForm.Where(d => d.DateFlight.Contains(search));

            //}
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
