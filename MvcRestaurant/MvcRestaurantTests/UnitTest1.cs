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
    public class UnitTest1
    {
        [TestMethod]
        public void WriteNote_TableIdSent_TableWithCorectIdReturned()
        {
            //arrange
            System.Data.Entity.Database.SetInitializer(new MvcRestaurant.Models.SampleData());
            WaitersController controller = new WaitersController();

            //act
            var result = controller.WriteNote(3) as ViewResult;
            var model = result.ViewData.Model as WaiterTableViewModel;

            //assert
            Assert.AreEqual(3, model.Table.TableId);

        }

        [TestMethod]
        public void WriteNote_TableIdSent_WaiterIsNotNull()
        {
            //arrange
            System.Data.Entity.Database.SetInitializer(new MvcRestaurant.Models.SampleData());
            WaitersController controller = new WaitersController();

            //act
            var result = controller.WriteNote(3) as ViewResult;
            var model = result.ViewData.Model as WaiterTableViewModel;

            //assert
            Assert.IsNotNull(model.Table.Waiter);
        }

        [TestMethod]
        public void TablesView_WaiterIdSent_WaiterWithCorectIdReturned()
        {
            //arrange
            System.Data.Entity.Database.SetInitializer(new MvcRestaurant.Models.SampleData());
            WaitersController controller = new WaitersController();

            //act
            var result = controller.TablesView(3) as ViewResult;
            var model = result.ViewData.Model as WaiterTableViewModel;

            //assert
            Assert.AreEqual(3, model.Waiter.WaiterId);

        }

        [TestMethod]
        public void AddWaiter_ModelStateIsValid_WaiterSavedInDatabase()
        {
            //arrange
            System.Data.Entity.Database.SetInitializer(new MvcRestaurant.Models.SampleData());
            WaitersController controller = new WaitersController();
            Waiter waiter = new Waiter();
            waiter.Name = "Jack";
            waiter.NumberEmployee = 9;

            //act
            var result = controller.AddWaiter(waiter) as ViewResult;

            //assert
            RestaurantEntities db = new RestaurantEntities();
            Waiter wait = db.Waiters.SingleOrDefault();
            Assert.IsNotNull(wait);
        }

        [TestMethod]
        public void AddWaiter_ModelIsValid_RedirectToConfirm()
        {
            //arrange
            System.Data.Entity.Database.SetInitializer(new MvcRestaurant.Models.SampleData());
            WaitersController controller = new WaitersController();
            Waiter waiter = new Waiter();
            waiter.Name = "Jack";
            waiter.NumberEmployee = 9;

            //act
            var result = controller.AddWaiter(waiter) as RedirectToRouteResult;

            //assert
            //Assert.IsTrue(result.RouteValues["action"] == "Coordinator");
        }

        [TestMethod]
        public void AddTable_ModelStateIsValid_TableSavedInDatabase()
        {
           //arrange
            System.Data.Entity.Database.SetInitializer(new MvcRestaurant.Models.SampleData());
            WaitersController controller = new WaitersController();
            Table table = new Table();
            table.DimensionTable = 4;
            table.CoordinatesTable.CoordinateX = 4;
            table.CoordinatesTable.CoordinateY = 3;
            table.Status = Status.Free;

            //act
            var result = controller.AddTable(table) as ViewResult;

            //assert
            RestaurantEntities db = new RestaurantEntities();
            Table tab = db.Tables.SingleOrDefault();
            Assert.IsNotNull(tab);
          
        }
        [TestMethod]
        public void AddTable_ModelIsValid_RedirectToConfirm()
        {
            //arrange
            System.Data.Entity.Database.SetInitializer(new MvcRestaurant.Models.SampleData());
            WaitersController controller = new WaitersController();
            Table table = new Table();
            table.DimensionTable = 4;
            table.CoordinatesTable.CoordinateX = 4;
            table.CoordinatesTable.CoordinateY = 3;
            table.Status = Status.Free;

            //act
            var result = controller.AddTable(table) as RedirectToRouteResult;

            //assert
            //Assert.IsTrue(result.RouteValues["action"] == "Coordinator");
        }

    }
}
