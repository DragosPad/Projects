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
                new Plane { NumberRow = 4, NumberPlaceRow = 27 },
                new Plane { NumberRow = 3, NumberPlaceRow = 26 },
                new Plane { NumberRow = 4, NumberPlaceRow = 25 },
                new Plane { NumberRow = 3, NumberPlaceRow = 26 },
                new Plane { NumberRow = 5, NumberPlaceRow = 27 },
                new Plane { NumberRow = 4, NumberPlaceRow = 25 },
                new Plane { NumberRow = 4, NumberPlaceRow = 26 }

            };
            p.ForEach(a => context.Planes.Add(a));

            new List<Fligth>
            {
                new Fligth {FligthId = 1, Location = "Bucharest", Destination = "Madrid", FlightDuration = 8, DepartureTime = "16:30", ArrivalTime = "20:00", DateFlight = new DateTime(2017, 12, 12), 
                    Plane = p[0]},
                new Fligth {FligthId = 2, Location = "Bucharest", Destination = "Rome", FlightDuration = 6, DepartureTime = "03:30", ArrivalTime = "09:00", DateFlight = new DateTime(2017, 12, 12), 
                Plane = p[1]},
                new Fligth { FligthId = 3, Location = "Paris", Destination = "Madrid", FlightDuration = 4, DepartureTime = "09:30", ArrivalTime = "20:00", DateFlight = new DateTime(2017, 12, 10), 
                Plane = p[2]},
                new Fligth { FligthId = 4, Location = "Vienna", Destination = "Rome", FlightDuration = 2, DepartureTime = "10:30", ArrivalTime = "22:00", DateFlight = new DateTime(2017, 12, 12), 
                Plane = p[3]},
                new Fligth {FligthId = 5, Location = "Berlin", Destination = "Bucharest", FlightDuration = 5, DepartureTime = "16:30", ArrivalTime = "23:00", DateFlight = new DateTime(2017, 12, 10), 
                Plane = p[4]},
                new Fligth {FligthId = 6, Location = "Athens", Destination = "Berlin", FlightDuration = 7, DepartureTime = "11:30", ArrivalTime = "20:00", DateFlight = new DateTime(2017, 12, 12),
                Plane = p[5]},

            }.ForEach(b => context.Fligths.Add(b));
            
            //base.Seed(context);
        }


    }
}