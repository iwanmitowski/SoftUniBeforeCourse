using EasterRaces.Core.Contracts;
using EasterRaces.Core.Factories;
using EasterRaces.Core.Factories.Contracts;
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

        }
        public ChampionshipController(
            CarRepository carRepository,
            DriverRepository driverRepository,
            RaceRepository raceRepository,
            ICarFactory carFactory,
            IDriverFactory driverFactory,
            IRaceFactory raceFactory)
        {
            this.carRepository = carRepository;
            this.driverRepository = driverRepository;
            this.raceRepository = raceRepository;

            this.carFactory = carFactory;
            this.driverFactory = driverFactory;
            this.raceFactory = raceFactory;
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
            var race = this.raceRepository.GetByName(raceName);
            var driver = this.driverRepository.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
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
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            var race = this.raceFactory.CreateRace(name, laps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetByName(raceName);

            if (race==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var drivers = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).ToList();

            if (drivers.Count< RequiredParticipants)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid,race.Name,RequiredParticipants));
            }

            StringBuilder sb = new StringBuilder();

            drivers.First().WinRace();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, drivers[0].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, drivers[1].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, drivers[2].Name, race.Name));


            return sb.ToString();

        }
    }
}
