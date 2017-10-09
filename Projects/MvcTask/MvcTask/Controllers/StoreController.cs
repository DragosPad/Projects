using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTask.Models;

namespace MvcTask.Controllers
{
    public class StoreController : Controller
    {
        TaskEntities storeDB = new TaskEntities();
        
        public ActionResult Index()
        {
           var listgens = storeDB.ListGens.ToList();

           return View(listgens);
           
        }
        
        public ActionResult Browse(string listgen)
        {
            var listgenModel = storeDB.ListGens.Include("Tasks").Single(g => g.Name == listgen);

            return View(listgenModel);
        }

        public ActionResult Details(int id)
        {
            var listtask = storeDB.Tasks.Find(id);
            return View(listtask);
        }
    }
}
