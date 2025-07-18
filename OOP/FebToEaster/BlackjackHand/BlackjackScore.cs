using System;

namespace HandClasses
{
    internal class BlackjackScore
    {
        public int Number;
        public string Type;

        public BlackjackScore(int number, string type)
        {
            Number = number;
            Type = type;
        }

        public BlackjackScore()
        {
            Number = 0;
            Type = "";
        }
    }
}
