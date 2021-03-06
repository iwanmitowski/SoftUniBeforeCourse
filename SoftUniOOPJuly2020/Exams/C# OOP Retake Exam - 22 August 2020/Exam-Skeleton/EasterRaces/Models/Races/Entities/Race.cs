﻿using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Utilities.Messages;
using System.Linq;

namespace EasterRaces.Models.Races.Entities
{
    class Race : IRace
    {
        private const int RequiredSymbols = 5;
        private const int RequiredLaps = 1;
        private string name;
        private int laps;
        private readonly List<IDriver> drivers;
        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < RequiredSymbols)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, RequiredSymbols));

                }
                this.name = value;
            }
        }

        public int Laps
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, RequiredLaps));
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver==null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }
            if (driver.Car==null||driver.CanParticipate==false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            if (this.drivers.Contains(driver))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }
            this.drivers.Add(driver);
        }
    }
}
