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
            new List<Plane>
            {
                new Plane { NumberRow = 20, NumberPlaceRow = 4 },
                new Plane { NumberRow = 24, NumberPlaceRow = 8 },
                new Plane { NumberRow = 40, NumberPlaceRow = 6 },
                new Plane { NumberRow = 30, NumberPlaceRow = 10 },
                new Plane { NumberRow = 30, NumberPlaceRow = 2 },
                new Plane { NumberRow = 28, NumberPlaceRow = 4 },
                new Plane { NumberRow = 25, NumberPlaceRow = 8 }

            }.ForEach(a => context.Planes.Add(a));

            new List<Fligth>
            {
                new Fligth { Location = "Bucharest", Destination = "Madrid", FlightDuration = 8, DepartureTime = "16:30", ArrivalTime = "20:00"},
                new Fligth { Location = "Bucharest", Destination = "Rome", FlightDuration = 6, DepartureTime = "03:30", ArrivalTime = "09:00"},
                new Fligth { Location = "Paris", Destination = "Madrid", FlightDuration = 4, DepartureTime = "09:30", ArrivalTime = "20:00"},
                new Fligth { Location = "Vienna", Destination = "Rome", FlightDuration = 2, DepartureTime = "10:30", ArrivalTime = "22:00"},
                new Fligth { Location = "Berlin", Destination = "Bucharest", FlightDuration = 5, DepartureTime = "16:30", ArrivalTime = "23:00"},
                new Fligth { Location = "Athens", Destination = "Berlin", FlightDuration = 7, DepartureTime = "11:30", ArrivalTime = "20:00"},

            }.ForEach(b => context.Fligths.Add(b));
            
            //base.Seed(context);
        }


    }
}