using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    public partial class RoomSelect : Form
    {
        public static RoomSelect Instance;

        public RoomSelect()
        {
            InitializeComponent();
        }

        private void RoomSelect_Load(object sender, EventArgs e)
        {
            Instance = this;
        }

        private void RoomSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string[] words = File.ReadAllLines("C:\\Users\\Dom\\My stuff\\SixthForm\\Computer Science\\Code\\Othello\\OthelloClient\\Words.txt");
            Random random = new Random();
            string password = words[random.Next(words.Length)];
            using (var database = new SqlConnection(Program.connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    $"INSERT INTO Room(Password) VALUES ('{password}'); " + // I know this could be insecure - fix
                    "SELECT TOP 1 RoomID FROM Room ORDER BY RoomID DESC;", 
                    database);
                database.Open();

                string result = cmd.ExecuteScalar().ToString();
                Console.WriteLine(result);

                cmd = new SqlCommand(
                    $"DELETE FROM Room WHERE RoomID={result};", // I know this could be insecure - fix
                    database);
            }
        }
    }
}
