using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hour
{
    interface IEmergencyVehicle : IVehicle
    {
        void SoundSiren();
    }
}
