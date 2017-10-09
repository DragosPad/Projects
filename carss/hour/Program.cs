using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hour
{
    class Program
    {
        static void Main(string[] args)
        {
            //Vehicle baza = new Vehicle();
            Car c = new Car();
            c.Operate();
            Truck t = new Truck();
            Motorcycle m = new Motorcycle();
            m.Operate();
            Tricycle tr = new Tricycle();
            //Vehicle b = new Vehicle();
            FourWheeledVehicle f = new FourWheeledVehicle();
            IVehicle ob = new Vehicle();
            ob.Operate();
            IEmergencyVehicle ob2 = new PoliceCar();
            ob2.SoundSiren();
            ob2.Operate();
            //b.Operate();
            //f.Operate();
           
           
            
            
            
            Vehicle v1 = c;
            Vehicle v2 = t;
            if (typeof(Car).IsAssignableFrom(v1.GetType()))
            {
                c = (Car)v1;
                Console.WriteLine(c.GetType());
            }
            if (v1 is Car)
            {
                c = (Car)v1;
                Console.WriteLine(c.GetType());
            }
            c = v1 as Car;
            if (c != null)
            {
                Console.WriteLine(c.GetType());
            }

            Console.ReadLine();
        }
    }
}
