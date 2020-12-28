using System;
using System.Collections.Generic;
using System.Linq;

namespace ListExercisesW3resource
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://www.w3resource.com/csharp-exercises/basic-algo/index.php
            //141.

            List<int> nums = new List<int> { 1, 2, 3, 4 };
            List<int> result = nums.Select(x => x *= 3);
        }
    }
}
