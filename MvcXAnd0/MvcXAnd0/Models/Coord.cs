using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcXAnd0.Models
{
    
    public enum Player
    {
      X,
      O
    }
    public class Coord
    {
     
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public Player? Player { get; set;}
        public bool IsEmpty { get; set; }
       
    }
    
}