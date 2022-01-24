using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneDeliveryService
{
    /// <summary>
    /// Based object handle the Drones trips
    /// </summary>
    public class Trip
    {
        public string Id { get; set; }
        public Drone Drone { get; set; }
        public List<Location> Locations { get; set; }
        public int UseWeight { get; set; }

        public Trip() 
        {
            Locations = new List<Location>();   
            UseWeight = 0;      
        }

        public bool HasLocations() 
        { 
            return Locations.Any();
        }

        public bool IsThereSpace(int weight)
        {
            return Drone.MaxWeight - UseWeight >= weight;
        }

        public string LocationsToString()
        {
            var value = "";
            for (int i = 0; i < Locations.Count; i++) 
            {
                var location = Locations[i];
                value += $"{location.Name} ({location.Weight})";
                if (i != Locations.Count - 1) 
                {
                    value += " - ";
                }
            }

            return value;
        }

        public bool IsFull() 
        {
            return UseWeight == Drone.MaxWeight;
        }

        internal void Add(Location location)
        {
            Locations.Add(location);
            UseWeight += location.Weight;
        }
    }
}
