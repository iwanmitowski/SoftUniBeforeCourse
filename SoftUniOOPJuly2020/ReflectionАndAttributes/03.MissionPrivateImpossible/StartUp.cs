﻿using Stealer;
using System;

namespace _03.MissionPrivateImpossible
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.RevealPrivateMethods("Stealer.Hacker");
            Console.WriteLine(result) ;

        }
    }
}
