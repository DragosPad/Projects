﻿using System;
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
        public Table Table { get; set; }
        public SelectList Note { get; set; }
        public Dictionary<Waiter, List<Table>> AllocatedTable { get; set; }
    }
}