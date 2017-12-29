using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AirlineCompany.Models
{
    public class SampleData : DropCreateDatabaseAlways<AirlineEntities>
    {
        protected override void Seed(AirlineEntities context)
        {
           var p = new List<Plane>
            {
                new Plane { NumberRow = 2, NumberPlaceRow = 4 },
                new Plane { NumberRow = 4, NumberPlaceRow = 8 },
                new Plane { NumberRow = 7, NumberPlaceRow = 6 },
                new Plane { NumberRow = 10, NumberPlaceRow = 10 },
                new Plane { NumberRow = 5, NumberPlaceRow = 2 },
                new Plane { NumberRow = 7, NumberPlaceRow = 4 },
                new Plane { NumberRow = 2, NumberPlaceRow = 8 }

            };
            p.ForEach(a => context.Planes.Add(a));

            new List<Fligth>
            {
                new Fligth { Location = "Bucharest", Destination = "Madrid", FlightDuration = 8, DepartureTime = "16:30", ArrivalTime = "20:00", DateFlight = new DateTime(2017, 12, 12), 
                    Planes = new List<Plane>() {p[0]}},
                new Fligth { Location = "Bucharest", Destination = "Rome", FlightDuration = 6, DepartureTime = "03:30", ArrivalTime = "09:00", DateFlight = new DateTime(2017, 12, 12), 
                Planes = new List<Plane>() {p[1]}},
                new Fligth { Location = "Paris", Destination = "Madrid", FlightDuration = 4, DepartureTime = "09:30", ArrivalTime = "20:00", DateFlight = new DateTime(2017, 12, 10), 
                Planes = new List<Plane>() {p[2]}},
                new Fligth { Location = "Vienna", Destination = "Rome", FlightDuration = 2, DepartureTime = "10:30", ArrivalTime = "22:00", DateFlight = new DateTime(2017, 12, 12), 
                Planes = new List<Plane>() {p[3]}},
                new Fligth { Location = "Berlin", Destination = "Bucharest", FlightDuration = 5, DepartureTime = "16:30", ArrivalTime = "23:00", DateFlight = new DateTime(2017, 12, 10), 
                Planes = new List<Plane>() {p[4]}},
                new Fligth { Location = "Athens", Destination = "Berlin", FlightDuration = 7, DepartureTime = "11:30", ArrivalTime = "20:00", DateFlight = new DateTime(2017, 12, 12),
                Planes = new List<Plane>() {p[5]}},

            }.ForEach(b => context.Fligths.Add(b));
            
            //base.Seed(context);
        }


    }
}