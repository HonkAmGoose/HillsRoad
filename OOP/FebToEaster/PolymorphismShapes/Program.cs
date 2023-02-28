using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] myShapes = new Shape[3];
            myShapes[0] = new Circle(2);
            myShapes[1] = new Square(2);
            myShapes[2] = new Rectangle(3, 2);

            foreach (var shape in myShapes)
            {
                Console.WriteLine(shape.GetType());
                Console.WriteLine($"Area: {shape.CalculateArea()}");
                shape.Draw();
                Console.WriteLine();
            }
        }
    }
}
