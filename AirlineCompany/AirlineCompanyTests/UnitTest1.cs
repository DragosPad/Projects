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
            AirlineCompany.Controllers.FormController controller = new AirlineCompany.Controllers.FormController();
            ActionResult result = controller.Confirm(2);
            ViewResult viewResult = result as ViewResult;
            Assert.AreEqual("Confirm", viewResult.ViewName);
        }

        [TestMethod]
        public void FligthsFromLocation_SearchName()
        {
            System.Data.Entity.Database.SetInitializer(new AirlineCompany.Models.SampleData());
            FormController controller = new FormController();
            var result = controller.FligthsFromLocation("Paris", null) as ViewResult;
            var model = (Fligth) result.ViewData.Model;
           // var model = vesult.ViewData.Model as IEnumerable<Fligth>;
            Assert.AreEqual("Paris", model.Location);
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
