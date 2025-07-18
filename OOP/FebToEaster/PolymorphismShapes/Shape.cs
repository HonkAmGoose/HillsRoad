using System;

namespace Shapes
{
    public abstract class Shape
    {
        public int NumberOfSides { get; protected set; }

        public Shape(int sides)
        {
            NumberOfSides = sides;
        }

        public abstract double CalculateArea();

        public abstract void Draw();
    }
}
