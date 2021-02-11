using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }
        public int Age
        {
            get => age;
            set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()) || value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;

            }
        }
        public string Gender
        {
            get => gender;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public virtual string GetResult()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"{this.Name} {this.Age} {this.Gender}{Environment.NewLine}");
            return stringBuilder.ToString();
        }
    }
}
