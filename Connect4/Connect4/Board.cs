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

		public string PrettifyBoard()
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
				value += $" {row + 1} |";
				for (int column = 0; column < columns; column++)
				{
					value + " {board[row,col]} |";
				}
				value += $"\n{separator}\n";
			}
			
			value += ending
			return value;
		}

		/* Code to implement this as follows:
while (!AddToken())
{
	// prompt to try again
}
		*/
		public bool AddToken(int columnAttempt, Player player)
		{

		}
    }
}
