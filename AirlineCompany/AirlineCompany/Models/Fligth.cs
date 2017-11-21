using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineCompany.Models
{
    public class Fligth
    {
        public int FligthId { get; set; }
        public string Location{ get; set; }
        public string Destination { get; set; }
        public int FlightDuration { get; set; }
        public string DepartureTime = DateTime.Now.ToString("mm:ss");
    }
}