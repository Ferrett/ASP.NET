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
    public class PlayerControllerGET : ControllerBase
    {

        [HttpGet]
        public Player Get(string teamName, string playerName)
        {
            if (PlayerControllerSET.FindTeamID(teamName) == -1 || PlayerControllerSET.FindPlayerID(teamName,playerName) == -1)
            {
                return null;
            }
          
            return PlayerControllerSET.team[PlayerControllerSET.FindTeamID(teamName)].Players[PlayerControllerSET.FindPlayerID(teamName,playerName)];
        }
    }
}
