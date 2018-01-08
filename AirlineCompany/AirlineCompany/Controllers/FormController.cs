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
            var fligth = db.Fligths.Include( f => f.Plane);
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

        public ActionResult ViewSeat(int fligthId)
        {
            SeatsModelView seatView = new SeatsModelView();
            Fligth fligth = db.Fligths.Include(f => f.Plane).Single(f => f.FligthId == fligthId);
            InformationPassenger infoPass = new InformationPassenger();
            //seatView.Planes = new Plane();
            seatView.Fligth = fligth;
            seatView.NamePassenger = infoPass.NamePassenger;
            seatView.BirthdatePassenger = infoPass.BirthdatePassenger;
            seatView.CNP = infoPass.CNP;
           
            
            return View(seatView);
        }

        [HttpPost]
        public ActionResult ViewSeat(SeatsModelView seatView, FligthSeatInformationView fligthSeatInfoView, int hiddenIdSeat, int hiddenIdSeatColumn)
        {
           
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation();
                var changeReservation = db.Reservations.SingleOrDefault(t => t.ReservationId == reservation.ReservationId);
                changeReservation.NamePassenger = seatView.NamePassenger;
                changeReservation.BirthdatePassenger = seatView.BirthdatePassenger;
                changeReservation.CNP = seatView.CNP;
                changeReservation.FligthId = fligthSeatInfoView.FligthId;
                changeReservation.PlaceRow = hiddenIdSeat;
                changeReservation.PlaceColumn = hiddenIdSeatColumn;

                //db.InformationPassenger.Add(changeReservation);
                db.SaveChanges();
                return RedirectToAction("Confirm");
            }
            return View();
        }

        public ActionResult FligthsFromLocation(string search, DateTime? date)
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
          
            var fligth = db.Fligths.ToList();

            return View(fligth);
        }

        public ActionResult Confirm()
        {

            return View();
        }

    }
}
