using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcRestaurant.Models
{
    public enum Status
    {
        Free,
        Occupied,
        Reserved

    }
    public class Table
    {
        public int TableId { get; set; }
        //public int BookingFormId { get; set; }
        public int DimensionTable { get; set; }
        public Status? Status { get; set; }
        public Coords CoordinatesTable { get; set;}
        public string ImageUrl { get; set; }
        public virtual List<Reservation> BookingForms { get; set; }
        public int? WaiterId { get; set; }
        //public ImageHelper Image { get; set; }

    }

   


    public class Coords
    {
       private int x, y;
       
        public int CoordinateX
        {
            get { return x; }
            set { x = value; }
        }
        public int CoordinateY
        {
            get { return y; }
            set { y = value; }
        }
        public Coords()
        {

        }
        public Coords(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }
}