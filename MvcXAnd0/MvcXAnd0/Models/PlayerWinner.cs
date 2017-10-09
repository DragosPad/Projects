using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcXAnd0.Models
{
    public class PlayerWinner
    {
        public string Id { get; set; }
        public bool Winner { get; set; }

        public PlayerWinner(string userName)
        {
            Id = userName;
            Winner = false;
        }
    }
}