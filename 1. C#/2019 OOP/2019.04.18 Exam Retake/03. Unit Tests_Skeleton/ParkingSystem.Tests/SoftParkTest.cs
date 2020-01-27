namespace ParkingSystem.Tests
{
    using NUnit.Framework;

    public class SoftParkTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Car_IsCreatedSuccessfuly()
        {
            string expectedMake = "Nissan";
            string expectedregistrationNumber = "CA7777MH";
            var car = new Car(expectedMake, expectedregistrationNumber);

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedregistrationNumber, car.RegistrationNumber);
        }

        [Test]
        public void ContructorTest()
        {
            string expectedMake = "Nissan";
            string expectedregistrationNumber = "CA7777MH";
            var car = new Car(expectedMake, expectedregistrationNumber);

            var softPark = new SoftPark();
            var testSpot = "A1";

            softPark.ParkCar(testSpot, car);
            
            Assert.AreEqual(expectedMake, car.Make);

        }

    }
}