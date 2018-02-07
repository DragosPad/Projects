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
    }
}
