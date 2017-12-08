using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestaurant.Models;
using System.Data.Entity;
using MvcRestaurant.ViewModel;
using System.Net;
using System.Data;
using MvcRestaurant.Filters;


namespace MvcRestaurant.Controllers
{
    
    [Authorization(Roles = "Waiter")]
    public class WaitersController : Controller
    {
        private RestaurantEntities db = new RestaurantEntities();
   
        [Authorize]
        public ActionResult Index()
        {
            var waiter = db.Waiters.Include(c => c.Tables);
            return View(waiter);
        }

        public ActionResult WriteNote(int tableId)
        {
            WaiterTableViewModel viewModel = new WaiterTableViewModel();
            Table table = db.Tables.Include(c => c.Waiter).Single(c => c.TableId == tableId);
            var tables = db.Tables.Include(t => t.Waiter).ToList();
            viewModel.AllocatedTable = tables.GroupBy(i => i.WaiterId).ToDictionary(m => m.First().Waiter != null? m.First().Waiter.Name + " " + m.First().Waiter.NumberEmployee : string.Empty, m => m.ToList());
           
            var enumStatus = from Status e in Enum.GetValues(typeof(Status))
                             select new
                             {
                                 ID = e,
                                 Name = e.ToString()
                             };
            var note = db.Waiters.Select(w => new
            {
                Id = w.WaiterId,
                Note = w.Note

            });
            viewModel.Statuses = new SelectList(enumStatus, "ID", "Name");
            viewModel.Table = table;
            viewModel.Waiter = table.Waiter;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult WriteNote(Table table, Waiter waiter)
        {
          
            if (ModelState.IsValid)
            {
                var changeTable = db.Tables.SingleOrDefault(t => t.TableId == table.TableId);
                changeTable.Status = table.Status;
                changeTable.Waiter.Note = table.Waiter.Note;
                db.SaveChanges();
                return RedirectToAction("Index");

            
            }

            var viewModel = table;
        
            return View(viewModel);
        }

       // [Authorize]
        public ActionResult TablesView( int waiterId)
        {
            WaiterTableViewModel viewModel = new WaiterTableViewModel();
          Waiter waiter = db.Waiters.Include(w => w.Tables).Single(w => w.WaiterId == waiterId);
          viewModel.Waiter = waiter;
          var enumStatus = from Status e in Enum.GetValues(typeof(Status))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
          ViewBag.EnumList = new SelectList(enumStatus, "ID", "Name");
          
          return View(viewModel);
        }

        [Authorization(Roles = "Coordinator")]
        public ActionResult Coordinator()
        {
            TablesAndWaterView viewModel = new TablesAndWaterView();

           var tables = db.Tables.Include(t => t.Waiter).ToList();
           var x = tables.GroupBy(t => t.WaiterId);         
           viewModel.AllocatedTable = tables.GroupBy(i => i.WaiterId).ToDictionary(m => m.First().Waiter != null ? m.First().Waiter.Name + " " + m.First().Waiter.NumberEmployee : string.Empty, m => m.ToList());
           viewModel.WaiterList = db.Waiters.Where(w => w.Tables.Any() == false).ToList();

            return View(viewModel);
            
        }

        public ActionResult Change(int tableId)
        {

            Table table = db.Tables.Include(c => c.Waiter).Single(c => c.TableId == tableId);
            var changeTable = CreateChangeTable(table);


           return View(changeTable);
        }

        private ChangeTable CreateChangeTable(Table table)
        {
            ChangeTable viewModel = new ChangeTable();

            var tables = db.Tables.Include(t => t.Waiter).ToList();
            viewModel.WaiterList = db.Waiters.Where(w => w.Tables.Any() == false).ToList();

            var enumStatus = from Status e in Enum.GetValues(typeof(Status))
                             select new
                             {
                                 ID = e,
                                 Name = e.ToString()
                             };
            var waiter = db.Waiters.Select(w => new
            {
                Id = w.WaiterId,
                Name = w.Name

            });
            var dimension = Enumerable.Range(2, 7);

            viewModel.Status = new SelectList(enumStatus, "ID", "Name");
            viewModel.Table = table;
            viewModel.Waiters = new SelectList(waiter, "Id", "Name");
            viewModel.Dimensions = new SelectList(dimension);


            return viewModel;
         
        }

        [HttpPost]
        public ActionResult Change(Table table)
        {
            if (ModelState.IsValid)
            {
               
                var changeTable = db.Tables.SingleOrDefault(t => t.TableId == table.TableId);
                changeTable.WaiterId = table.WaiterId;
                changeTable.Status = table.Status;
                changeTable.DimensionTable = table.DimensionTable;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var viewModel = CreateChangeTable(table);
            return View(viewModel);
        }

        public ActionResult AddWaiter()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddWaiter(Waiter waiter)
        {
            if (ModelState.IsValid)
            {
                db.Waiters.Add(waiter);
                db.SaveChanges();
                return RedirectToAction("Coordinator");
            }
            return View();
        }

        public ActionResult AddTable()
        {

            return View();
        }

       [HttpPost]
        public ActionResult AddTable(Table table)
        {
            if (ModelState.IsValid)
            {
                db.Tables.Add(table);
                db.SaveChanges();
                return RedirectToAction("Coordinator");
            }

            return View(table);
        }



    }

}
