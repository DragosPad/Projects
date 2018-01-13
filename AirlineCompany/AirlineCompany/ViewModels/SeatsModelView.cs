using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineCompany.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AirlineCompany.ViewModels
{
    public class SeatsModelView
    {
        public Fligth Fligth { get; set; }
        public string NamePassenger { get; set; }

        [Required]
       // [Range(typeof(DateTime), "1/2/1900", "3/4/2000", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime? BirthdatePassenger { get; set; }
        public long? CNP { get; set; }
        public int PlaceRow { get; set; }
        public int PlaceColumn { get; set; }
        public Plane Plane { get; set; }
       // public int ReservationId { get; set; }
    }
}