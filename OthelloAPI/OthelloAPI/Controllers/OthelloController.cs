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
            return "hi";

        }
    }
}
