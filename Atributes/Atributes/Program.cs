using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using TestLibrary;


namespace Atributes
{
  public class Program
    {
        static void Main(string[] args)
        {
            Class1 c = new Class1();
            c.RunAttribute();
            Console.ReadLine();

        }

        public void Method()
        {
            System.Console.WriteLine("Finish");
        }
    }
}
