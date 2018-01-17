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

        [Required(ErrorMessage = "Name Passenger is required")]
        [StringLength(20)]
        public string NamePassenger { get; set; }

       [Required(ErrorMessage = "Date is required")]
      //  [Range(typeof(DateTime), "1/2/1900", "3/4/2000", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime? BirthdatePassenger { get; set; }

       [Required(ErrorMessage = "CNP is required")]
       [StringLength(13)]
        public long? CNP { get; set; }
        public int PlaceRow { get; set; }
        public int PlaceColumn { get; set; }
        public Plane Plane { get; set; }
        public int ReservationId { get; set; }
    }
}