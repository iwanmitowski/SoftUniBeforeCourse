using EasterRaces.Core.Contracts;
using EasterRaces.Core.Factories;
using EasterRaces.Core.Factories.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    class ChampionshipController : IChampionshipController
    {
        private const int RequiredParticipants = 3;

        private readonly CarRepository carRepository;
        private readonly DriverRepository driverRepository;
        private readonly RaceRepository raceRepository;

        private readonly ICarFactory carFactory;
        private readonly IDriverFactory driverFactory;
        private readonly IRaceFactory raceFactory;
        public ChampionshipController()
        {
            this.carFactory = new CarFactory();
            this.driverFactory = new DriverFactory();
            this.raceFactory = new RaceFactory();

            this.carRepository = new CarRepository();
            this.driverRepository = new DriverRepository();
            this.raceRepository = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = this.driverRepository.GetByName(driverName);
            var car = this.carRepository.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var driver = this.driverRepository.GetByName(driverName);
            var race = this.raceRepository.GetByName(raceName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.carRepository.GetAll().Any(x => x.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            var car = this.carFactory.CreateCar(type, model, horsePower);
            this.carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            if (this.driverRepository.GetAll().Any(x => x.Name == driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            var driver = this.driverFactory.CreateDriver(driverName);
            this.driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetAll().Any(x => x.Name == name && x.Laps==laps))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RaceExists, name));
            }

            var race = this.raceFactory.CreateRace(name, laps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            List<IDriver> drivers = driverRepository.GetAll().ToList();

            if (drivers.Count < RequiredParticipants)
            {
                throw new InvalidCastException(string.Format(ExceptionMessages.RaceInvalid, raceName, RequiredParticipants));
            }

            var sortedDrivers = drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();

            drivers.First().WinRace();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, sortedDrivers[0].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, sortedDrivers[1].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, sortedDrivers[2].Name, race.Name));

            raceRepository.Remove(race);

            return sb.ToString().Trim();
        }
    }
}
