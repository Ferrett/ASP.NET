using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamControllerGET : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Team> Get(string token)
        {
            if (GetTokenController.CheckToken(token))
            {
                return PlayerControllerSET.team;
            }
            return null;
        }
    }
}
