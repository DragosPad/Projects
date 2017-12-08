using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLibrary;

namespace Atributes
{
    public class Engineer
    {
        [Example(1,2,7)]
        public void Test(int x, int y, int z)
        {
            System.Console.WriteLine("I am an engineer");
        }
    }
}
