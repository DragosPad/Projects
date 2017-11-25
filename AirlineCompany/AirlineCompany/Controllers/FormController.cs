using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineCompany.Models;
using System.Data.Entity;
using System.Data;
using System.Net;

namespace AirlineCompany.Controllers
{
    public class FormController : Controller
    {
        private Form fr = new Form();
        //
        // GET: /Form/
        private AirlineEntities db = new AirlineEntities();
        public ActionResult Index(string search)
        {
            var searchForm = from s in db.Fligths
                             select s;
            if (!String.IsNullOrEmpty(search))
            {
                searchForm = searchForm.Where(s => s.Location.Contains(search));
            }
            return View(searchForm.ToList());
        }
        [HttpPost]
        public ActionResult Index()
        {
            //if (ModelState.IsValid)
            //{
            //    //db.Forms.Add(form);
            //    //db.SaveChanges();
            //    form.Message = "Successful completion";
            //    return RedirectToAction("StartLocation");
            //}
            
            
            return View();
        
        }

        public ActionResult ViewSeat()
        {
            return View();
        }

        public ActionResult StartLocation()
        {
          //Fligth fligth = new Fligth();
            var fligth = db.Fligths.ToList();

            return View(fligth);
        }

    }
}
