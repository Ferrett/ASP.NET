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
        public StatusCodeResult Post(string teamName, Game discipline)
        {
            PlayerControllerSET.team.Add(new Team(teamName,discipline, DateTime.Now, new List<Player>()));

            return StatusCode(200);
        }

        [HttpDelete]
        public StatusCodeResult Delete(string teamName)
        {
            if (PlayerControllerSET.FindTeamID(teamName) == -1)
            {
                return StatusCode(204);
            }

            PlayerControllerSET.team.Remove(PlayerControllerSET.team[PlayerControllerSET.FindTeamID(teamName)]);

            return StatusCode(200);
        }

        [HttpPatch]
        public StatusCodeResult Patch(string teamName, string newTeamName, Game newDiscipline)
        {
            if (PlayerControllerSET.FindTeamID(teamName) == -1)
            {
                return StatusCode(204);
            }


            PlayerControllerSET.team[PlayerControllerSET.FindTeamID(teamName)] = new Team(
                newTeamName,
                newDiscipline,
                PlayerControllerSET.team[PlayerControllerSET.FindTeamID(teamName)].CreationDate,
                PlayerControllerSET.team[PlayerControllerSET.FindTeamID(teamName)].Players);

            return StatusCode(200);
        }
    }
}
