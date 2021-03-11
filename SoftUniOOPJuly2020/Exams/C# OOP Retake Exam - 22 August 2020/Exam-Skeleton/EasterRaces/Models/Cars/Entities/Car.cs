using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    abstract class Car : ICar
    {
        private const int RequiredSymbols = 4;

        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;
        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
            
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < RequiredSymbols)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel,value, RequiredSymbols));
                }
                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            private set
            {
                if (value >= this.minHorsePower && value <= this.maxHorsePower)
                {
                    this.horsePower = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower,value));
                }
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.horsePower * laps;
        }
    }
}
