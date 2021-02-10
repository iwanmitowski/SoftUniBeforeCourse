using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    class RandomList : List<string>
    {
        private Random rnd;
        
        public RandomList()
        {
            rnd = new Random();
            
        }
        public string RandomString()
        {
            string result = string.Empty;
            try
            {
                int index = rnd.Next(0, this.Count);
                result = this[index];
                this.RemoveAt(index);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return result;

        }
    }
}
