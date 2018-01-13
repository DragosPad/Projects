using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineCompany.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
       // public virtual Fligth Fligth { get; set; }
        public int FligthId { get; set; }
        public int PlaceRow { get; set; }
        public int PlaceColumn { get; set; }
       // public InformationPassenger InformationPassenger { get; set; }
        public string NamePassenger { get; set; }

        //[Range(typeof(DateTime), "1/2/1900", "3/4/2000", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime BirthdatePassenger { get; set; }
        public long CNP { get; set; }
    }
}