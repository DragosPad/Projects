using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcRestaurant.Models;
using System.Web.Mvc;

namespace MvcRestaurant.ViewModel
{
    public class WaiterTableViewModel
    {
        public Waiter Waiter { get; set; }
        public SelectList Statuses { get; set; }
    }
}