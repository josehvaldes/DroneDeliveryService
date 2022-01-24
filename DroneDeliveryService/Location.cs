using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneDeliveryService
{
    public class Location
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{Name}({Weight})";
        }
    }
}
