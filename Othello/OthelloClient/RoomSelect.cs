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

namespace Othello
{
    public partial class RoomSelect : Form
    {
        public static RoomSelect Instance;

        int roomID = 0;
        string password = "";
        HubConnection connection = new HubConnection("http://localhost:9082");
        IHubProxy hubProxy;


        public RoomSelect()
        {
            InitializeComponent();
        }

        private void RoomSelect_Load(object sender, EventArgs e)
        {
            Instance = this;

            hubProxy = connection.CreateHubProxy("MyHub");

            hubProxy.On<int, string>("returnRoom", (_roomID, _password) => getReturnedRoom(_roomID, _password));
        }

        private void RoomSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
                await connection.Start(new LongPollingTransport());
                _ = hubProxy.Invoke("createRoom");
        }

        private void getReturnedRoom(int _roomID, string _password)
        {
            roomID = _roomID;
            password = _password;
            Console.WriteLine(roomID + password);
            Close();
        }
    }
}
