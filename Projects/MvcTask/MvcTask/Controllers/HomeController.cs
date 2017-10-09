using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTask.Models;
namespace MvcTask.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
           
            //var l = new TaskEntities();
            //l.Tasks.First();
            return View();


        }
        //public string Index()
        //{
        //    return "Hello from Home";
        //}
    }
}
