using System;

namespace Shapes
{
    internal class Rectangle : Shape
    {
        public double Width { get; protected set; }
        public double Height { get; protected set; }

        public Rectangle(double width, double height) : base(4)
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
            for (int line = 0; line < Math.Ceiling(Height); line++)
            {
                for (int column = 0; column < Math.Ceiling(Width); column++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
        }
    }
}
