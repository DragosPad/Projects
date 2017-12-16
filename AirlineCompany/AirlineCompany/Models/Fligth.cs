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
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public DateTime DateFlight { get; set; }
        public virtual List<Plane> Plane { get; set; }
    }
}