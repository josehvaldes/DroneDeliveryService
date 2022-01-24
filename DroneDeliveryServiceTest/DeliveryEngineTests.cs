using DroneDeliveryService;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneDeliveryServiceTest
{
    [TestFixture]
    public class DeliveryEngineTests
    {
        private const string Default_File = @"TestInput\Test1.txt";
        private const string Test_2 = @"TestInput\Test2.txt";
        private const string Test_3 = @"TestInput\Test3.txt";

        private DeliveryEngine _deliveryEngine;
        private TripPublisher _publisher;


        [SetUp]
        public void Setup() 
        {
            _publisher = new TripPublisher();
        }

        [Test]
        public void Process_Trips_NotEmpty() 
        {
            _deliveryEngine = new DeliveryEngine(new FileInputReader(Default_File));
            var result = _deliveryEngine.Process();
            Assert.IsNotEmpty(result.Trips);
        }

        [Test]
        public void Process_Trips_Equals_2()
        {
            _deliveryEngine = new DeliveryEngine(new FileInputReader(Default_File));
            var result = _deliveryEngine.Process();
            Assert.AreEqual(2, result.Trips.Count);
        }

        [Test]
        public void Process_Trips_Equals_4()
        {
            _deliveryEngine = new DeliveryEngine(new FileInputReader(Test_2));
            var result = _deliveryEngine.Process();
            Assert.AreEqual(4, result.Trips.Count);
            _publisher.Print(result.Trips);
        }

        [Test]
        public void Process_Trips_Equals()
        {
            _deliveryEngine = new DeliveryEngine(new FileInputReader(Test_3));
            var result = _deliveryEngine.Process();
            Assert.IsNotEmpty(result.Trips);
            _publisher.Print(result.Trips);
        }

    }
}
