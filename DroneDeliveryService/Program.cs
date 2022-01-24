using System;

namespace DroneDeliveryService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine(" * * * * * Drone Delivery System * * * * * ");
            Console.WriteLine(" * * * * * * * * * * * * * * * * * * * * *");
            var reader = new ConsoleInputReader();
            var engine = new DeliveryEngine(reader);
            var result = engine.Process();

            var tripPublisher = new TripPublisher();
            tripPublisher.Print(result.Trips);
            tripPublisher.PrintLocations("The following locations were ommited", result.Omitted);
        }
    }
}
