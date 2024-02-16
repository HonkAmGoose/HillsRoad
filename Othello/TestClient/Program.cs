using Microsoft.AspNet.SignalR.Client;
using System.Data.SqlClient;

namespace Othello
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            const string connectionString = "Server=localhost; Database=OTHELLO_DB; Trusted_Connection=True;";

            Console.WriteLine("Client started");

            using (var connection = new HubConnection("http://localhost:9082"))
            {
                var hubProxy = connection.CreateHubProxy("MyHub");

                hubProxy.On<string>("selectAll", (test) =>
                {
                    Console.WriteLine(GetUserNames(connectionString));
                });
            }
        }

        public static string[] GetUserNames(string connectionString)  
        {
            List<string> values = new();

            using (var database = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users;", database);
                database.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    values.Add((string)reader[1]);
                }
            }

            return values.ToArray();
        }
    }
}