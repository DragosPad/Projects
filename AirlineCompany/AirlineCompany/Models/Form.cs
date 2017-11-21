using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineCompany.Models
{
    public class Form
    {
        public int FormId { get; set; }
        public DateTime DateForm { get; set; }
        public string Location { get; set; }
        public string Message { get; set; }
        public int FligthId { get; set; }
        public virtual List<Fligth> Fligth { get; set; }
    }
}