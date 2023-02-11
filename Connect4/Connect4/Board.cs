using System;
using System.ComponentModel;

namespace Connect4
{
	internal class Board
	{
		/// <summary>
		/// The private int[,] representing the board with each element being the token of the player, -1 for empty
		/// </summary>
		private int[,] board;
		
		/// <summary>
		/// The readonly number of rows for the board
		/// </summary>
		public readonly int rows;

		/// <summary>
		/// The readonly number of columns for the board
		/// </summary>
		public readonly int columns;

		/// <summary>
		/// Constructor for the board to assign values and initialise the board with empty slots (-1s)
		/// </summary>
		/// <param name="rows">Number of rows</param>
		/// <param name="columns">Number of columns</param>
		public Board(int rows, int columns)
		{
			// Assign values
			this.rows = rows;
			this.columns = columns;

			// Initialise board with empty slots (-1s)
			board = new int[columns, rows];
			for (int column = 0; column < columns; column++)
			{
				for (int row = 0; row < rows; row++)
				{
					board[column, row] = -1;
				}
			}
		}

		/// <summary>
		/// Method to print out the board in human readable format with colours
		/// </summary>
		/// <param name="playerColours">ConsoleColor[] with player colours</param>
		public void PrintBoard(ConsoleColor[] playerColours)
		{
            Console.ResetColor();

            // Generate separator and ending strings
            string rowSeparator = "";
			string ending = "";
			for (int column = 0; column < columns; column++)
			{
				if (column != 0)
				{
					ending += "|";
					rowSeparator += "+";
				}
				rowSeparator += "---";
				ending += $" {column} ";
			}

			// Iterate through rows and columns
			for (int row = 0; row < rows; row++)
			{
				for (int column = 0; column < columns; column++)
				{
					// First element of a row doesn't need a column separator in front of it
					if (column != 0)
					{
						Console.Write("|");
					}

					if (board[column, row] == -1)
					{
						// Empty element
						Console.Write(" . ");
					}
					else
					{
						// Print token in correct colour
                        Console.ForegroundColor = playerColours[board[column, row]];
						Console.Write(" O ");
						Console.ResetColor();
					}
				}

				Console.Write($"\n{rowSeparator}\n");
			}

			Console.Write($"{ending}\n\n");
			Console.ResetColor();
		}

        /// <summary>
        /// Attempt to add token to a column
        /// </summary>
        /// <param name="columnAttempt">Column to try to place it in</param>
        /// <param name="playerToken">Player token to place</param>
        /// <returns>The row that the token was placed in or -1 if column is full</returns>
        public int AddToken(int columnAttempt, int playerToken)
		{
			// Iterate backwards up the column
			for (int row = rows - 1; row >= 0; row--)
			{
				if (board[columnAttempt, row] == -1)
				{
					// Empty so add token and return row
					board[columnAttempt, row] = playerToken;
					return row;
				}
			}

			// Column is full so return -1
			return -1;
		}

		/// <summary>
		/// Method to check for win
		/// </summary>
		/// <param name="column">Column of last token placement</param>
		/// <param name="row">Row of last token placement</param>
		/// <param name="playerToken">Player of last token</param>
		/// <returns>Whether the game has been won</returns>
		/// <exception cref="Exception">Raised if sanity check of last token placement fails</exception>
		public bool CheckForWin(int column, int row, int playerToken) // TODO: currently broken
		{
			// Sanity check the coordinate belongs to the player
			if (board[column,row] != playerToken)
			{
				throw new Exception("This should not be possible");
			}

            /*
			 * The direction corresponds to the following: 0 = N-S, 1 = NE-SW, 2 = E-W, 3 = SE-NW
			 * It is used to determine the value in the columnMod and rowMod arrays
			 * The value from the array is multiplied by the multiplier and added onto the original coordinate
			 * Note if the value in the mod array is zero, the coordinate will not be modified
			 */
            int[] columnMod = { -1, -1, 0, 1 };
			int[] rowMod = { 0, 1, 1, 1 };
			for (int direction = 0; direction < 4; direction++) 
			{
				int numInLine = 0;

				// Check in positive direction for an unbroken line, breaking when end of line
				for (int multiplier = 1; multiplier < 4; multiplier++)
				{
					int newColumn = column + columnMod[direction] * multiplier;
					int newRow = row + rowMod[direction] * multiplier;
					
					// If any of the range checks fail, it will default to else and not attempt to find the token on the board, which would throw an exception
                    if (newColumn > -1 && newColumn < columns && newRow > -1 && newRow < rows && (board[newColumn, newRow] == playerToken))
					{
						numInLine++;
					}
					else
					{
						break;
					}
				}
				// Check in negative direction as above
				for (int multiplier = -1; multiplier > -4; multiplier--)
				{
                    int newColumn = column + columnMod[direction] * multiplier;
                    int newRow = row + rowMod[direction] * multiplier;

                    // As above
                    if (newColumn > -1 && newColumn < columns && newRow > -1 && newRow < rows && (board[newColumn, newRow] == playerToken))
                    {
                        numInLine++;
                    }
                    else
                    {
                        break;
                    }
                }

				// Check for four in a row and return true if found
				if (numInLine >= 4)
				{
					return true;
				}
			}

			// If none of the directions have returned true, return false because there was no win
			return false;
		}
    }
}
