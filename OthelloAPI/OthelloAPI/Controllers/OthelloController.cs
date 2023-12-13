using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace OthelloAPI.Controllers
{
    [Route("api/Othello")]
    [ApiController]
    public class OthelloController : ControllerBase
    {
        public readonly IConfiguration config;
        public static int testing = 0;

        public OthelloController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public string GetUsers()
        {
            SqlConnection con = new SqlConnection(config.GetConnectionString("OthelloConnection").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Users", con);

            testing++;
            return $"test {testing}";
        }
    }
}
