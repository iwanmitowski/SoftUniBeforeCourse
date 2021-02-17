using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Rectangle : IDrawable
    {
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public void Draw()
        {
            DrawLine('*', '*');
            Console.WriteLine();
            for (int i = 0; i < this.Height - 2; ++i)
            {
                DrawLine('*', ' ');
                Console.WriteLine();
            }
            DrawLine('*', '*');
        }
        public void DrawLine(char first, char second)
        {
            Console.Write(first);
            for (int i = 0; i < this.Width - 2; i++)
            {
                Console.Write(second);
            }
            Console.Write(first);
        }
    }
}
