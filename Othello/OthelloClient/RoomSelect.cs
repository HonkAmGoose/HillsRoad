using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;
using Microsoft.AspNet.SignalR.Client.Hubs;
using System.Runtime.CompilerServices;

namespace Othello
{
    /// <summary>
    /// Form to prompt the user to join or create a room
    /// </summary>
    public partial class RoomSelect : Form
    {
        /// <summary>
        /// Stores the instance statically
        /// </summary>
        public static RoomSelect Instance;
        
        OthelloMenu ParentMenu;
        readonly HubConnection connection;
        readonly IHubProxy hubProxy;

        /// <summary>
        /// Creates a form to prompt the user to join or create a room
        /// </summary>
        /// <param name="parent"></param>
        public RoomSelect(OthelloMenu parent)
        {
            InitializeComponent();

            ParentMenu = parent;

            // Register hub events
            connection = new HubConnection("http://localhost:9082");
            hubProxy = connection.CreateHubProxy("MyHub");
            hubProxy.On<int, string>("ReturnRoom", (roomID, password) => GetReturnedRoom(roomID, password));
            hubProxy.On("ReturnJoined", () => JoinedRoomSuccess());
            hubProxy.On("ReturnDenied", () => JoinedRoomFailed());
        }

        /// <summary>
        /// Stores the current instance in the static variable Instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoomSelect_Load(object sender, EventArgs e)
        {
            Instance = this;
        }

        /// <summary>
        /// Deletes some variables and closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoomSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            ParentMenu = null;
            Instance = null;

            connection.Dispose();
        }

        /// <summary>
        /// Creates a new room on the server, which will return data via the hub method ReturnRoom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CreateButton_Click(object sender, EventArgs e)
        {
            await connection.Start(new LongPollingTransport());
            _ = hubProxy.Invoke("CreateRoom");
        }

        /// <summary>
        /// Joins an existing room with the details provided by the user in the RoomCodeTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void JoinButton_Click(object sender, EventArgs e)
        {
            string input = RoomCodeTextBox.Text.Replace(" ", "");
            RoomCodeTextBox.Text = "";

            try
            {
                // Should work with any number of digits for roomID
                ParentMenu.roomID = Convert.ToInt32(input.Substring(0, input.Length - 5));
                ParentMenu.password = input.Substring(input.Length - 5);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Room code is at least 6 digits");
                return;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid room code");
                return;
            }

            await connection.Start(new LongPollingTransport());
            _ = hubProxy.Invoke("JoinRoom", ParentMenu.ID, ParentMenu.roomID, ParentMenu.password);
        }

        /// <summary>
        /// Registered to the hub method ReturnRoom, gets and stores data about a created room
        /// </summary>
        /// <param name="roomID">The ID of the room</param>
        /// <param name="password">The password of the room</param>
        private async void GetReturnedRoom(int roomID, string password)
        {
            ParentMenu.roomID = roomID;
            ParentMenu.password = password;

            MessageBox.Show($"Room successfully made - your room code is {roomID.ToString() + password} (spaces and capitalisation don't matter)");

            await connection.Start(new LongPollingTransport());
            _ = hubProxy.Invoke("JoinRoom", ParentMenu.ID, ParentMenu.roomID, ParentMenu.password);
        }

        /// <summary>
        /// Registered to the hub method ReturnJoined, opens an online game, and closes the current menu
        /// </summary>
        private void JoinedRoomSuccess()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ParentMenu.NewOnlineGame()));
                Invoke(new Action(() => Close()));
            }
            else
            {
                ParentMenu.NewOnlineGame();
                Close();
            }
        }

        /// <summary>
        /// Registered to the hub method ReturnFailed, shows an error message
        /// </summary>
        private void JoinedRoomFailed()
        {
            MessageBox.Show("Invalid details");
        }
    }
}
