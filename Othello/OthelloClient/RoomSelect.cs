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
    public partial class RoomSelect : Form
    {
        public static RoomSelect Instance;
        public static OthelloMenu ParentMenu;

        HubConnection connection;
        IHubProxy hubProxy;


        public RoomSelect(OthelloMenu parent)
        {
            InitializeComponent();

            ParentMenu = parent;

            connection = new HubConnection("http://localhost:9082");
            hubProxy = connection.CreateHubProxy("MyHub");
            hubProxy.On<int, string>("ReturnRoom", (roomID, password) => GetReturnedRoom(roomID, password));
            hubProxy.On("ReturnJoined", () => JoinedRoomSuccess());
            hubProxy.On("ReturnDenied", () => JoinedRoomFailed());
        }

        private void RoomSelect_Load(object sender, EventArgs e)
        {
            Instance = this;
        }

        private void RoomSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            ParentMenu = null;
            Instance = null;

            connection.Dispose();
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            await connection.Start(new LongPollingTransport());
            _ = hubProxy.Invoke("CreateRoom");
        }

        private async void JoinButton_Click(object sender, EventArgs e)
        {
            string input = RoomCodeTextBox.Text.Replace(" ", "");
            RoomCodeTextBox.Text = "";

            try
            {
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
            _ = hubProxy.Invoke("JoinRoom", ParentMenu.roomID, ParentMenu.password, ParentMenu.ID);
        }

        private async void GetReturnedRoom(int roomID, string password)
        {
            ParentMenu.roomID = roomID;
            ParentMenu.password = password;

            MessageBox.Show($"Room successfully made - your room code is {roomID.ToString() + password} (no spaces and capitalisation doesn't matter)");

            await connection.Start(new LongPollingTransport());
            _ = hubProxy.Invoke("JoinRoom", ParentMenu.roomID, ParentMenu.password, ParentMenu.ID);
        }

        private void JoinedRoomSuccess()
        {
            
            if (InvokeRequired)
            {
                Invoke(new Action(() => ParentMenu.NewOnlineGame(ParentMenu.roomID, ParentMenu.password)));
                Invoke(new Action(() => Close()));
            }
            else
            {
                ParentMenu.NewOnlineGame(ParentMenu.roomID, ParentMenu.password);
                Close();
            }
        }

        private void JoinedRoomFailed()
        {

        }
    }
}
