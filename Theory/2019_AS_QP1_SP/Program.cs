// Skeleton Program for the AQA A1 Summer 2019 examination
// this code should be used in conjunction with the Preliminary Material
// written by the AQA AS1 Programmer Team
// developed in Visual Studio 2017

// Version number: 0.0.3

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BoardGameCS
{
    class Program
    {
        const string Space = "     ";
        const string Unused = "XXXXX";
        const int BoardSize = 8;
        const int NumberOfPieces = 12;
        const int MaxMoves = 50;
        const int Row = 0;
        const int Column = 1;
        const int Dame = 2;

        struct MoveRecord
        {
            public string Piece;
            public int NewRow;
            public int NewColumn;
            public bool CanJump;
        }

        private static void LoadPieces(StreamReader fileHandle, int[,] playersPieces)
        {
            for (int index = 0; index < NumberOfPieces + 1; index++)
            {
                playersPieces[index, Row] = Convert.ToInt32(fileHandle.ReadLine());
                playersPieces[index, Column] = Convert.ToInt32(fileHandle.ReadLine());
                playersPieces[index, Dame] = Convert.ToInt32(fileHandle.ReadLine());
            }
        }

        private static void CreateNewBoard(string[,] board)
        {
            for (int thisRow = 0; thisRow < BoardSize; thisRow++)
            {
                for (int thisColumn = 0; thisColumn < BoardSize; thisColumn++)
                {
                    if ((thisRow + thisColumn) % 2 == 0)
                    {
                        board[thisRow, thisColumn] = Unused;
                    }
                    else
                    {
                        board[thisRow, thisColumn] = Space;
                    }
                }
            }
        }

        private static void AddPlayerA(string[,] board, int[,] a)
        {
            int pieceRow, pieceColumn, pieceDame;
            for (int index = 1; index < NumberOfPieces + 1; index++)
            {
                pieceRow = a[index, Row];
                pieceColumn = a[index, Column];
                pieceDame = a[index, Dame];
                if (pieceRow > -1)
                {
                    if (pieceDame == 1)
                    {
                        board[pieceRow, pieceColumn] = "A" + index;
                    }
                    else
                    {
                        board[pieceRow, pieceColumn] = "a" + index;
                    }
                }
            }
        }

        private static void AddPlayerB(string[,] board, int[,] b)
        {
            int pieceRow, pieceColumn, pieceDame;
            for (int index = 1; index < NumberOfPieces + 1; index++)
            {
                pieceRow = b[index, Row];
                pieceColumn = b[index, Column];
                pieceDame = b[index, Dame];
                if (pieceRow > -1)
                {
                    if (pieceDame == 1)
                    {
                        board[pieceRow, pieceColumn] = "B" + index;
                    }
                    else
                    {
                        board[pieceRow, pieceColumn] = "b" + index;
                    }
                }
            }
        }

        private static void DisplayErrorCode(int errorNumber)
        {
            Console.WriteLine("Error " + errorNumber);
        }

        private static void SetUpBoard(string[,] board, int[,] a, int[,] b, ref bool fileFound)
        {
            string fileName = "game1.txt";
            Console.Write("Do you want to load a saved game? (Y/N): ");
            string answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                Console.Write("Enter the filename: ");
                fileName = Console.ReadLine();
            }
            try
            {
                StreamReader filehandle = new StreamReader(fileName);
                fileFound = true;
                LoadPieces(filehandle, a);
                LoadPieces(filehandle, b);
                filehandle.Close();
                CreateNewBoard(board);
                AddPlayerA(board, a);
                AddPlayerB(board, b);
            }
            catch (Exception)
            {
                DisplayErrorCode(4);
            }

        }

        private static void PrintHeading()
        {
            Console.Write("    ");
            for (int boardColumn = 0; boardColumn < BoardSize; boardColumn++)
            {
                Console.Write("{0,3}{1}", boardColumn, "   ");
            }
            Console.WriteLine();
        }

        private static void PrintRow(string[,] board, int thisRow)
        {
            Console.Write("   |");
            for (int boardColumn = 0; boardColumn < BoardSize; boardColumn++)
            {
                if (board[thisRow, boardColumn] == Unused)
                {
                    Console.Write(board[thisRow, boardColumn] + "|");
                }
                else
                {
                    Console.Write(Space + "|"); ;
                }
            }
            Console.WriteLine();
        }

        private static void PrintMiddleRow(string[,] board, int thisRow)
        {
            Console.Write("{0,2}{1}", thisRow, " |");
            for (int boardColumn = 0; boardColumn < BoardSize; boardColumn++)
            {
                if (board[thisRow, boardColumn] == Unused || board[thisRow, boardColumn] == Space)
                {
                    Console.Write(board[thisRow, boardColumn] + "|");
                }
                else
                {
                    Console.Write("{0,4}{1}", board[thisRow, boardColumn], " |");
                }
            }
            Console.WriteLine();
        }

        private static void PrintLine()
        {
            Console.Write("   ");
            for (int boardColumn = 0; boardColumn < BoardSize; boardColumn++)
            {
                Console.Write("------");
            }
            Console.WriteLine("-");
        }

        private static void DisplayBoard(string[,] board)
        {
            PrintHeading();
            PrintLine();
            for (int thisRow = 0; thisRow < BoardSize; thisRow++)
            {
                PrintRow(board, thisRow);
                PrintMiddleRow(board, thisRow);
                PrintRow(board, thisRow);
                PrintLine();
            }
        }

        private static void PrintPlayerPieces(int[,] a, int[,] b)
        {
            Console.WriteLine();
            Console.WriteLine("Player A:");
            Console.Write("[");
            for (int index = 0; index < NumberOfPieces; index++)
            {
                Console.Write("[" + a[index, Row] + ", " + a[index, Column] + ", " + a[index, Dame] + "], ");
            }
            Console.WriteLine("[" + a[NumberOfPieces, Row] + ", " + a[NumberOfPieces, Column] + ", " + a[NumberOfPieces, Dame] + "]]");
            Console.WriteLine("Player B:");
            Console.Write("[");
            for (int index = 0; index < NumberOfPieces; index++)
            {
                Console.Write("[" + b[index, Row] + ", " + b[index, Column] + ", " + b[index, Dame] + "], ");
            }
            Console.WriteLine("[" + b[NumberOfPieces, Row] + ", " + b[NumberOfPieces, Column] + ", " + b[NumberOfPieces, Dame] + "]]");
            Console.WriteLine();
        }

        private static void ClearList(MoveRecord[] listOfMoves)
        {
            for (int index = 0; index < MaxMoves; index++)
            {
                listOfMoves[index].Piece = "";
                listOfMoves[index].NewRow = -1;
                listOfMoves[index].NewColumn = -1;
                listOfMoves[index].CanJump = false;
            }
        }

        private static bool ValidMove(string[,] board, int newRow, int newColumn)
        {
            bool valid = false;
            if (newRow >= 0 && newRow < BoardSize &&
                newColumn >= 0 && newColumn < BoardSize)
            {
                if (board[newRow, newColumn] == Space)
                {
                    valid = true;
                }
            }
            return valid;
        }

        private static bool ValidJump(string[,] board, int[,] playersPieces, string piece, int newRow, int newColumn)
        {
            bool valid = false;
            string middlePiece = "";
            string player, oppositePiecePlayer, middlePiecePlayer;
            int index, currentRow, currentColumn, middlePieceRow, middlePieceColumn;
            player = piece[0].ToString().ToLower();
            index = Convert.ToInt32(piece.Substring(1));
            if (player == "a")
            {
                oppositePiecePlayer = "b";
            }
            else
            {
                oppositePiecePlayer = "a";
            }
            if (newRow >= 0 && newRow < BoardSize &&
                newColumn >= 0 && newColumn < BoardSize)
            {
                if (board[newRow, newColumn] == Space)
                {
                    currentRow = playersPieces[index, Row];
                    currentColumn = playersPieces[index, Column];
                    middlePieceRow = (currentRow + newRow) / 2;
                    middlePieceColumn = (currentColumn + newColumn) / 2;
                    middlePiece = board[middlePieceRow, middlePieceColumn];
                    middlePiecePlayer = middlePiece[0].ToString().ToLower();
                    if (middlePiecePlayer != oppositePiecePlayer && middlePiecePlayer != " ")
                    {
                        valid = true;
                    }
                }
            }
            return valid;
        }

        private static void ListPossibleMoves(string[,] board, int[,] playersPieces, string nextPlayer, MoveRecord[] listOfMoves)
        {
            int direction, numberOfMoves = 0; ;
            int currentColumn, leftColumn, rightColumn;
            int jumpLeftColumn, jumpRightColumn;
            int currentRow, newRow, jumpRow;
            string piece;

            if (nextPlayer == "a")
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }
            for (int i = 1; i < NumberOfPieces + 1; i++)
            {
                piece = nextPlayer + i;
                currentRow = playersPieces[i, Row];
                currentColumn = playersPieces[i, Column];
                if (playersPieces[i, Dame] == 1)
                {
                    piece = piece.ToUpper();
                }
                newRow = currentRow + direction;
                leftColumn = currentColumn - 1;
                rightColumn = currentColumn + 1;
                if (ValidMove(board, newRow, leftColumn))
                {
                    Console.WriteLine(piece + " can move to " + newRow + " , " + leftColumn);
                    numberOfMoves++;
                    listOfMoves[numberOfMoves].Piece = piece;
                    listOfMoves[numberOfMoves].NewRow = newRow;
                    listOfMoves[numberOfMoves].NewColumn = leftColumn;
                    listOfMoves[numberOfMoves].CanJump = false;
                }
                if (ValidMove(board, newRow, rightColumn))
                {
                    Console.WriteLine(piece + " can move to " + newRow + " , " + rightColumn);
                    numberOfMoves++;
                    listOfMoves[numberOfMoves].Piece = piece;
                    listOfMoves[numberOfMoves].NewRow = newRow;
                    listOfMoves[numberOfMoves].NewColumn = rightColumn;
                    listOfMoves[numberOfMoves].CanJump = false;
                }
                jumpRow = currentRow + direction + direction;
                jumpLeftColumn = currentColumn - 2;
                jumpRightColumn = currentColumn + 2;
                if (ValidJump(board, playersPieces, piece, jumpRow, jumpLeftColumn))
                {
                    Console.WriteLine(piece + " can jump to " + jumpRow + " , " + jumpLeftColumn);
                    numberOfMoves++;
                    listOfMoves[numberOfMoves].Piece = piece;
                    listOfMoves[numberOfMoves].NewRow = jumpRow;
                    listOfMoves[numberOfMoves].NewColumn = jumpLeftColumn;
                    listOfMoves[numberOfMoves].CanJump = true;
                }
                if (ValidJump(board, playersPieces, piece, jumpRow, jumpRightColumn))
                {
                    Console.WriteLine(piece + " can jump to " + jumpRow + " , " + jumpRightColumn);
                    numberOfMoves++;
                    listOfMoves[numberOfMoves].Piece = piece;
                    listOfMoves[numberOfMoves].NewRow = jumpRow;
                    listOfMoves[numberOfMoves].NewColumn = jumpRightColumn;
                    listOfMoves[numberOfMoves].CanJump = true;
                }
            }
            Console.WriteLine("There are " + numberOfMoves + " possible moves");
        }

        private static bool ListEmpty(MoveRecord[] listOfMoves)
        {
            if (listOfMoves[1].Piece == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int SelectMove(MoveRecord[] listOfMoves)
        {
            bool validPiece = false, validMove, found, endOfList;
            string piece = "", rowString, columnString;
            int index = 0, chosenPieceIndex;
            int newRow, newColumn;
            while (!validPiece)
            {
                found = false;
                endOfList = false;
                Console.Write("Which piece do you want to move? ");
                piece = Console.ReadLine();
                index = 0;
                if (piece == "")
                {
                    endOfList = true;
                }
                while (!found && !endOfList)
                {
                    index++;
                    if (listOfMoves[index].Piece == piece)
                    {
                        found = true;
                    }
                    else if (listOfMoves[index].Piece == "")
                    {
                        endOfList = true;
                        DisplayErrorCode(1);
                    }
                }
                if (found)
                {
                    validPiece = true;
                }
            }
            chosenPieceIndex = index;
            validMove = false;
            while (!validMove)
            {
                Console.Write("Which row do you want to move to? ");
                rowString = Console.ReadLine();
                Console.Write("Which column do you want to move to? ");
                columnString = Console.ReadLine();
                try
                {
                    newRow = Convert.ToInt32(rowString);
                    newColumn = Convert.ToInt32(columnString);
                    found = false;
                    endOfList = false;
                    index = chosenPieceIndex - 1;
                    while (!found && !endOfList)
                    {
                        index++;
                        if (listOfMoves[index].Piece != piece)
                        {
                            endOfList = true;
                            DisplayErrorCode(2);
                        }
                        else if (listOfMoves[index].NewRow == newRow &&
                            listOfMoves[index].NewColumn == newColumn)
                        {
                            found = true;
                        }
                    }
                    validMove = found;
                }
                catch (Exception)
                {
                    DisplayErrorCode(3);
                }
            }
            return index;
        }

        private static void MoveDame(string[,] board, string player, ref int newRow, ref int newColumn)
        {
            if (player == "a")
            {
                for (int i = 1; i < 8; i = i + 2)
                {
                    if (board[0, i] == Space)
                    {
                        newColumn = i;
                        newRow = 0;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 7; i = i + 2)
                {
                    if (board[BoardSize - 1, i] == Space)
                    {
                        newColumn = i;
                        newRow = BoardSize - 1;
                        break;
                    }
                }
            }
        }

        private static void MovePiece(string[,] board, int[,] playersPieces,
          string chosenPiece, int newRow, int newColumn)
        {
            int index, currentRow, currentColumn;
            string player;
            index = Convert.ToInt32(chosenPiece.Substring(1));
            currentRow = playersPieces[index, Row];
            currentColumn = playersPieces[index, Column];
            board[currentRow, currentColumn] = Space;
            if (newRow == BoardSize - 1 && playersPieces[index, Dame] == 0)
            {
                player = "a";
                playersPieces[0, 1] = playersPieces[0, 1] + 1;
                playersPieces[index, Dame] = 1;
                chosenPiece = chosenPiece.ToUpper();
                MoveDame(board, player, ref newRow, ref newColumn);
            }
            else if (newRow == 0 && playersPieces[index, Dame] == 0)
            {
                player = "b";
                playersPieces[0, 1] = playersPieces[0, 1] + 1;
                playersPieces[index, Dame] = 1;
                chosenPiece = chosenPiece.ToUpper();
                MoveDame(board, player, ref newRow, ref newColumn);
            }
            playersPieces[index, Row] = newRow;
            playersPieces[index, Column] = newColumn;
            board[newRow, newColumn] = chosenPiece;
        }

        private static void MakeMove(string[,] board, int[,] playersPieces, int[,] opponentsPieces, MoveRecord[] listOfMoves, int pieceIndex)
        {
            string piece, middlePiece;
            int newRow, newColumn, playersPieceIndex, currentRow, currentColumn;
            int middlePieceRow, middlePieceColumn;
            bool jumping;
            playersPieces[0, 0] = playersPieces[0, 0] + 1;
            if (pieceIndex > 0)
            {
                piece = listOfMoves[pieceIndex].Piece;
                newRow = listOfMoves[pieceIndex].NewRow;
                newColumn = listOfMoves[pieceIndex].NewColumn;
                playersPieceIndex = Convert.ToInt32(piece.Substring(1));
                currentRow = playersPieces[playersPieceIndex, Row];
                currentColumn = playersPieces[playersPieceIndex, Column];
                jumping = listOfMoves[pieceIndex].CanJump;
                MovePiece(board, playersPieces, piece, newRow, newColumn);
                if (jumping)
                {
                    middlePieceRow = (currentRow + newRow) / 2;
                    middlePieceColumn = (currentColumn + newColumn) / 2;
                    middlePiece = board[middlePieceRow, middlePieceColumn];
                    Console.WriteLine("jumped over " + middlePiece);
                }
            }
        }

        private static string SwapPlayer(string nextPlayer)
        {
            if (nextPlayer == "a")
            {
                return "b";
            }
            else
            {
                return "a";
            }
        }

        private static void PrintResult(int[,] a, int[,] b, string nextPlayer)
        {

            Console.WriteLine("Game ended");
            Console.WriteLine(nextPlayer + " lost this game as they cannot make a move");
            PrintPlayerPieces(a, b);
        }

        private static void Game()
        {
            int[,] A = new int[NumberOfPieces + 1, 3];
            int[,] B = new int[NumberOfPieces + 1, 3];
            string[,] board = new string[BoardSize, BoardSize];
            MoveRecord[] listOfMoves = new MoveRecord[MaxMoves];
            for (int i = 0; i < MaxMoves; i++)
            {
                MoveRecord tempRec = new MoveRecord();
                listOfMoves[i] = tempRec;
            }
            bool fileFound = false, gameEnd = false;
            string nextPlayer = "a";
            int pieceIndex = 0;
            SetUpBoard(board, A, B, ref fileFound);
            if (!fileFound)
            {
                gameEnd = true;
            }
            while (!gameEnd)
            {
                PrintPlayerPieces(A, B);
                DisplayBoard(board);
                Console.WriteLine("Next Player: " + nextPlayer);
                ClearList(listOfMoves);
                if (nextPlayer == "a")
                {
                    ListPossibleMoves(board, A, nextPlayer, listOfMoves);
                    if (!ListEmpty(listOfMoves))
                    {
                        pieceIndex = SelectMove(listOfMoves);
                        MakeMove(board, A, B, listOfMoves, pieceIndex);
                        nextPlayer = SwapPlayer(nextPlayer);
                    }
                    else
                    {
                        gameEnd = true;
                    }
                }
                else
                {
                    ListPossibleMoves(board, B, nextPlayer, listOfMoves);
                    if (!ListEmpty(listOfMoves))
                    {
                        pieceIndex = SelectMove(listOfMoves);
                        MakeMove(board, B, A, listOfMoves, pieceIndex);
                        nextPlayer = SwapPlayer(nextPlayer);
                    }
                    else
                    {
                        gameEnd = true;
                    }
                }
            }
            if (fileFound)
            {
                PrintResult(A, B, nextPlayer);
            }

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Game();
        }
    }
}
