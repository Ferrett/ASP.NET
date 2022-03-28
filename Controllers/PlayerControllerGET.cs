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
        public Player Get(string teamName, string playerName, string token)
        {
            if (GetTokenController.CheckToken(token))
            {
                if (PlayerControllerSET.FindTeamID(teamName, token) == -1 || PlayerControllerSET.FindPlayerID(teamName, playerName, token) == -1)
                {
                    return null;
                }

                return PlayerControllerSET.team[PlayerControllerSET.FindTeamID(teamName, token)].Players[PlayerControllerSET.FindPlayerID(teamName, playerName, token)];
            }
           
            return null;
        }
    }
}
