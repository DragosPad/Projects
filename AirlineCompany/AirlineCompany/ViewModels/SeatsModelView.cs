using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineCompany.Models;

namespace AirlineCompany.ViewModels
{
    public class SeatsModelView
    {
        public InformationPassenger InfoPass { get; set; }
        public List<Plane> Planes { get; set; }
    }
}