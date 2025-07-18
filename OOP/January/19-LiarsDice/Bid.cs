using System;

namespace LiarsDice
{
    internal class Bid
    {
        private int roll;
        private int num;
        private static string[] unitsArr = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static string[] tensArr = { "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        public Bid(int roll, int num)
        {
            this.roll = roll;
            this.num = num;
        }

        public Bid()
        {
            this.roll = 1;
            this.num = 1;
        }

        public int GetRoll()
        {
            return this.roll;
        }

        public int GetNum()
        {
            if (num < 20)
            {
                return unitsArr[num - 1];
            }
            else
            {
                int tens = num / 10;
                int units = num % 10;
                return $"{tensArr[tens - 2] -{unitsArr[units - 1]}";
            }
        }
        }
    }