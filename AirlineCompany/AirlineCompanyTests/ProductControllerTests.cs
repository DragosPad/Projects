using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineCompany.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirlineCompany.ViewModels;
using System.Web.Mvc;

namespace AirlineCompanyTests
{
    class ProductControllerTests
    {
        [TestMethod]
        public void TestDetailsView()
        {
            AirlineCompany.Controllers.ProductController controller = new AirlineCompany.Controllers.ProductController();
           ActionResult result = controller.Details(2) ;
           ViewResult viewResult = result as ViewResult;
            Assert.AreEqual("Details", viewResult.ViewName);
            
        }
    }
}
