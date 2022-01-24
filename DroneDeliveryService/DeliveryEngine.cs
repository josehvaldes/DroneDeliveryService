using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneDeliveryService
{
    /// <summary>
    /// Generates the trips for each drone and location collected by the DeliveryInputReader
    /// </summary>
    public class DeliveryEngine
    {
        private List<Drone> _drones;
        private List<Location> _locations;
        private const int MAX_ITERATIONS = 100;

        public DeliveryEngine(DeliveryInputReader reader) 
        {
            reader.Read();
            _drones = reader.Drones;
            _locations= reader.Locations;
        }

        /// <summary>
        /// Main Process to select the trips for each drone
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ProcessResult Process()
        {
            var result = new ProcessResult();

            var drones = _drones.OrderByDescending(x => x.MaxWeight);
            var locations = _locations.OrderByDescending(x => x.Weight).ToList();

            int iterations = 0;
            bool emptyLoad = false;
            while (locations.Any() && !emptyLoad && MAX_ITERATIONS > iterations++)
            {
                emptyLoad = true;
                foreach (var drone in drones)
                {
                    var trip = LoadTrips(drone, locations);
                    if (trip.HasLocations())
                    {
                        result.Trips.Add(trip);
                        emptyLoad = false;
                    }
                    if (!locations.Any())
                    {
                        break;
                    }
                }
            }

            if (locations.Any()) 
            {
                result.Omitted = locations;
            }

            return result;
        }

        /// <summary>
        /// Select ths locations that best fit the drone conditions
        /// </summary>
        /// <param name="drone"></param>
        /// <param name="locations"></param>
        /// <returns></returns>
        private Trip LoadTrips(Drone drone, List<Location> locations)
        {
            var trip = new Trip() { Drone = drone };
            var usedLocations = new List<Location>();

            foreach (var location in locations)
            {
                if (trip.IsFull()) 
                {
                    break;
                }
                else if (trip.IsThereSpace(location.Weight))
                {
                    trip.Add(location);
                    usedLocations.Add(location);
                }
            }

            locations.RemoveAll(x=> usedLocations.Contains(x));

            return trip;
        }
    }
}
