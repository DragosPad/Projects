using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcRestaurant.Models;

namespace MvcRestaurant.ViewModel
{
    public class TableView
    {
        public int TableId { get; set;}
        public int BookingFormId { get; set; }
        public int DimensionTable { get; set; }

        public Coords CoordinatesTable { get; set; }
        public Status? Status { get; set; }
    }
}