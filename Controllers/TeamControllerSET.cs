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
    public class TeamControllerSET : ControllerBase
    {
        private readonly ILogger<PlayerControllerSET> _logger;
        public TeamControllerSET(ILogger<PlayerControllerSET> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public StatusCodeResult Post(string teamName, Game discipline,string token)
        {
            if (GetTokenController.CheckToken(token))
            {
                PlayerControllerSET.team.Add(new Team(teamName, discipline, DateTime.Now, new List<Player>()));

                return StatusCode(200);
            }
            return StatusCode(401);
        }

        [HttpDelete]
        public StatusCodeResult Delete(string teamName, string token)
        {
            if (GetTokenController.CheckToken(token))
            {

                if (PlayerControllerSET.FindTeamID(teamName, token) == -1)
                {
                    return StatusCode(204);
                }

                PlayerControllerSET.team.Remove(PlayerControllerSET.team[PlayerControllerSET.FindTeamID(teamName, token)]);

                return StatusCode(200);
            }
            return StatusCode(401);
        }

        [HttpPatch]
        public StatusCodeResult Patch(string teamName, string newTeamName, Game newDiscipline, string token)
        {
            if (GetTokenController.CheckToken(token))
            {
                if (PlayerControllerSET.FindTeamID(teamName, token) == -1)
                {
                    return StatusCode(204);
                }


                PlayerControllerSET.team[PlayerControllerSET.FindTeamID(teamName, token)] = new Team(
                    newTeamName,
                    newDiscipline,
                    PlayerControllerSET.team[PlayerControllerSET.FindTeamID(teamName, token)].CreationDate,
                    PlayerControllerSET.team[PlayerControllerSET.FindTeamID(teamName, token)].Players);

                return StatusCode(200);
            }
            return StatusCode(401);
        }
    }
}
