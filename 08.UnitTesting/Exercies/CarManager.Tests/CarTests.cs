using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new CarManager.Car("WV", "Passat", 1.4, 100));
        }

        [Test]
        public void CarMakeIsSetProperly()
        {

            CarManager.Car car = new CarManager.Car("WV", "Passat", 1.4, 100);
            Assert.AreEqual("WV", car.Make);
        }

        [Test]
        public void CarModelIsSetPorperly()
        {
            CarManager.Car car = new CarManager.Car("WV", "Passat", 1.4, 100);
            Assert.AreEqual("Passat", car.Model);

        }

        [Test]
        public void StartingFuelMustBeZero()
        {
            CarManager.Car car = new CarManager.Car("WV", "Passat", 1.4, 100);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void FuelCapacityCantBeZeroOrNegative(double Capacity)
        {
            Assert.Throws<ArgumentException>(() => new CarManager.Car("WV", "Passat", 1.4, Capacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void FuelConsumptionCantBeZeroOrNegative(double Consumption)
        {
            Assert.Throws<ArgumentException>(() => new CarManager.Car("WV", "Passat", Consumption, 100));
        }


        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void MakeCantBeNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new CarManager.Car(make, "Passat", 1.2, 100));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ModelCantBeNullOrEmpty(string Model)
        {
            Assert.Throws<ArgumentException>(() => new CarManager.Car("WV", Model, 1.2, 100));
        }

        [Test]
        [TestCase(1)]
        [TestCase(20)]
        [TestCase(100)]
        public void CanCanRefilIfThereIsEnoughSpace(double fuel)
        {
            CarManager.Car car = new CarManager.Car("WV", "Passat", 1.4, 100);
            car.Refuel(fuel);

            Assert.AreEqual(fuel, car.FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void CantRefilZeroOrNagativeAountOfFuel(double fuel)
        {
            CarManager.Car car = new CarManager.Car("WV", "Passat", 1.4, 100);
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        [TestCase(101)]
        [TestCase(200)]
        public void CantRefillOverFulelCapacity(double fuel)
        {
            CarManager.Car car = new CarManager.Car("WV", "Passat", 1.4, 100);
            car.Refuel(fuel);

            Assert.AreEqual(100, car.FuelCapacity);
        }

        [Test]
        [TestCase(2)]
        [TestCase(20)]
        public void CarCanDriveIFTheFuelIsEnough(double distance)
        {
            CarManager.Car car = new CarManager.Car("WV", "Passat", 1.4, 100);
            car.Refuel(30);
            Assert.DoesNotThrow(() => car.Drive(distance));
        }

        [Test]
        [TestCase(200)]
        [TestCase(20)]
        public void CarCantDriveWithoutEnoughFuel(double distance)
        {
            CarManager.Car car = new CarManager.Car("WV", "Passat", 10, 100);
            car.Refuel(1);
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }
    }
}