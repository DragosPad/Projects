using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hour
{
    public class Vehicle : IVehicle
    {
        public Vehicle() { }
        public Vehicle(int wheels)
        {
            Console.WriteLine("The number of wheeles requested is {0}", wheels);
        }
        void IVehicle.Operate()
        {
            Console.WriteLine("eroare ");
        }
        public virtual void Operate()
        {
            Console.WriteLine("Default ");
         }
    }
    public class FourWheeledVehicle : Vehicle 
    {
        public FourWheeledVehicle() : base(4) { }
        

        public override void Operate()
        {
            base.Operate();
            Console.WriteLine("Driving a four-wheeled vehicle");
        }
        
    }
      public class TwoWheeledVehicle : Vehicle 
    {
          public TwoWheeledVehicle() : base(2) { }
          public override void Operate()
          {
              //base.Operate();
              Console.WriteLine("Driving a two-wheeled vehicle");
          }
        
    }
      public class ThreeWheeledVehicle : Vehicle 
      {
          public ThreeWheeledVehicle() : base(3) { }
      }
    public class Car : FourWheeledVehicle 
    {
        public override void Operate()
        {
            base.Operate();
            Console.WriteLine("Driving a car");
        }
    }

    public class Truck : FourWheeledVehicle { }
    public class Motorcycle : TwoWheeledVehicle { }
    public class Tricycle : ThreeWheeledVehicle { }

    public class PoliceCar : Vehicle, IVehicle, IEmergencyVehicle
    {
        void IEmergencyVehicle.SoundSiren()
        {
            Console.WriteLine("Sound");
        }
    }
   
    public class PoliceMotorcycle : Vehicle { }
    public class FireTruck : Vehicle { }
    
}
