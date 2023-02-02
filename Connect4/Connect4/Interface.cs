using System;

namespace Connect4
{
    internal class Interface
    {
        public int DisplayMenu(string before, string prompt, string after)
        {
            Console.WriteLine(before);
            Console.WriteLine(prompt);
            Console.WriteLine(after);
        }
    }
}
