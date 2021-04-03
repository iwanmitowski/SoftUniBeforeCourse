using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Drivers.Entities
{
    class Driver : IDriver
    {
        private const int RequiredSymbols = 5;
        private string name;

        public Driver(string name)
        {
            Name = name;
            this.NumberOfWins = 0;
            this.CanParticipate = false;

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)|| value.Length < RequiredSymbols)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, RequiredSymbols));

                }
                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }

        public void AddCar(ICar car)
        {
            if (car==null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }
            this.Car = car;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
