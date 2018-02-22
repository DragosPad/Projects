using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirlineCompany.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using AirlineCompany.Models;
using System.Linq;

namespace AirlineCompanyTests
{
    [TestClass]
    public class UnitTest1
    {
        
       
        [TestMethod]
        public void FligthsFromLocation_SearchStringNotFilled_AllFlightsAreReturned()
        {
            System.Data.Entity.Database.SetInitializer(new AirlineCompany.Models.SampleData());
            FormController controller = new FormController();
            var viewResult = controller.FligthsToLocation(null, null) as ViewResult;
            var model = viewResult.ViewData.Model as IEnumerable<Fligth>;

            Assert.AreEqual(6, model.Count());
        }

        [TestMethod]
        public void TestConfirmView()
        {
            AirlineEntities airlineEntities = new AirlineEntities();
            Reservation reservation = new Reservation();

            reservation.BirthdatePassenger = new DateTime(2000, 11, 11);
            airlineEntities.Reservations.Add(reservation);
            airlineEntities.SaveChanges();
                        
            AirlineCompany.Controllers.FormController controller = new AirlineCompany.Controllers.FormController();
            ActionResult result = controller.Confirm(1);
            ViewResult viewResult = result as ViewResult;
            var model = viewResult.ViewData.Model as Reservation;

            Assert.AreEqual(1, model.ReservationId);

            //Assert.AreEqual(string.Empty, viewResult.ViewName);
             
            //Assert.AreEqual(1, ((Reservation)viewResult.Model).ReservationId);
            
        }

        [TestMethod]
        public void FligthsFromLocation_SearchName()
        {
            System.Data.Entity.Database.SetInitializer(new AirlineCompany.Models.SampleData());
            FormController controller = new FormController();
            var result = controller.FligthsFromLocation("Paris", null) as ViewResult;
            //var model = (List<Fligth>) result.ViewData.Model;
           var model = result.ViewData.Model as IEnumerable<Fligth>;
            Assert.IsTrue(model.All(f => f.Location == "Paris"));
        }





        //[TestMethod]
        //public void FligthsFromLocation_ViewBag_search()
        //{
        //    FormController controller = new FormController();

        //    ViewResult result = controller.FligthsFromLocation(null, null) as ViewResult;

        //    Assert.AreEqual("Paris", result.ViewBag.CurrentFilter);
        //}


    }
}
