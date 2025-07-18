using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter which hershad number you want: ");
        int index = Convert.ToInt32(Console.ReadLine());

        int hershad = FindIndexedHershad(index);
        Console.WriteLine($"The {index}{GetFollowing(index)} hershad number is {hershad}");
    }
    public static int FindIndexedHershad(int index)
    {
        int current = 0;
        for (int i = 1; i <= index; i++)
        {
            current = FindNextHershad(current);
            //Console.WriteLine(current);
        }
        return current;
    }
    public static int FindNextHershad(int current)
    {
        do
        {
            current += 1;
        } while (!IsHershad(current));
        return current;
    }
    public static bool IsHershad(int number)
    {
        return number % GetDigitSum(number) == 0;
    }
    public static int GetDigitSum(int number)
    {
        int sum = 0;
        do
        {
            sum += number % 10;
            number /= 10;
        } while (number > 0);
        return sum;
    }
    public static string GetFollowing(int number)
    {
        if (number % 100 / 10 == 1)
        {
            return "th";
        }

        number %= 10;
        string follower;
        switch (number)
        {
            case 1:
                follower = "st";
                break;
            case 2:
                follower = "nd";
                break;
            case 3:
                follower = "rd";
                break;
            default:
                follower = "th";
                break;
        }
        return follower;
    }
}