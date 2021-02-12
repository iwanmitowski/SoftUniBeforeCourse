using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (ValidateName(value))
                {
                    this.firstName = value;
                }
                else
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (ValidateName(value))
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value>0)
                {
                    this.age = value;

                }
                else
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
            }
        }
        public decimal Salary {
            get
            {
                return this.salary;
            }

            private set
            {
                if (value<460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");

                }
                this.salary = value;
            }

        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age >= 30)
            {
                this.Salary += (this.Salary * percentage) / 100;

            }
            else
            {
                this.Salary += (this.Salary * percentage) / 200;

            }

        }
        //public override string ToString()
        //{
        //    return $"{this.FirstName} receives {this.Salary:f2} leva.";
        //}

        private bool ValidateName(string name)
        {
            if (name.Length > 2)
            {
                return true;
            }
            return false;
        }
    }
}
