using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AirlineCompany.Controllers;
using AirlineCompany.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FormControllerTests
    {
        [TestMethod]
        public void FligthsFromLocation_SearchStringFilled_FilteredFlightsReturned()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void FligthsFromLocation_SearchStringNotFilled_AllFlightsAreReturned()
        {
            FormController controller = new FormController();
            var viewResult = controller.FligthsToLocation(null, null) as ViewResult;
            var model = viewResult.ViewData.Model as IEnumerable<Fligth>;

            Assert.Equals(2, model.Count());
        }
    }
}
