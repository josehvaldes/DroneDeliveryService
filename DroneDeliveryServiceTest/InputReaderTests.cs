using System;
using DroneDeliveryService;
using NUnit.Framework;
namespace DroneDeliveryServiceTest
{
    [TestFixture]
    public class InputReaderTests
    {
        private const string Default_File = @"TestInput\Test1.txt";

        private FileInputReader _inputReader;

        [SetUp]
        public void Setup() 
        {
            _inputReader = new FileInputReader(Default_File);
        }


        [Test]
        public void Read_DefaultInput_Drones_Not_Null()
        {
            _inputReader.Read();
            Assert.NotNull(_inputReader.Drones);
        }

        [Test]
        public void Read_DefaultInput_Load_2_Drones() 
        {
            var expectedDrones = 2;
            _inputReader.Read();
            Assert.AreEqual(_inputReader.Drones.Count, expectedDrones);
        }

        [Test]
        public void Read_DefaultInput_Locations_Not_Null()
        {
            _inputReader.Read();
            Assert.NotNull(_inputReader.Locations);
        }


        [Test]
        public void Read_DefaultInput_Load_3_Locations()
        {
            var expectedLocations = 3;
            _inputReader.Read();
            Assert.AreEqual(_inputReader.Locations.Count, expectedLocations);
        }

    }
}
