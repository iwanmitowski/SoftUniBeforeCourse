using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        RaceEntry race;
        UnitCar car;
        UnitDriver driver;
        [SetUp]

        public void Setup()
        {
            car = new UnitCar("Mercedes", 120, 100);
            race = new RaceEntry();
            driver = new UnitDriver("Ivan", car);
        }
        [Test]
        public void ConstructorShouldWorkCorectly()
        {
            Assert.IsNotNull(race);
        }

        [Test]
        public void AddDriverCorectly()
        {
            race.AddDriver(driver);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.race.Counter);
        }

        [Test]
        public void AddDriverThrowsExceptionIfDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }

        [Test]
        public void AddDriverThrowsExceptionIfExistingDriver()
        {
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }

        [Test]
        public void CalculateAverageHorsePowerWorksCorectly()
        {
            race.AddDriver(driver);
            race.AddDriver(new UnitDriver("Gosho", new UnitCar("Opel", 80, 100)));

            int expectedValue = 100;

            Assert.AreEqual(expectedValue, race.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerThrowsExceptionIfNotEnoughDrivers()
        {
            race.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }
    }
}