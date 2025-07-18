namespace TimesTables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a times table to generate:");
            int table = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine($"{i} x {table} = {i * table}");
            }
        }
    }
}