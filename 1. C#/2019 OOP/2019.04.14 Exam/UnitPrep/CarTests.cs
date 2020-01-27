using CarTrip;
using NUnit.Framework;
using System;

namespace CarTrip.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestPropertyGettersWorkCorrectly()
        {
            Car car = new Car("Kola", 60, 50, 0.2);

            string model = car.Model;
            double capacity = car.TankCapacity;
            double fuel = car.FuelAmount;
            double consumption = car.FuelConsumptionPerKm;

            string expectedModel = "Kola";
            double expectedCapacity = 60;
            double expectedFuel = 50;
            double expectedConsumption = 0.2;

            Assert.AreEqual(expectedModel, model, "Model getter does not work correctly!");
            Assert.AreEqual(expectedCapacity, capacity, "Capacity getter does not work correctly!");
            Assert.AreEqual(expectedFuel, fuel, "Fuel getter does not work correctly!");
            Assert.AreEqual(expectedConsumption, consumption, "Consumption getter does not work correctly!");
        }

        [Test]
        public void TestModelSetterThrowsArgumentExceptionForInvalidData()
        {
            Assert.Throws<ArgumentException>(() => new Car("", 60, 50, 0.2), "Model setter does not validate the input data!");
        }

        [Test]
        public void TestTankSetterThrowsArgumentExceptionForInvalidData()
        {
            Assert.Throws<ArgumentException>(() => new Car("Kola", 60, 65, 0.2), "Fuel setter does not validate the input data!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TestFuelAmountSetterThrowsArgumentExceptionForInvalidData(double consumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("Kola", 60, 50, consumption), "Consumption setter does not validate the input data!");

        }

        [Test]
        public void TestIfDriveMethodReducesFuelAmount()
        {
            Car car = new Car("Kola", 60, 50, 0.2);
            string expectedMessage = "Have a nice trip";
            string message = car.Drive(10);

            double fuel = car.FuelAmount;
            double expectedFuel = 48;

            Assert.AreEqual(expectedFuel, fuel);
            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void TestIfDriveMethodThrowsExceptionWhenFuelIsNotEnough()
        {
            Car car = new Car("Kola", 60, 50, 0.2);

            Assert.Throws<InvalidOperationException>(() => car.Drive(1000));
        }

        [Test]
        public void TestIfRefuelMethodIncreasesFuelAmount()
        {
            Car car = new Car("Kola", 60, 50, 0.2);
            car.Refuel(10);

            double fuel = car.FuelAmount;
            double expectedFuel = 60;

            Assert.AreEqual(expectedFuel, fuel);
        }

        [Test]
        public void TestIfRefuelMethodThrowsExceptionWhenTooMuchFuel()
        {
            Car car = new Car("Kola", 60, 50, 0.2);
            

            Assert.Throws<InvalidOperationException>(() => car.Refuel(100));
        }

    }
}