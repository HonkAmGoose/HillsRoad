using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    static internal class OthelloDB
    {
        public const string connectionString = "Server=localhost; Database=OTHELLO_DB; Trusted_Connection=True;";

        public static void QueryNoResult(string query)
        {
            using (var database = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, database);
                database.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public static int QueryIntScalar(string query)
        {
            using (var database = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, database);
                database.Open();

                string result = cmd.ExecuteScalar().ToString();
                if (result == "") return -1;
                else return Convert.ToInt32(result);
            }
        }

        public static string QueryStrScalar(string query)
        {
            using (var database = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, database);
                database.Open();

                var result = cmd.ExecuteScalar();

                if (result == null | result.ToString() == "") return null;
                else return result.ToString();
            }
        }
    }
}
