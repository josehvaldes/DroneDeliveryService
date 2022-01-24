using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DroneDeliveryService
{
    /// <summary>
    /// Reads the Drones and locations from a file in the file system
    /// </summary>
    public class FileInputReader : DeliveryInputReader
    {
        private string _fullfilename;
        public List<Drone> Drones { get; set; }
        public List<Location> Locations { get; set; }
        
        public FileInputReader(string filename) 
        {
            _fullfilename = filename;
        }

        public void Read()
        {
            var reader = new StreamReader(_fullfilename);

            Drones = ReadDrones(reader);

            Locations = ReadLocations(reader);
        }

        private List<Drone> ReadDrones(StreamReader reader)
        {
            var line = reader.ReadLine(); 
            var data = line.Split(',');

            var drones = new List<Drone>();
            for (int i = 0; i < data.Length; i += 2)
            {
                drones.Add(new Drone() { Name = data[i].Trim(), MaxWeight = Int32.Parse(data[i + 1].Trim()) });
            }

            return drones;
        }

        private List<Location> ReadLocations(StreamReader reader)
        {
            var locations = new List<Location>();
            while (!reader.EndOfStream) 
            {
                var line = reader.ReadLine().Trim();
                var data = line.Split(',');
                var location = new Location() { Name = data[0].Trim(), Weight = Int32.Parse(data[1]) };

                locations.Add(location);
            }

            return locations;
        }
    }
}
