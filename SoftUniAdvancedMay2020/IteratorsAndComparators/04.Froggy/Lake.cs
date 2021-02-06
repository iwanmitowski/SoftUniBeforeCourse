using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] stones;
        

        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int currLenght = stones.Length-1;
            for (int i = 0; i <= currLenght; i+=2)
            {
                yield return this.stones[i];
            }

            if (currLenght%2==0)
            {
                currLenght--;
            }

            for (int i = currLenght; i >= 0; i-=2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
