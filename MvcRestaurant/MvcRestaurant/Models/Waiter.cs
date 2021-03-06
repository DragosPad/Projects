﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcRestaurant.Models
{
    public class Waiter
    {
        public int WaiterId { get; set; }
        public string Name { get; set; }
        public int NumberEmployee { get; set; }
        public int CoordinatorId { get; set; }
        public Waiter Coordinator { get; set; }
        public bool IsCoordinator { get; set; }
        public string Note { get; set; }
        public virtual List<Table> Tables { get; set; }
        public Status Status { get; set; }
        public IEnumerable<Status> Items { get; set; }
        public User User { get; set; }
    }
}