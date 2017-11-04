using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcRestaurant.Models;

namespace MvcRestaurant.ViewModel
{
    public class TablesAndWaterView
    {
        public List<Table> Table1 { get; set; }
        public List<Waiter> Waiter1 { get; set; }
    }
}