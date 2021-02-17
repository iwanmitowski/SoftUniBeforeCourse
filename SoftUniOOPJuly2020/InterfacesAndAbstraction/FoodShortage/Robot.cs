using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    class Robot : IIdentible
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }
        public string Id { get; private set; }
    }
}
