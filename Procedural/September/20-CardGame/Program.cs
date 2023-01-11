namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of cards to generate (with replacement)");
            int count = Convert.ToInt32(Console.ReadLine());

            int i, number, ranknum, suitnum;
            string rank = "";
            string suit = "";

            // "seeds" (initialises) the random number generator
            Random random = new Random();

            // big for loop to generate as many cards as required
            for (i = 0; i < count; i++)
            {
                // selects a random number between 0 and 51,
                // adds one to it and assigns the result to number
                number = random.Next(52);

                // divide 52 into ranks and suits
                ranknum = number / 4 + 1;
                suitnum = number % 4;

                // case statement for ranks
                switch (ranknum)
                {
                    case 1:
                        rank = "Ace";
                        break;
                    case 2:
                        rank = "Two";
                        break;
                    case 3:
                        rank = "Three";
                        break;
                    case 4:
                        rank = "Four";
                        break;
                    case 5:
                        rank = "Five";
                        break;
                    case 6:
                        rank = "Six";
                        break;
                    case 7:
                        rank = "Seven";
                        break;
                    case 8:
                        rank = "Eight";
                        break;
                    case 9:
                        rank = "Nine";
                        break;
                    case 10:
                        rank = "Ten";
                        break;
                    case 11:
                        rank = "Jack";
                        break;
                    case 12:
                        rank = "Queen";
                        break;
                    case 13:
                        rank = "King";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Rank must be 1-13 (number {number}, ranknum {ranknum}, suitnum {suitnum})");
                }

                // if statements for suits
                if (suitnum == 0)
                {
                    suit = "Hearts";
                }
                else if (suitnum == 1)
                {
                    suit = "Clubs";
                }
                else if (suitnum == 2)
                {
                    suit = "Diamonds";
                }
                else if (suitnum == 3)
                {
                    suit = "Spades";
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Suit must be 0-4 (number {number}, ranknum {ranknum}, suitnum {suitnum})");
                }

                // output using an interpolated string
                Console.WriteLine($"Your card is the {rank} of {suit}");
                // first alternative old format	
                // Console.WriteLine("Your card is the " + rank + " of " + suit);
                // second alternative format for the output
                // Console.WriteLine(("Your card is the {0} of {1}", rank, suit);
            }

            // wait for input to exit
            Console.ReadLine();
        }
    }
}
