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
       // public DbSet<Form> Forms { get; set; }
        public DbSet<ListForm> ListForms { get; set; }
    }
}