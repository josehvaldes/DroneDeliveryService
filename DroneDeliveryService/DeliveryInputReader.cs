using System.Collections.Generic;

namespace DroneDeliveryService
{
    public interface DeliveryInputReader
    {
        List<Drone> Drones { get;}
        List<Location> Locations { get; }
        void Read();
    }
}
