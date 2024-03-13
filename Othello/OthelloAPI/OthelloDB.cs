using System;
using System.Data.SqlClient;

namespace Othello
{
    /// <summary>
    /// Static class to interface with the database
    /// </summary>
    static internal class OthelloDB
    {
        /// <summary>
        /// Stores the database connection string
        /// </summary>
        public const string connectionString = "Server=localhost; Database=OTHELLO_DB; Trusted_Connection=True;";

        /// <summary>
        /// Submits a query to the database
        /// </summary>
        /// <param name="query"></param>
        public static void QueryNoResult(string query)
        {
            using (var database = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, database);
                database.Open();

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Submits a query to the database and returns a scalar int
        /// </summary>
        /// <param name="query">Query to process</param>
        /// <returns>Single int result of the query</returns>
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

        /// <summary>
        /// Submits a query to the database and returns a scalar string
        /// </summary>
        /// <param name="query">Query to process</param>
        /// <returns>Single string result of the query</returns>
        public static string QueryStrScalar(string query)
        {
            using (var database = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, database);
                database.Open();

                var result = cmd.ExecuteScalar();

                if (result == null || result.ToString() == "") return null;
                else return result.ToString();
            }
        }
    }
}