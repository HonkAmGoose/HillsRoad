﻿using System;

namespace Shapes
{
    internal class Circle : Shape
    {
        public int Radius { get; protected set; }

        public Circle(int radius) : base(1)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override void Draw()
        {
            Console.WriteLine("O");
        }
    }
}
