using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRestaurant.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult details()
        {
            return View();
        }     

    }
}
