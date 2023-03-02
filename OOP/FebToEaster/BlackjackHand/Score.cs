using System;

namespace HandClasses
{
    internal class Score
    {
        public int Number;
        public string Type;

        public Score(int number, string type)
        {
            Number = number;
            Type = type;
        }

        public Score()
        {
            Number = 0;
            Type = "";
        }
    }
}
