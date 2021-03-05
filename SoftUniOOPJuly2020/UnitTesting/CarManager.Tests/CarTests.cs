using NUnit.Framework;
using CarManager;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Mercedes", "c180", 7.5, 50);
        }

        [Test]
        public void CarShouldBeSetUpCorect()
        {

            string expectedMake = "Mercedes";
            string expectedModel = "c180";
            double expectedFuelConsumption = 7.5;
            double expectedFuelCapacity = 50;

            Assert.That(expectedMake, Is.EqualTo(car.Make));
            Assert.That(expectedModel, Is.EqualTo(car.Model));
            Assert.That(expectedFuelConsumption, Is.EqualTo(car.FuelConsumption));
            Assert.That(expectedFuelCapacity, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void CarShouldBeCreatedWith0Fuel()
        {
            Assert.That(this.car.FuelAmount, Is.EqualTo(0));
        }

        [TestCase(null)]
        [TestCase("")]
        public void IfMakeIsNullThrowException(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "c180", 7.5, 50));
        }

        [TestCase(null)]
        [TestCase("")]
        public void IfModelIsNullThrowException(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", model, 7.5, 50));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void IfFuelConsumptionlIsZeroORLessThrowException(double fc)
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", "c180", fc, 50));
        }
        [TestCase(0)]
        [TestCase(-1)]
        public void IfFuelCapacitylIsZeroORLessThrowException(double fc)
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", "c180", 7.5, fc));
        }

        [Test]
        public void IfFuelAmountIsNegativeThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(100));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void IfRefuelIsZeroORLessThrowException(double fuelAmount)
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(fuelAmount));
        }

        [Test]
        public void CarShouldIncreaseFuelAmount()
        {
            this.car.Refuel(10);
            double expectedFuel = 10;

            Assert.That(this.car.FuelAmount, Is.EqualTo(expectedFuel));
        }

        [Test]
        public void RefuelShouldBeNotMoreThanCapacity()
        {
            this.car.Refuel(60);
            double expectedFuelAmount = 50;

            Assert.That(this.car.FuelAmount, Is.EqualTo(expectedFuelAmount));

        }

        [Test]
        public void DrivingShouldDecreaseFuelAmount()
        {
            this.car.Refuel(10);
            this.car.Drive(10);
            double expectedFuelAmount = 9.25;

            Assert.That(this.car.FuelAmount, Is.EqualTo(expectedFuelAmount));
        }

    }
}