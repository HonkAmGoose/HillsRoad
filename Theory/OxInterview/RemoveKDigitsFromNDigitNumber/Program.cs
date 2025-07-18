using System;

namespace RemoveKDigitsFromNDigitNumber
{
    static class Program
    {
        static void Main(string[] args)
        {
            Test(BruteForce);
            Test(LookAtSections);
            Test(DiscardDecrease);
        }

        public static void Test(Func<List<int>, int, List<int>> function)
        {
            int[][] testSuite = new int[][]
            {
                new int[] { 50719, 2, 719 },
                new int[] { 70519, 2, 759 },
                new int[] { 7016499, 3, 7699 },
                new int[] { 7016499, 4, 799 },
                new int[] { 7016433, 3, 7643},
            };

            bool works = true;
            int actual;
            bool result;
            foreach (int[] test in testSuite)
            {
                actual =  ConvertListToInt(function(ConvertIntToList(test[0]), test[1]));
                result = actual == test[2];
                Console.WriteLine($"Test function {function.Method.Name}:\tn = {test[0]},\tk = {test[1]},\texpects {test[2]},\tgot {actual},\tresult = {(result ? "    pass     " : "****FAIL****")}");
                works &= result;
            }
        }

        public static int ConvertListToInt(List<int> n)
        {
            int length = n.Count;
            int value = 0;
            for (int i = 0; i < length; i++)
            {
                value += n[length - i - 1] * Convert.ToInt32(Math.Pow(10, i));
            }
            return value;
        }

        public static List<int> ConvertIntToList(int value)
        {
            List<int> n = new List<int>();
            int length = Convert.ToInt32(Math.Log10(value));
            int pow10, ival;
            for (int i = 0; i < length; i++)
            {
                pow10 = Convert.ToInt32(Math.Pow(10, length - i - 1));
                ival = value / pow10;
                n.Add(ival);
                value -= pow10 * ival;
            }
            return n;
        }

        public static List<int> BruteForce(List<int> n, int k)
        {
            return ConvertIntToList(BruteForce(n, k, 0));
        }

        public static int BruteForce(List<int> n, int k, int max)
        {
            if (k > 0)
            {
                List<int> tmp = new List<int>();
                for (int i = 0; i < n.Count; i++)
                {
                    tmp = n.ToArray().ToList();
                    tmp.RemoveAt(i);
                    max = BruteForce(tmp, k - 1, max);
                }
                return max;
            }
            else
            {
                return Math.Max(max, ConvertListToInt(n));
            }
        }

        public static List<int> LookAtSections(List<int> n, int k)
        {
            int max, diff;
            for (int i = 0; i < n.Count - k; i++)
            {
                max = n.IndexOf(n.GetRange(i, k + 1).Max());
                diff = max - i;

                if (diff > 0)
                {
                    n.RemoveRange(i, diff);
                    return LookAtSections(n, k - diff);
                }
            }
            n.RemoveRange(n.Count - k, k);
            return n;
        }

        public static List<int> DiscardDecrease(List<int> n, int k)
        {
            int keep = n.Count - k;

            for (int i = 1; i < n.Count; i++)
            {
                if (n[i - 1] < n[i])
                {
                    n.Remove(i - 1); 
                }
            }

            return n;
        }
    }
}