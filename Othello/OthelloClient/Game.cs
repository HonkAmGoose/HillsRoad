using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Othello
{
    /// <summary>
    /// The form to actually play the game
    /// </summary>
    public partial class Game : Form
    {
        OthelloMenu parentMenu;
        Graphics DisplayGraphics;
        GameBoard GameBoard;

        bool online = false;
        int NoValidMovesCounter; // Used to end the game when both players have no valid moves
        int BlackWins = 0, WhiteWins = 0;

        bool opponentConnected;
        Colour player;

        readonly HubConnection connection;
        readonly IHubProxy hubProxy;

        readonly SolidBrush[] TileBrushes = new SolidBrush[] { new SolidBrush(Color.Black), new SolidBrush(Color.White), new SolidBrush(Color.Gold) };

        /// <summary>
        /// Used to indicate whether an opponent joined or left
        /// </summary>
        enum OpponentStatus
        {
            Joined,
            Left,
        }

        /// <summary>
        /// Creates a form to play the game of Othello
        /// </summary>
        /// <param name="parentMenu">Stores a reference to the Othello.Menu instance that opened this form</param>
        /// <param name="online">Determines if a game is online or not</param>
        public Game(OthelloMenu parentMenu, bool online)
        {
            InitializeComponent();
            this.parentMenu = parentMenu;
            this.online = online;

            if (online)
            {
                BonusComboBox.Visible = false;
                StatusLabel.Visible = true;
                Text += " - " + (_ = parentMenu.roomID).ToString() + parentMenu.password;

                // Register hub events
                connection = new HubConnection("http://localhost:9082");
                hubProxy = connection.CreateHubProxy("MyHub");
                hubProxy.On<bool, char>("ReturnGameInfo", (opponentConnected, player) => 
                                        GetReturnedGameInfo(opponentConnected, (player == 'B' ? Colour.Black : player == 'W' ? Colour.White : throw new Exception("Player should be 'B' or 'W'"))));
                hubProxy.On("OpponentJoin", () => UpdateOpponentStatus(OpponentStatus.Joined));
                hubProxy.On("OpponentLeave", () => UpdateOpponentStatus(OpponentStatus.Left));
                hubProxy.On<string>("OpponentMove", (move) => MakeOpponentMove(move));
            }
        }

        /// <summary>
        /// Registered to the hub method OpponentJoin and OpponentLeave, updates opponentConnected
        /// </summary>
        /// <param name="status"></param>
        private void UpdateOpponentStatus(OpponentStatus status)
        {
            opponentConnected = status == OpponentStatus.Joined;
            string prefix = status == OpponentStatus.Joined ? "" : "dis";
            MessageBox.Show($"Opponent {prefix}connected");
        }

        /// <summary>
        /// Registered to the hub method OpponentMove, makes a move for the opponent
        /// </summary>
        /// <param name="move"></param>
        private void MakeOpponentMove(string move)
        {
            Coordinate coord = new Coordinate(move);
            if (GameBoard.ProposeMove(coord))
            {
                GameBoard.ConfirmMove();
            }
            else
            {
                MessageBox.Show("Opponent made an invalid move - exiting");
                if (InvokeRequired) Invoke(new Action(() => Close()));
                else Close();
            }

            if (InvokeRequired) Invoke(new Action(() => Refresh()));
            else Refresh();
        }

        /// <summary>
        /// Registered to the hub method returnGameInfo, stores the game info returned by the server
        /// </summary>
        /// <param name="opponentConnected">Whether the opponent is connected</param>
        /// <param name="player">What colour the user is playing as</param>
        private void GetReturnedGameInfo(bool opponentConnected, Colour player)
        {
            this.opponentConnected = opponentConnected;
            this.player = player;

            if (InvokeRequired) Invoke(new Action(() => UpdateStatusLabel(opponentConnected, player)));
            else UpdateStatusLabel(opponentConnected, player);

            MessageBox.Show($"Opponent is {(opponentConnected ? "" : "not ")}connected, you are player {player}");
        }

        /// <summary>
        /// Updates the status label to show whether the opponent is connected
        /// </summary>
        /// <param name="opponentConnected">Whether the opponent is connected</param>
        /// <param name="player">What colour the user is playing as</param>
        /// <exception cref="ArgumentException">If player is Colour.None</exception>
        private void UpdateStatusLabel(bool opponentConnected, Colour player)
        {
            StatusLabel.Text = $"You are {(player == Colour.Black ? "black" : player == Colour.White ? "white" : throw new ArgumentException("Player should be black or white"))}\n" +
                               $"Opponent {(opponentConnected ? "" : "not ")}connected";
        }

        /// <summary>
        /// Called on load, connects to the server and initialises parts of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GUI_Load(object sender, EventArgs e)
        {
            DisplayGraphics = DisplayPanel.CreateGraphics(); // Get the graphics object to be referenced
            DisplayGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            BonusComboBox.SelectedIndex = 0; // Set combo box to default

            if (online)
            {
                await connection.Start(new LongPollingTransport());
                _ = hubProxy.Invoke("Hello", parentMenu.ID);
                _ = hubProxy.Invoke("GetGameInfo", parentMenu.ID);
            }

            NewGame();
            Refresh();
        }

        /// <summary>
        /// Creates a new game by calling NewGame()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            NewGameButton.Enabled = false; // Don't allow multiple clicks
            Refresh();
            int index;
            if ((index = BonusComboBox.FindString(BonusComboBox.Text)) != -1) // Try to match input string to an option
            {
                BonusComboBox.SelectedIndex = index;
            }
            else // Otherwise revert to default
            {
                BonusComboBox.SelectedIndex = 0;
            }
            NewGame();
            NewGameButton.Enabled = true; 
            Refresh();
        }

        /// <summary>
        /// Hints possible moves to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HintButton_Click(object sender, EventArgs e)
        {
            GameBoard.HintMoves();
            Refresh();
        }

        /// <summary>
        /// Ends a player's turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception">Thrown if Game.player is Colour.None</exception>
        private async void EndTurnButton_Click(object sender, EventArgs e)
        {
            if (online && (/*!opponentConnected ||*/ GameBoard.PlayerTurn != player)) // Change before prod -----------------------------------------------------------------
            {
                string addition = (opponentConnected) ? "are" : "aren't";
                MessageBox.Show($"Opponent's turn - they {addition} connected");
            }
            else
            {
                EndTurnButton.Enabled = false; // Prevent spam of the button
                if (GameBoard.IsMoveProposed) // Only confirm move if one has been proposed
                {
                    string proposedMove = GameBoard.ProposedMove.ToString();
                    GameBoard.ConfirmMove();
                    if (online)
                    {
                        await connection.Start(new LongPollingTransport());
                        _ = hubProxy.Invoke("Hello", parentMenu.ID);
                        _ = hubProxy.Invoke("MakeMove", 
                                            parentMenu.ID, 
                                            player == Colour.Black ? 'B' : player == Colour.White ? 'W' : throw new Exception("Player should be black or white"), 
                                            proposedMove);
                    }
                    StartTurn();
                    Refresh();
                }
                EndTurnButton.Enabled = true;
            }
        }

        /// <summary>
        /// Called when clicking the game area, proposes a move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (online && GameBoard.PlayerTurn != player)
            {
                string addition = (opponentConnected) ? "are" : "aren't";
                MessageBox.Show($"Opponent's turn - they {addition} connected");
            }
            else
            {
                if (GameBoard.IsMoveProposed)
                {
                    GameBoard.CancelMove();
                }

                int x, y;
                Coordinate location;
                if (e.Location.X % 50 > 5 && e.Location.Y % 50 > 5) // Location is a green square and not a black line
                {
                    // Convert coordinate to 2d index
                    x = e.Location.X / 50;
                    y = e.Location.Y / 50;
                    location = new Coordinate(x, y);
                    GameBoard.ProposeMove(location);
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Draws the game panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawBackground();
            DrawPieces();
            UpdateCounterNumbers();
        }

        /// <summary>
        /// Creates a new game by generating a new game board and allowing input
        /// </summary>
        private void NewGame()
        {
            if (BonusComboBox.SelectedIndex == 0) // No bonus
            {
                GameBoard = new GameBoard();
            }
            else
            {
                int bonus = BonusComboBox.SelectedIndex - 1;
                GameBoard = new GameBoard(bonus / 4 == 0 ? Colour.Black : Colour.White, bonus % 4 + 1);
            }

            NoValidMovesCounter = 0;
            GameBoard.StartTurn();
            DisplayPanel.Enabled = true;
            HintButton.Enabled = true;
            EndTurnButton.Enabled = true;
        }

        /// <summary>
        /// Method used at the start of the turn to check for the end of the game
        /// </summary>
        private void StartTurn()
        {
            if (!GameBoard.StartTurn())
            {
                NoValidMovesCounter++;
                if (NoValidMovesCounter >= 2) // Neither player has valid moves
                {
                    EndGame();
                    return;
                }
                StartTurn(); // Recursion
            }
            else if(NoValidMovesCounter != 0)
            {
                MessageBox.Show("No valid moves for " + ((GameBoard.PlayerTurn == Colour.Black) ? "white" : "black"));
                NoValidMovesCounter = 0;
            }
        }

        /// <summary>
        /// Ends game by showing a messagebox and disabling input
        /// </summary>
        private void EndGame()
        {
            Refresh();
            if (GameBoard.CounterNumbers[0] > GameBoard.CounterNumbers[1])
            {
                BlackWinLabel.Text = (++BlackWins).ToString();
                MessageBox.Show("Game Over - Black wins!");
            }
            else if (GameBoard.CounterNumbers[0] < GameBoard.CounterNumbers[1])
            {
                WhiteWinLabel.Text = (++WhiteWins).ToString();
                MessageBox.Show("Game Over - White wins!");
            }
            else
            {
                BlackWinLabel.Text = (++BlackWins).ToString();
                WhiteWinLabel.Text = (++WhiteWins).ToString();
                MessageBox.Show("Game Over - Draw!");
            }
            DisplayPanel.Enabled = false;
            HintButton.Enabled = false;
            EndTurnButton.Enabled = false;
        }

        /// <summary>
        /// Updates the counter numbers
        /// </summary>
        private void UpdateCounterNumbers()
        {
            BlackCounterLabel.Text = GameBoard.CounterNumbers[0].ToString();
            WhiteCounterLabel.Text = GameBoard.CounterNumbers[1].ToString();
        }

        /// <summary>
        /// Draws the background gameboard
        /// </summary>
        private void DrawBackground()
        {
            using (SolidBrush lineBrush = new SolidBrush(Color.Black))
            {
                DisplayGraphics.Clear(Color.Green); // Green background

                for (int i = 0; i <= 405; i += 50) // Black grid over the top
                {
                    DisplayGraphics.FillRectangle(lineBrush, i, 0, 5, 405);
                    DisplayGraphics.FillRectangle(lineBrush, 0, i, 405, 5);
                }
            }
        }

        /// <summary>
        /// Draws the pieces onto the board
        /// </summary>
        private void DrawPieces()
        {
            Tile toPaint;
            for (int x = 0; x <= Coordinate.maxX; x++)
            {
                for (int y = 0; y <= Coordinate.maxY; y++)
                {
                    toPaint = GameBoard.Tiles[x, y];
                    if (toPaint.CounterStatus != Status.None)
                    {
                        int playerColour = (toPaint.CounterColour == Colour.Black) ? 0 : 1;
                        int opponentColour = (toPaint.CounterColour == Colour.Black) ? 1 : 0;
                        switch (toPaint.CounterStatus)
                        {
                            case Status.Confirmed: // Confirmed is a whole counter of player colour
                                DrawCounter(TileBrushes[playerColour], x, y); 
                                break;

                            case Status.Turning: // Turning is big counter of opponent with small counter of player colour
                                DrawCounter(TileBrushes[opponentColour], x, y);
                                DrawSmallCounter(TileBrushes[playerColour], x, y);
                                break;

                            case Status.Proposed: // Proposed is small counter of player colour
                                DrawSmallCounter(TileBrushes[playerColour], x, y);
                                break;

                            case Status.Hinted: // Hints are in gold
                                DrawSmallCounter(TileBrushes[2], x, y);
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Draws a counter in a specified place with a specified colour
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void DrawCounter(SolidBrush brush, int x, int y)
        {
            DisplayGraphics.FillEllipse(brush, x * 50 + 7, y * 50 + 7, 40, 40);
        }

        /// <summary>
        /// Draws a small counter in a specified place with a specified colour
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void DrawSmallCounter(SolidBrush brush, int x, int y)
        {
            DisplayGraphics.FillEllipse(brush, x * 50 + 12, y * 50 + 12, 30, 30);
        }

        /// <summary>
        /// Called when form closes, tells the server that the player is leaving and redisplays the menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (var connection = new HubConnection(Program.hubConnection))
            {
                var hubProxy = connection.CreateHubProxy("MyHub");

                // Start listening
                await connection.Start(new LongPollingTransport());

                // Send a message to server / other clients
                _ = hubProxy.Invoke("Leaving", parentMenu.ID);
            }

            parentMenu.Show();
        }
    }
}
