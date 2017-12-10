using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineCompany.Models
{
    public class InformationPassenger
    {
        public int InformationPassengerId { get; set; }
        public string NamePassenger { get; set; }
        public DateTime BirthdatePassenger { get; set; }
        public long CNP { get; set; }
    }
}