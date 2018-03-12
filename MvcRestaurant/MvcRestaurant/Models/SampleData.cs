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
               new Table {TableId = 1, DimensionTable = 4, Status=Status.Free, CoordinatesTable = new Coords(0, 0), ImageUrl="/Content/images/imagine1.png",
               BookingForms = new List<Reservation>() {new Reservation() {ReservationDate = DateTime.Today.AddDays(2), NumberOfPeople =4}}
             },
               new Table {TableId = 2, DimensionTable = 2, Status=Status.Occupied, CoordinatesTable = new Coords(0, 1), ImageUrl="/Content/images/imagine1.png" },
               new Table {TableId = 3, DimensionTable = 6, Status=Status.Reserved, CoordinatesTable = new Coords(0, 2), ImageUrl="/Content/images/imagine1.png" },
               new Table {TableId = 4, DimensionTable = 4, Status=Status.Occupied, CoordinatesTable = new Coords(1, 0), ImageUrl="/Content/images/imagine1.png" },
               new Table {TableId = 5, DimensionTable = 8, Status=Status.Reserved, CoordinatesTable = new Coords(2, 0), ImageUrl="/Content/images/imagine1.png" },
               new Table {TableId = 6, DimensionTable = 2, Status=Status.Free, CoordinatesTable = new Coords(1, 1), ImageUrl="/Content/images/imagine1.png" },
               new Table {TableId = 7, DimensionTable = 6, Status=Status.Free, CoordinatesTable = new Coords(2, 2), ImageUrl="/Content/images/imagine1.png" }
               
            
            
            }; 
            //foreach (var table in tableList
            x.ForEach(a => context.Tables.Add(a));

            Waiter coordinator = new Waiter() 
            {
              Name = "Bontea",
              NumberEmployee = 3,
              IsCoordinator = true,
              User = new User() { UserName = "Bontea@yahoo.com", passWord = "000" }
            };
            new List<Waiter> 
            
            {
                new Waiter {WaiterId = 1, Name = "Jack", NumberEmployee = 5, Coordinator = coordinator,
                
                Tables = new List<Table>() {x[0], x[1]}, User = new User(){UserName = "dragospaduraru89@yahoo.com", passWord = "1"}},
                    
                new Waiter {WaiterId = 2, Name = "Jerry", NumberEmployee = 1, Coordinator = coordinator,
                 Tables = new List<Table>() { x[2]
                 },User = new User(){UserName = "dragos@yahoo.com", passWord = "222"}},
                new Waiter {WaiterId = 3, Name = "Andre", NumberEmployee = 3, Coordinator = coordinator,
                 Tables = new List<Table>() { x[3]
                 },User = new User(){UserName = "Andre@yahoo.com", passWord = "333"}},
                new Waiter {WaiterId = 4, Name = "Anton", NumberEmployee = 8, Coordinator = coordinator,
                Tables = new List<Table>() { x[4], x[5], x[6]
                     },User = new User(){UserName = "Anton@yahoo.com", passWord = "444"}},
                     new Waiter {WaiterId = 5, Name = "Hadean", NumberEmployee = 4, Coordinator = coordinator, User = new User(){UserName = "Hadean@yahoo.com", passWord = "555"}},
                     new Waiter {WaiterId = 6, Name = "Patricia", NumberEmployee  = 2, Coordinator = coordinator, User = new User(){UserName = "Patricia@yahoo.com", passWord = "666"}},
                      new Waiter {WaiterId = 7, Name = "Florin", NumberEmployee  = 2, Coordinator = coordinator, User = new User(){UserName = "Florin@yahoo.com", passWord = "777"}}
            
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