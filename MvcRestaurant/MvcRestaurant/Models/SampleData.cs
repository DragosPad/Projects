using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcRestaurant.Models
{
    public class SampleData : DropCreateDatabaseAlways<RestaurantEntities>
    {
        protected override void Seed(RestaurantEntities context)
        {
           var x = new List<Table> 
            {
               new Table { DimensionTable = 4, Status=Status.Free, CoordinatesTable = new Coords(0, 0), ImageUrl="/Content/images/imagine1.png",
               BookingForms = new List<Reservation>() {new Reservation() {ReservationDate = DateTime.Today.AddDays(2), NumberOfPeople =4}}
             },
               new Table { DimensionTable = 2, Status=Status.Occupied, CoordinatesTable = new Coords(0, 1), ImageUrl="/Content/images/imagine1.png" },
               new Table { DimensionTable = 6, Status=Status.Reserved, CoordinatesTable = new Coords(0, 2), ImageUrl="/Content/images/imagine1.png" },
               new Table { DimensionTable = 4, Status=Status.Occupied, CoordinatesTable = new Coords(1, 0), ImageUrl="/Content/images/imagine1.png" },
               new Table { DimensionTable = 8, Status=Status.Reserved, CoordinatesTable = new Coords(2, 0), ImageUrl="/Content/images/imagine1.png" },
               new Table { DimensionTable = 2, Status=Status.Free, CoordinatesTable = new Coords(1, 1), ImageUrl="/Content/images/imagine1.png" },
               new Table { DimensionTable = 6, Status=Status.Free, CoordinatesTable = new Coords(2, 2), ImageUrl="/Content/images/imagine1.png" }
               
            
            
            }; 
            //foreach (var table in tableList
            x.ForEach(a => context.Tables.Add(a));

            Waiter coordinator = new Waiter() 
            {
              Name = "Bontea",
              NumberEmployee = 3
            };
            new List<Waiter> 
            
            {
                new Waiter { Name = "Jack", NumberEmployee = 5, Coordinator = coordinator,
                
                Tables = new List<Table>() {x[0], x[1]}},
                    
                new Waiter { Name = "Jerry", NumberEmployee = 1, Coordinator = coordinator,
                 Tables = new List<Table>() { x[2]
                 }},
                new Waiter { Name = "Andre", NumberEmployee = 3, Coordinator = coordinator,
                 Tables = new List<Table>() { x[3]
                 }},
                new Waiter { Name = "Anton", NumberEmployee = 8, Coordinator = coordinator,
                Tables = new List<Table>() { x[4], x[5], x[6]
                     }}
            
            }.ForEach(b => context.Waiters.Add(b));

            var u = new List<User> {
               new User {UserName = "1Pas@yahoo.com", passWord = "23"},
               new User {UserName = "2Pas@yahoo.com", passWord = "26"}
            };
            u.ForEach(c => context.Users.Add(c)); 
           
            //base.Seed(context);
        }
    }
}