using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> ints = new EqualityScale<int>(10,10);
            Console.WriteLine(ints.AreEqual());
            EqualityScale<string> strings = new EqualityScale<string>("pe", "pe");
            Console.WriteLine(ints.AreEqual());
        }
    }
}
