using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneDeliveryService
{
    public class ProcessResult
    {
        public List<Trip> Trips { get; set; }
        public List<Location> Omitted { get; set; }


        public ProcessResult() 
        {
            Trips = new List<Trip>();
            Omitted = new List<Location>();
        }

    }
}
