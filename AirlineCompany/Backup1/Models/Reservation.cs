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
        public int FligthId { get; set; }
        public int PlaceRow { get; set; }
        public int PlaceColumn { get; set; }
        public string NamePassenger { get; set; }
        public DateTime BirthdatePassenger { get; set; }
        public long CNP { get; set; }
    }
}