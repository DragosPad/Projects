using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTask.Models;
using System.Data.Entity;
using System.Data;
using System.Net;


namespace MvcTask.Controllers
{
    public class StoreListGenController : Controller
    {
        private TaskEntities db = new TaskEntities();
        
        public ActionResult Index()
        {
            var listgens = db.ListGens.Include(a => a.Tasks);
            //List<Task> listtask = new List<Task>();
            
            return View(listgens.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.ListGenId = new SelectList(db.ListGens, "GenreId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(ListGen listgen)
        {
            if (ModelState.IsValid)
            {
                db.ListGens.Add(listgen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListGenId = new SelectList(db.ListGens, "ListGenId", "Name");
            return View(listgen);
        }
        public ActionResult Edit(int listId)
        {
           
            ListGen listgen = db.ListGens.Include(l => l.Tasks).Single(l => l.ListGenId == listId);
            ViewBag.GenreId = new SelectList(db.ListGens, "ListGenId", "Name", listgen.ListGenId);
            return View(listgen);
        }
        [HttpPost]
        public ActionResult Edit(ListGen listgen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listgen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.ListGens, "ListGenId", "Name", listgen.ListGenId);
            return View(listgen);
        }
        public ActionResult Delete(int id)
        {
            ListGen listgen = db.ListGens.Find(id);

            return View(listgen);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            ListGen listgen = db.ListGens.Find(id);
            db.ListGens.Remove(listgen);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteAll(int id)
        {

            ListGen listgen = db.ListGens.Find(id);
            return View(listgen);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("DeleteAll")]
        public ActionResult DeleteAll(int id, FormCollection collection)
        {

            ListGen listgen = db.ListGens.Find(id);
           // db.ListGens.Remove(listgen);
            List<Task> tasksdelet = new List<Task>();
            tasksdelet.AddRange(listgen.Tasks);
            foreach (var listgentask in tasksdelet)
            {
                db.Tasks.Remove(listgentask);
            }
            db.ListGens.Remove(listgen);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
