using System;
using System.Collections.Generic;

namespace DroneDeliveryService
{
    /// <summary>
    /// Reads the Drones and locations from Command Line Console
    /// </summary>
    public class ConsoleInputReader : DeliveryInputReader
    {
        public List<Drone> Drones { get; set; }
        public List<Location> Locations { get; set; }

        public void Read() 
        {
            PrintMessage("Write the drones name and weight in the following format: Name, Weight, Name, Weight");
            try 
            {
                Drones = ReadDrones();
            }
            catch(Exception e) 
            {
                PrintMessage($"Wrong Drone input. Verify your data and try again [{e.Message}] ");
                throw;
            }

            try 
            {
                Locations = ReadLocations();
            } 
            catch (Exception e) 
            {
                PrintMessage($"Wrong location input. Verify your data and try again [{e.Message}]");
                throw;
            }
        }

        /// <summary>
        /// Reads the number of locations and then the location in each line
        /// </summary>
        /// <returns></returns>
        private List<Location> ReadLocations() 
        {
            var locations = new List<Location>();
            var total = ReadInt("Enter the total number of locations: ");

            PrintMessage("Write the location name and weight in the following format: Name, Weight, Name, Weight");
            for (int i=0; i<total; i++) 
            {
                locations.Add(ReadLocation($"Location {i+1} : "));
            }

            return locations;
        }

        private Location ReadLocation(string message)
        {
            Console.Write(message);
            var line = Console.ReadLine();
            var data = line.Split(',');
            return new Location() { Name = data[0].Trim(), Weight = Int32.Parse(data[1])};
        }

        /// <summary>
        /// Reads the line containing the Drones in one line in the following format: Name, Weight
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Drone> ReadDrones() 
        {
            var line = Console.ReadLine();

            if (!string.IsNullOrEmpty(line)) 
            {
                var data = line.Split(',');

                var drones = new List<Drone>();
                for (int i = 0; i < data.Length; i = i + 2)
                {
                    drones.Add(new Drone() { Name = data[i].Trim(), MaxWeight = Int32.Parse(data[i + 1].Trim()) });
                }

                return drones;
            }
            throw new Exception("Wrong Drones line");
            
        }

        /// <summary>
        /// Reads an int value from command line
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private int ReadInt(string message)
        {
            int value;
            string line = "";
            do
            {
                Console.Write(message);
                line = Console.ReadLine();
                if (!Int32.TryParse(line, out value))
                {
                    PrintMessage("Wrong number. Try again");
                    
                }
            } while (value <= 0);
            
            return value;
        }
 
        /// <summary>
        /// Prints a message in the console
        /// </summary>
        /// <param name="message"></param>
        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
