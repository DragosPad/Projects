using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcXAnd0.Models
{
    public class GameModel
    {
        public List<Coord> CurrentGame { get; set; }
        public Coord EditCoordonate { get; set; }
        public string Message { get; set; }
        public bool GameEnded { get; set; }
    }
}