namespace Circle
{
    internal class Program
    {

        /* Program to calculate the circumference of a circle
        when the radius is known.
        NB.This program will not compile - you need to correct the errors */
        static void Main(string[] args)
        {
            const double PI = 3.14159;
            int radius;
            double diam;
            double circ;
            Console.WriteLine("Program to calculate the circumference of a circle");
            Console.Write("Enter circle radius: ");
            radius = Convert.ToInt32(Console.ReadLine());
            diam = radius * 2;
            circ = PI * diam;
            Console.WriteLine("The circumference of the circle = " + circ.ToString());
            Console.ReadLine();
        }

    }
}
