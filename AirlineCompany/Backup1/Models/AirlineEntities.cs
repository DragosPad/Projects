using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AirlineCompany.Models 
{
    public class AirlineEntities : DbContext
    {
        public DbSet<Fligth> Fligths { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<InformationPassenger> InformationPassenger { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
      
    }
}