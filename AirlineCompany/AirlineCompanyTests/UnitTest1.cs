using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirlineCompany.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using AirlineCompany.Models;
using AirlineCompany.ViewModels;
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
            var viewResult = controller.FligthsFromLocation(null, null) as ViewResult;
            var model = viewResult.ViewData.Model as IEnumerable<Fligth>;

            Assert.AreEqual(6, model.Count());
        }

        [TestMethod]
        public void FligthsToLocation_SearchStringNotFilled_AllFlightsAreReturn()
        {
            System.Data.Entity.Database.SetInitializer(new AirlineCompany.Models.SampleData());
            FormController controller = new FormController();
            var viewResult = controller.FligthsToLocation(null, null) as ViewResult;
            var model = viewResult.ViewData.Model as IEnumerable<Fligth>;

            Assert.AreEqual(6, model.Count());
        }

       
        [TestMethod]
        public void FligthsToLocation_SearchStringNotFilled_AllFlightsAreReturned()
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

            Assert.AreEqual(1, (viewResult.ViewData.Model as Reservation).ReservationId);

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
            Assert.IsTrue(model.Count() == 1);
        }

        [TestMethod]
        public void FligthsFromLocation_SearchDateTime()
        {
            System.Data.Entity.Database.SetInitializer(new AirlineCompany.Models.SampleData());
            FormController controller = new FormController();
            var result = controller.FligthsFromLocation(null, new DateTime(2017, 12, 10)) as ViewResult;
            //var model = (List<Fligth>) result.ViewData.Model;
            var model = result.ViewData.Model as IEnumerable<Fligth>;
            Assert.IsTrue(model.Count() == 2);
        }

        [TestMethod]
        public void FligthsToLocation_SearchName()
        {
            System.Data.Entity.Database.SetInitializer(new AirlineCompany.Models.SampleData());
            FormController controller = new FormController();
            var result = controller.FligthsToLocation("Rome", null) as ViewResult;
            //var model = (List<Fligth>) result.ViewData.Model;
            var model = result.ViewData.Model as IEnumerable<Fligth>;
            Assert.IsTrue(model.Count() == 2);
        }

        [TestMethod]
        public void FligthsToLocation_SearchDateTime()
        {
            System.Data.Entity.Database.SetInitializer(new AirlineCompany.Models.SampleData());
            FormController controller = new FormController();
            var result = controller.FligthsToLocation(null, new DateTime(2017, 12, 12)) as ViewResult;
            var model = result.ViewData.Model as IEnumerable<Fligth>;
            Assert.IsTrue(model.Count() == 4);
        }

        [TestMethod]
        public void ViewSeat_FlightIdSent_FligthWithCorectIdReturned()
        {
          //arrange
            System.Data.Entity.Database.SetInitializer(new AirlineCompany.Models.SampleData());
            FormController controller = new FormController();

            //act
            var result = controller.ViewSeat(3) as ViewResult;
            var model = result.ViewData.Model as SeatsModelView;

            //assert
            Assert.AreEqual(3, model.Fligth.FligthId);
            
        }

        [TestMethod]
        public void ViewSeat_FligthIdSent_PlaneIsNotNull()
        {
            //arrange
            System.Data.Entity.Database.SetInitializer(new AirlineCompany.Models.SampleData());
            FormController controller = new FormController();

            //act
            var result = controller.ViewSeat(3) as ViewResult;
            var model = result.ViewData.Model as SeatsModelView;

            //assert
            Assert.IsNotNull(model.Fligth.Plane);
        }

        [TestMethod]
        public void ViewSeat_ModelIsValid_RedirectToConfirm()
        {
           //arrange
            System.Data.Entity.Database.SetInitializer(new AirlineCompany.Models.SampleData());
            FormController controller = new FormController();
            SeatsModelView seatModelView = new SeatsModelView();
            seatModelView.BirthdatePassenger = new DateTime(2000, 4, 12);
            seatModelView.CNP = 1234445;
            seatModelView.NamePassenger = "vali";

            FligthSeatInformationView fligthInfo = new FligthSeatInformationView();
            fligthInfo.FligthId = 2;
            fligthInfo.PlaceColumn = 12;
            fligthInfo.PlaceRow = 10;


            //act
            var result = controller.ViewSeat(seatModelView, fligthInfo) as RedirectToRouteResult;
           

            //assert
            Assert.IsTrue(result.RouteValues["action"] == "Confirm");
        }

        [TestMethod]
        public void ViewSeatPost_FlightIdSent_FligthWithCorectIdReturned()
        {
            //arrange
            System.Data.Entity.Database.SetInitializer(new AirlineCompany.Models.SampleData());
            FormController controller = new FormController();
            SeatsModelView seatModelView = new SeatsModelView();
            seatModelView.BirthdatePassenger = new DateTime(2018, 6, 10);
            seatModelView.CNP = 1234445;
            seatModelView.NamePassenger = "Tudor";

            FligthSeatInformationView fligthInfo = new FligthSeatInformationView();
            fligthInfo.FligthId = 4;
            fligthInfo.PlaceColumn = 10;
            fligthInfo.PlaceRow = 10;

            //act
            var result = controller.ViewSeat(seatModelView, fligthInfo) as ViewResult;
            var model = result.ViewData.Model as SeatsModelView;


            //assert
            Assert.AreEqual(fligthInfo.FligthId, model.Fligth.FligthId);

        }

        [TestMethod]
        public void ViewSeatPost_FligthIdSent_PlaneIsNotNull()
        {
            //arrange
            System.Data.Entity.Database.SetInitializer(new AirlineCompany.Models.SampleData());
            FormController controller = new FormController();
            SeatsModelView seatModelView = new SeatsModelView();
            seatModelView.BirthdatePassenger = new DateTime(2018, 6, 10);
            seatModelView.CNP = 1234445;
            seatModelView.NamePassenger = "Tudor";

            FligthSeatInformationView fligthInfo = new FligthSeatInformationView();
            fligthInfo.FligthId = 4;
            fligthInfo.PlaceColumn = 10;
            fligthInfo.PlaceRow = 10;

            //act
            var result = controller.ViewSeat(seatModelView, fligthInfo) as ViewResult;
            var model = result.ViewData.Model as SeatsModelView;

            //assert
            Assert.IsNotNull(model.Fligth.Plane);

        }

    }
}
