using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coord
{

    public struct Coordinate
    {
        public int x;
        public int y;
    }

    class EntryPoint
    {
        public static void AttemptToModifyCoord(Coordinate coord)
        {
            coord.x = 1;
            coord.y = 3;
        }
        public static void ModifyCoord(ref Coordinate coord)
        {
            coord.x = 10;
            coord.y = 10;
        }
        static void Main(string[] args)
        {

            Coordinate location;
            location.x = 50;
            location.y = 50;

            AttemptToModifyCoord(location);
            System.Console.WriteLine("( {0}, {1} )", location.x, location.y);
           // Console.ReadLine();

            ModifyCoord(ref location);
            System.Console.WriteLine("( {0}, {1} )", location.x, location.y);
            Console.ReadLine();
        }
    }
}
