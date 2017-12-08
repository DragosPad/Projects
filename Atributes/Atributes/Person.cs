using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLibrary;

namespace Atributes
{
    public class Person
    {
        public string Name { get; set; }
        
        [Example("AAA", "BB", "CC")]
        public void IncreaseAge(string message)
        {
            System.Console.WriteLine("Another year has passed");
            //Program p = new Program();
            //p.Method();
        }

        
        public void DecreaseAge()
        {
            System.Console.WriteLine("Mistake");
        }
    }
   
}
