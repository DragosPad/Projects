using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineCompany.Models;

namespace AirlineCompany.ViewModels
{
    public class SeatsModelView
    {
       // public int FligthId { get; set; }
        public Fligth Fligth { get; set; }
       // public InformationPassenger InfoPass { get; set; }
        public string NamePassenger { get; set; }
        public DateTime BirthdatePassenger { get; set; }
        public long CNP { get; set; }
        public int PlaceRow { get; set; }
        public int PlaceColumn { get; set; }

        //public int NumberRow { get; set; }
        //public int NumberPlaceRow { get; set; }

       // public Plane Planes { get; set; }
    }
}