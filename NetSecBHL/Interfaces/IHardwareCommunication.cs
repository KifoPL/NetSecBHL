using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    interface IHardwareCommunication
    {

        //Inputs
        public float getCurrentPowerUsage();
        public float getCurrentBattery();
        public float getCurrentFotovoltaicsPower();
        public float getCurrentHardwarePower();

        //Outputs              
      

    }
}
