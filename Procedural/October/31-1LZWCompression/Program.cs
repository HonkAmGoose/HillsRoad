using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZWCompression
{
    class Program
    {
        // uses 16-bit unsigned integers
        //NB better compression could be achieved by using smaller integers
        // eg 12-bit or 14-bit.

        const ushort DICTMAX = 65535; //max dictionary size cannot exceed number of 16-bit integers

        static void LZWDemo(string s)
        // compresses s using LZW: displays workings including dictionary entries and
        // final list of integers
        {
            Dictionary<string, ushort> dict = new Dictionary<string, ushort>();

            // initialise dictionary with ASCII chars 0-255:
            for (ushort n = 0; n <= 255; n++)
            {
                dict.Add(Convert.ToChar(n).ToString(), n);
            }

            ushort dictLength = 256;
            StringBuilder current = new StringBuilder();
            StringBuilder result = new StringBuilder();
            ushort j;
            ushort i;
            int lineCount = 0;
            Console.WriteLine("These are the new entries in the dictionary:");
            foreach (char ch in s)
            {
                // lookup (current string + next char in s)  in Dictionary
                if (dict.ContainsKey(current.ToString() + ch))
                {
                    // append ch to current and go round again,
                    // trying to match one more character
                    current.Append(ch);
                }
                else // not found
                {
                    // append the position of the longest matching entry to the result,
                    // formatted to look pretty
                    dict.TryGetValue(current.ToString(), out i);
                    result.Append(i.ToString() + ":" + current.ToString());
                    result.AppendLine();
                    lineCount++;
                    if (dictLength < DICTMAX - 1) // if the dictionary is not full                     
                    {
                        // add a new entry for the string that failed to match
                        dict.Add(current.ToString() + ch, dictLength);
                        Console.WriteLine("Entry " + dictLength + ": " + current.ToString() + ch);
                        dictLength++;
                    }
                    // reset current to the character that failed to match
                    current.Clear();
                    current.Append(ch);
                }
            }
            // add final string to result
            dict.TryGetValue(current.ToString(), out j);
            result.Append(j.ToString() + ":" + current.ToString());// + Convert.ToString(10) + Convert.ToString(13));
            result.AppendLine();
            Console.WriteLine("Here are the codes and corresponding entries:");
            Console.WriteLine(result);
            Console.WriteLine("Your original text of " + s.Length + " characters has been compressed to " + (lineCount + 1) + " 16-bit integer codes");
        }

        static List<ushort> LZW(string s)
        //compresses s using LZW: returns a list of ushort
        {
            Dictionary<string, ushort> dict = new Dictionary<string, ushort>();
            // initialise dictionary with ASCII chars 0-255:
            for (ushort n = 0; n <= 255; n++)
            {
                dict.Add(Convert.ToChar(n).ToString(), n);
            }
            ushort dictLength = 256;
            StringBuilder current = new StringBuilder();
            List<ushort> result = new List<ushort>();
            ushort j;
            ushort i;
            foreach (char ch in s)
            {
                // lookup (current string + next char in s)  in Dictionary
                if (dict.ContainsKey(current.ToString() + ch))
                {
                    // append ch to current and go round again,
                    // trying to match one more character
                    current.Append(ch);
                }
                else // not found
                {
                    // append the position of the longest matching entry to the result,
                    dict.TryGetValue(current.ToString(), out i);
                    result.Add(i);
                    if (dictLength < DICTMAX - 1) // if the dictionary is not full                     
                    {
                        // add a new entry for the string that failed to match
                        dict.Add(current.ToString() + ch, dictLength);
                        dictLength++;
                    }
                    // reset current to the character that failed to match
                    current.Clear();
                    current.Append(ch);
                }
            }
            // add final string to result
            dict.TryGetValue(current.ToString(), out j);
            result.Add(j);
            return result;
        }

        static string DeLZW(List<ushort> LZWList)
        //decompresses list of ushort
        {
            string[] dict = new string[DICTMAX];
            //array is fine here because no need to lookup strings
            char ch;
            string entry;
            ushort dictLength = 256;
            StringBuilder result = new StringBuilder();

            // initialise dictionary with ASCII chars 0-255:
            for (ushort n = 0; n <= 255; n++)
            {
                dict[n] = (Convert.ToChar(n).ToString());
            }

            ushort prevCode = LZWList[0];
            result.Append(dict[prevCode]);
            string lastEntry = result.ToString();
            for (int i = 1; i < LZWList.Count; i++)
            {
                ushort currentCode = LZWList[i];

                if (currentCode < dictLength)
                {
                    entry = dict[currentCode];
                }
                else
                {
                    entry = lastEntry + lastEntry[0];
                }
                result.Append(entry);
                ch = entry[0];
                if (dictLength < DICTMAX)
                {
                    dict[dictLength] = dict[prevCode] + ch;
                    dictLength++;
                }
                prevCode = currentCode;
                lastEntry = entry;
            }
            return result.ToString();

        }

        static void TextToLZWFile(string fileName)
        {
            string contents = File.ReadAllText(fileName);
            List<ushort> LZWList = LZW(contents);
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName + ".lzw", FileMode.Create)))
            {
                foreach (ushort code in LZWList)
                {
                    writer.Write(code);
                }
            }
        }



        static void LZWFileToText(string fileName)
        {
            List<ushort> codeList = new List<ushort>();
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length) //loop through whole file
                {
                    codeList.Add(reader.ReadUInt16());
                }
            }
            string decompressed = DeLZW(codeList);
            File.WriteAllText(fileName + ".txt", decompressed);
        }

        static int Menu()
        {
            Console.WriteLine("This program demonstrates the LZW compression algorithm");
            Console.WriteLine("1. Demonstration of how the dictionary is built and used");
            Console.WriteLine("2. Compress a text file");
            Console.WriteLine("3. Decompress a text file");
            Console.WriteLine("4. Exit");
            int choice;
            do
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            while ((choice < 1) || (choice > 4));
            return choice;
        }
        static void Main(string[] args)
        {
            int choice = 0;
            while (choice != 4)
            {
                choice = Menu();
                if (choice == 1)
                {
                    Console.WriteLine("Enter text to compress: ");
                    string s = Console.ReadLine();
                    LZWDemo(s);
                }

                if (choice == 2)
                {
                    string fileName = string.Empty;
                    do
                    {
                        Console.WriteLine("Enter full name of file to be compressed (include .txt extension): ");
                        fileName = Console.ReadLine();
                    }
                    while (!File.Exists(fileName));
                    TextToLZWFile(fileName);
                    Console.WriteLine("Check to see how much the file size has decreased.");
                    Console.WriteLine("The compressed file has an extra .lzw extension");
                }

                if (choice == 3)
                {
                    Console.WriteLine("Enter full name of file to be compressed (include .txt.lzw extension): ");
                    string fileName = Console.ReadLine();
                    LZWFileToText(fileName);
                    Console.WriteLine("The original file has been restored with an extra .txt extension");
                }
            }

        }
    }
}
