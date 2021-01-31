using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; 

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public int Count => cars.Count;
        public string AddCar(Car car)
        {
            if (cars.Any(c=>c.RegistrationNumber==car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (cars.Count==capacity)
            {
                return "Parking is full!";
            }
            this.cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (cars.All(c=>c.RegistrationNumber!=registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            cars = cars.Where(x => x.RegistrationNumber != registrationNumber).ToList();
            return $"Successfully removed {registrationNumber}";
        }
        public Car GetCar(string registrationNumber)
        {
            return cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string reg in registrationNumbers)
            {
                if (cars.Any(x=>x.RegistrationNumber==reg))
                {
                    cars = cars.Where(x => x.RegistrationNumber != reg).ToList() ;
                }
            }
        }

    }
}
