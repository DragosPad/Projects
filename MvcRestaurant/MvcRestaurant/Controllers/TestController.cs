﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRestaurant.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        //
        // GET: /Test/

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
