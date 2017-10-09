using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcXAnd0.Models
{
    public class TableGames
    {
        public Player[,] GameTable { get; set; }
        public List<Coord> Move { get; set; }
    }
}