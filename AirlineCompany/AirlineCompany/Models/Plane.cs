using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineCompany.Models
{
    public class Plane
    {
        public int PlaneId { get; set; }
        public int NumberRow { get; set; }
        public int NumberPlaceRow { get; set; }
        public string ImageUrl { get; set; }
    }
}