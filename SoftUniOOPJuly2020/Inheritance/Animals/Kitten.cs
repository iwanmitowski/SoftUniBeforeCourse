using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Kitten : Cat
    {
        private const string kittensGender = "Female";

        public Kitten(string name, int age) : base(name, age, kittensGender)
        {
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
        public override string GetResult()
        {
            return base.GetResult() + ProduceSound();
        }
    }
}
