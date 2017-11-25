using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcRestaurant.Models;
using System.Web.Routing;
using System.Web.Mvc;

namespace MvcRestaurant.ViewModel
{
    public class BookingTable
    {
        public List<TableView> TablesView { get; set; }
        public Reservation Reservation { get; set; }
        public TableView TableView { get; set; }
    }
    
}