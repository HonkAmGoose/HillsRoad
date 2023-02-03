using System;

namespace Connect4
{
    internal class Board
    {
		private int[,] board;
		
		public readonly int rows;
		public readonly int columns;

		public Board(int rows, int columns)
		{
			this.rows = rows;
			this.columns = columns;

			board = new int[columns, rows];
		}

		public string PrintBoard(ConsoleColor[] playerColours)
		{
			string value = "";
			// TODO: Check this works
			string separator = $"{"---+" * columns}---";
			string ending = // TODO: Add code to this

			/* TODO: Otherwise use this
			string separator = "--";
			string ending = "  ";
			for (int column = 0; column < columns; column++)
			{
				separator += "-+--";
				ending += $" | {column + 1}";
			}
			*/

			for (int row = 0; row < rows; row++)
			{
				Console.WriteLine($" {row + 1} |");
				for (int column = 0; column < columns; column++)
				{
					if (board[row, column] == 0)
					{
						Console.WriteLine(" . |");
					}
					else
					{
						Console.ForegroundColor = colours[board[row,column]];
						Console.WriteLine(" O ");
						Console.ResetColor();
						Console.WriteLine("|");
					}
				}
				Console.WriteLine($"\n{separator}\n");
			}
			
			// TODO: Add ending
		}

		/* Code to implement this as follows:
// prompt to enter a column
while (!AddToken())
{
	// prompt to try again
}
		*/

		public bool AddToken(int columnAttempt, Player player)
		{
			for (int row = 0; row < rows; row++)
			{
				if (board[columnAttempt, row] == 0)
				{
					board[columnAttempt, row] = player.Token;
					break;
				}
			}
		}
    }
}
