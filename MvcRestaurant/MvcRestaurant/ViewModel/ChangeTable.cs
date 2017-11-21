using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcRestaurant.Models;
using System.Web.Mvc;

namespace MvcRestaurant.ViewModel
{
    public class ChangeTable
    {
        public Table Table { get; set; }
        public SelectList Status { get; set; }
        public SelectList Waiters { get; set; }
        public SelectList Dimensions { get; set; }
        public Dictionary<Waiter, List<Table>> AllocatedTable { get; set; }
        public List<Waiter> WaiterList { get; set; }
    }
}