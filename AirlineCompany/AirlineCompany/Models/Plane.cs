using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AirlineCompany.Models
{
    public class Plane
    {
        public int PlaneId { get; set; }
        public int NumberRow { get; set; }
        public int NumberPlaceRow { get; set; }
        public string ImageUrl { get; set; }
        public virtual Fligth Fligth { get; set; }
    }
}