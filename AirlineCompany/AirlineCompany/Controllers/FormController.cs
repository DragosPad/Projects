﻿using System;
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

        public ActionResult ViewSeat(int fligthId)
        {
            SeatsModelView seatView = new SeatsModelView();
            seatView.BirthdatePassenger = null;
            Fligth fligth = db.Fligths.Include(f => f.Plane).Single(f => f.FligthId == fligthId);
            //Fligth fligth = db.Fligths.Single(f => f.FligthId == fligthId);

            seatView.Fligth = fligth;
           
            return View(seatView);
        }

        [HttpPost]
        public ActionResult ViewSeat(SeatsModelView seatView, FligthSeatInformationView fligthSeatInfoView)
        {

            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation();
                //reservation.NamePassenger = seatView.NamePassenger;
                if (seatView.BirthdatePassenger.HasValue)
                {
                    reservation.BirthdatePassenger = seatView.BirthdatePassenger.Value;
                }
                if (seatView.CNP.HasValue)
                {
                    reservation.CNP = seatView.CNP.Value;
                }
                reservation.FligthId = fligthSeatInfoView.FligthId;
                reservation.PlaceRow = fligthSeatInfoView.PlaceRow;
                reservation.PlaceColumn = fligthSeatInfoView.PlaceColumn;

                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Confirm", new { reservedId = reservation.ReservationId });
            }
            else
            {
                Fligth fligth = db.Fligths.Include(f => f.Plane).Single(f => f.FligthId == fligthSeatInfoView.FligthId);
                seatView.Fligth = fligth;
               return View(seatView);
            }
        }

        public ActionResult FligthsFromLocation(string search, DateTime? date)
        {
            ViewBag.CurrentFilter = search;
            var searchForm = from s in db.Fligths
                             select s;
            if (!String.IsNullOrEmpty(search) || date.HasValue)
            {
                searchForm = searchForm.Where(s => s.Location.Contains(search) || s.DateFlight == date);
            }

            return View(searchForm.ToList());
           
        }

        public ActionResult FligthsToLocation(string search, DateTime? date)
        {
            ViewBag.CurrentFilter = search;
         
            var searchForm = from s in db.Fligths
                             select s;

            if (!String.IsNullOrEmpty(search) || date.HasValue)
            {
                searchForm = searchForm.Where(s => s.Destination.Contains(search) || s.DateFlight == date);
                
            }
          
            return View(searchForm);
        }

        public ActionResult StartLocation()
        {
          
            var fligth = db.Fligths.ToList();

            return View(fligth);
        }

        public ActionResult Confirm(int reservedId)
        {
           // var reservation = db.Reservations.ToList();
            Reservation reservation = db.Reservations.Single(r => r.ReservationId == reservedId);
            return View(reservation);
        }

    }
}
