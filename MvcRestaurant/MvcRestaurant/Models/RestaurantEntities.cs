using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcRestaurant.Models
{
    public class RestaurantEntities : DbContext
    {
        public DbSet<Table> Tables { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Reservation> BookingForms { get; set; }
        public DbSet<User> Users { get; set; }

        public RestaurantEntities()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ComplexType<Coords>();

            modelBuilder.Entity<Table>().Property(x => x.CoordinatesTable.CoordinateX).HasColumnName("XCoordinate");
            modelBuilder.Entity<Table>().Property(x => x.CoordinatesTable.CoordinateY).HasColumnName("YCoordinate");
        }
    }
}