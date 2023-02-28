using System;

namespace Shapes
{
    internal class Rectangle : Shape
    {
        public double Width { get; protected set; }
        public double Height { get; protected set; }

        public Rectangle(int width, int height) : base(4)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override void Draw()
        {
            for (int line = 0; line < Height; line++)
            {
                for (int column = 0; column < Width; column++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
        }
    }
}
