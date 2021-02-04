using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStringOrDouble
{
    public class Boxes<T> where T : IComparable
    {
        List<Box<T>> boxes;
        public Boxes()
        {
            this.boxes = new List<Box<T>>();

        }

        public void AddBox(Box<T> box)
        {
            this.boxes.Add(box);
        }

        public void Swap(int first, int second)
        {
            Box<T> temp = this.boxes[first];
            this.boxes[first] = boxes[second];
            this.boxes[second] = temp;
        }

        public int Count(Box<T> box)
        {
            int count = 0;
            foreach (var item in this.boxes)
            {
                if (box.IsLower(item))
                {
                    count++;
                }

            }
            return count;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Box<T> box in this.boxes)
            {
                sb.AppendLine(box.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
