using System;
using System.Collections.Generic;
using System.Linq;

namespace DroneDeliveryService
{
    /// <summary>
    /// Utility object to print the trips in different formats
    /// </summary>
    public class TripPublisher
    {
        /// <summary>
        /// Prints the Drone name and trips enumerated
        /// </summary>
        /// <param name="trips"></param>
        public void Print(List<Trip> trips) 
        {
            Console.WriteLine("");
            Console.WriteLine("* * *   Trip Summary    * * *");
            if (trips.Any())
            {
                var drones = trips.Select(trip => trip.Drone).Distinct();
                foreach (var drone in drones)
                {
                    int counter = 1;
                    Console.WriteLine($"Drone: {drone.Name}");
                    foreach (var trip in trips.Where(x => x.Drone == drone))
                    {
                        Console.WriteLine($"   Trip {counter++} : {trip.LocationsToString()}");
                    }
                }
                Console.WriteLine("");
            }
            else 
            {
                Console.WriteLine("No trips were found");
                Console.WriteLine("");
            }
            
        }

        /// <summary>
        /// Prints all the trips done by each drone
        /// </summary>
        /// <param name="trips"></param>
        public void Print_By_Drones(List<Trip> trips) 
        {
            var list = trips.OrderBy(x => x.Drone.Name).ToList();
            var current = "";
            foreach (var trip in list) 
            {
                var droneName = trip.Drone.Name;
                if (current != droneName) 
                {
                    Console.WriteLine($"{droneName}");
                    current = droneName;
                }

                foreach (var location in trip.Locations) 
                {
                    Console.WriteLine($"     {location.Name} ({location.Weight})");
                }
            }
        }

        /// <summary>
        /// Prints a list of locations
        /// </summary>
        /// <param name="title"></param>
        /// <param name="locations"></param>
        public void PrintLocations(string title, List<Location> locations) 
        {
            if (locations.Any()) 
            {
                Console.WriteLine(title);
                string line = String.Join(", ", locations.Select(x => x.ToString()));
                Console.WriteLine(line);
            }            
        }
    }
}
