while (true)
{
    Console.WriteLine("Enter the temperature in Fahrenheit (-1000 to quit)");
    double tempF = Convert.ToDouble(Console.ReadLine());

    if (tempF == -1000.0)
    {
        break;
    }

    double tempC = (tempF - 32) / 1.8;

    Console.WriteLine($"The temperature in Celsius is {tempC}");
}