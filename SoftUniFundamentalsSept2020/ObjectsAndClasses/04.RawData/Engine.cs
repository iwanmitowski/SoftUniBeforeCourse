using System;
using System.Collections.Generic;
using System.Text;

namespace _04.RawData
{
    class Engine
    {
        public Engine(Car car)
        {
            EngineSpeed = car.EngineSpeed;
            EnginePower = car.EnginePower;
        }

        public int EngineSpeed { get; set; }
        public int EnginePower {get; set; }
    }
}
