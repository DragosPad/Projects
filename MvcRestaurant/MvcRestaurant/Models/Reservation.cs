using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcRestaurant.Models
{
    public class Reservation
    {
        public Reservation()
        {
            //Tables = new List<Table>();
        }
        public int ReservationId { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime? ReservationDate { get; set; }
        public DateTime? ReservationTime { get; set; }
        public string Message { get; set; }
        public int TableId { get; set; }
        public virtual Table Table { get; set; }
    }
}