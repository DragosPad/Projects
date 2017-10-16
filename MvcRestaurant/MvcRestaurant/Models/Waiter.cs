using System;
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
        public string Note { get; set; }
        public virtual List<Table> Tables { get; set; }
        public int? TableId { get; set; }
    }
}