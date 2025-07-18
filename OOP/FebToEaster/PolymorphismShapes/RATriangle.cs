using System;

namespace Shapes
{
    internal class RATriangle : Rectangle
    {
        public RATriangle(double width, double height) : base(width, height)
        {

        }

        public override double CalculateArea()
        {
            return base.CalculateArea() / 2;
        }

        public override void Draw()
        {
            double gradient = Width / Height;
            double length = Width;

            for (int line = 0; line < Height; line++)
            {
                for (int column = 0; column < Math.Ceiling(length); column++)
                {
                    Console.Write("#");
                }
                length -= gradient;
                Console.WriteLine();
            }
        }
    }
}
