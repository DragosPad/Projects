using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRestaurant.Controllers;
using MvcRestaurant.Models;
using MvcRestaurant.ViewModel;
using System.Linq;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using System.Data.Entity;

namespace MvcRestaurantTests
{
    [TestClass]
    public class ReservationControllerTest
    {
        [TestMethod]
        public void ConfirmReservation_hiddenIdTableSent_TableWithCorectIdReturned()
        {
            //arrange
            System.Data.Entity.Database.SetInitializer(new MvcRestaurant.Models.SampleData());
            ReservationController controller = new ReservationController();
            BookingTable booking = new BookingTable();
            Reservation reservation = new Reservation();
            reservation.NumberOfPeople = 3;
            reservation.ReservationDate = new DateTime(2000, 4, 5);
            reservation.ReservationTime = new DateTime(2002, 4, 1);
            reservation.TableId = 4;

            booking.Reservation = reservation;
            //reservation = booking.Reservation;
            //reservation.NumberOfPeople = 4;
            //var myReservation = booking.Reservation;
           // myReservation.TableId = 3;

            //act
            var result = controller.ConfirmReservation(booking, 4) as ViewResult;
            var model = result.ViewData.Model as BookingTable;

            //assert
            Assert.AreEqual(4, model.Reservation.TableId);

        }

        [TestMethod]
        public void ConfirmReservation_ReservationIsNotNull_ReservationSavedInDatabase()
        {
            //arrange
            System.Data.Entity.Database.SetInitializer(new MvcRestaurant.Models.SampleData());
            ReservationController controller = new ReservationController();
            BookingTable booking = new BookingTable();
            Reservation reservation = new Reservation();
            reservation.NumberOfPeople = 3;
            reservation.ReservationDate = new DateTime(2000, 4, 5);
            reservation.ReservationTime = new DateTime(2002, 4, 1);
            reservation.TableId = 4;

            booking.Reservation = reservation;

            //act
            var result = controller.ConfirmReservation(booking, 4) as ViewResult;

            //assert
            RestaurantEntities db = new RestaurantEntities();
            Reservation tab = db.BookingForms.SingleOrDefault(b => b.TableId == 4);
            Assert.IsNotNull(tab);

        }

        [TestMethod]
        public void ViewDiagram_TableIdSent_BookingFormsIsNotNull()
        {
            //arrange
            System.Data.Entity.Database.SetInitializer(new MvcRestaurant.Models.SampleData());
            ReservationController controller = new ReservationController();

            var result = controller.ViewDiagram() as ViewResult;
            var model = result.ViewData.Model as Reservation;

            //assert
            Assert.IsNotNull(model.Table.BookingForms);
        }

        [TestMethod]
        public void ViewDiagram_TablesViewStatus_ReservationIsTrue()
        {

            //arrange
            System.Data.Entity.Database.SetInitializer(new MvcRestaurant.Models.SampleData());
            ReservationController controller = new ReservationController();

            //act
            var result = controller.ViewDiagram() as ViewResult;
            var model = result.ViewData.Model as Reservation;

            //assert
            Assert.IsTrue(model.ReservationId == 3);



        }
        


    }
}
