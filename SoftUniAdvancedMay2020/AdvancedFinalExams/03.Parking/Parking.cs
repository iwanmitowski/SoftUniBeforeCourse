using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            this.data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count => this.data.Count;
        public void Add(Car car)
        {
            if (Count<Capacity)
            {
                this.data.Add(car);

            }
           
        }

        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = this.data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (carToRemove==null)
            {
                return false;
            }
            this.data.Remove(carToRemove);
            return true;
        }

        public Car GetLatestCar()
        {
            if (Count==0)
            {
                return null;
            }
            return this.data.OrderByDescending(x => x.Year).First();
        }

        public Car GetCar(string manufacturer, string model)
        {
            if (Count == 0)
            {
                return null;
            }
            return this.data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (Car car in data)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
