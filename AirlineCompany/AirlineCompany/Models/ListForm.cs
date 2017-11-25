using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineCompany.Models
{
    public class ListForm
    {
        public int ListFormId { get; set; }
        public string LocationOfDeparture { get; set; }
        public DateTime FlightTime { get; set; }
        public string DestinationLocation { get; set; }
        public DateTime ArrivatTime { get; set; }
        public int FlightDuration { get; set; }
    }
}