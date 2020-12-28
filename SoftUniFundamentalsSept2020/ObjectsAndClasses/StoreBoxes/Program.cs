using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    class Program
    {
        private static object box;

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<Box> boxes = new List<Box>();

            while (input[0]!="end")
            {
                int serialNumber = int.Parse(input[0]);
                string itemName = input[1];
                int itemQuantity = int.Parse(input[2]);
                decimal itemPrice = decimal.Parse(input[3]);

                Box box = new Box();
                box.Item = new Item();

                box.SerialNumber = serialNumber;
                box.Item.Name = itemName;
                box.ItemQuantity = itemQuantity;
                box.Item.Price = itemPrice;
                box.PriceForBox = box.ItemQuantity * box.Item.Price;
                boxes.Add(box);


                

                input = Console.ReadLine().Split();
            }

            List<Box> sortedBoxes = new List<Box>( boxes.OrderByDescending(x=> x.PriceForBox));

            foreach (Box box in sortedBoxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} – ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForBox:f2}");
            }
        }
    }
}
