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
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(Form form)
        {
            if (ModelState.IsValid)
            {
                //db.Forms.Add(form);
                //db.SaveChanges();
                form.Message = "Successful completion";
                return RedirectToAction("StartLocation");
            }
            
            
            return View(form);
        
        }

        public ActionResult ViewSeat()
        {
            return View();
        }

        public ActionResult StartLocation()
        {
          //Fligth fligth = new Fligth();
            var fligth = db.Forms.Include(a => a.Fligth);

            return View(fligth);
        }

    }
}
