using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcRestaurant.Models;

namespace MvcRestaurant.ViewModel
{
    public class TablesAndWaterView
    {
        public Dictionary<String, List<Table>> AllocatedTable { get; set; }
        public List<Waiter> WaiterList { get; set; }
    }
}