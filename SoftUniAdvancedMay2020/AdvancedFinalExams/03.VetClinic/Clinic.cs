using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            this.data = new List<Pet>();
        }

        public int Count => this.data.Count();
        public int Capacity { get; set; }

       
        public void Add(Pet pet)
        {
            if (Count!=Capacity)
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet searchedPet = data.FirstOrDefault(x => x.Name == name);

            if (searchedPet==null)
            {
                return false;
            }

            this.data.Remove(searchedPet);
            return true;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet searchedPet = data.FirstOrDefault(x => x.Name == name && x.Owner==owner);
            
            return searchedPet;
        }

        public Pet GetOldestPet()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in this.data)
            {
                sb.AppendLine($"{pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString();
        }
    }
}
