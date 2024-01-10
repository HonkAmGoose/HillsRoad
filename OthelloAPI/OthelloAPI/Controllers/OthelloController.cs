using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace OthelloAPI.Controllers
{
    [Route("api/Othello")]
    [ApiController]
    public class OthelloController : ControllerBase
    {
        public readonly IConfiguration config;

        public OthelloController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public string GetAllUsers()
        {
            //return Environment.MachineName;
            if (Environment.UserName.Contains("DJ148539") || Environment.MachineName.Contains("B104") || Environment.MachineName.Contains("S114"))
            {
                return "No SQL Server instance supported lol";
            }
            else if (Environment.UserName == "Dom") // CHECK THIS -------------------------------------------------------------------------------------
            {
                using var context = new OthelloContext(config);
                User user = context.Find<User>(0);
                return user.UserName;
            }
            else
            {
                return "No clue";
            }
        }
    }
}
