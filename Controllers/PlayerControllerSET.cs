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
    public class PlayerControllerSET : ControllerBase
    {
        private readonly ILogger<PlayerControllerSET> _logger;
        public PlayerControllerSET(ILogger<PlayerControllerSET> logger)
        {
            _logger = logger;
        }

        // Дефолтная команда
        public static List<Team> team = new List<Team>()
        {
            new Team("NAVI",Game.CSGO,DateTime.Now,new List<Player>()
            {
                new Player("s1mple",DateTime.Now,24,5000000),
                new Player("electronic",DateTime.Now,26,200000),
                new Player("Boombl4",DateTime.Now,21,750000),
                new Player("Perfecto",DateTime.Now,20,750000),
                new Player("b1t",DateTime.Now,19,100000)
            })
        };


        [HttpPost]
        public StatusCodeResult Post(string teamName, string nickName, int age, int winnings,string token)
        {
            if (GetTokenController.CheckToken(token))
            {
                if (team[FindTeamID(teamName, token)].Players.Count >= 5)
                {
                    return StatusCode(204);
                }

                team[FindTeamID(teamName, token)].Players.Add(new Player(nickName, DateTime.Now, age, winnings));

                return StatusCode(200);
            }

            return StatusCode(401);
        }

        [HttpDelete]
        public StatusCodeResult Delete(string teamName, string nickName,string token)
        {
            if (GetTokenController.CheckToken(token))
            {
                if (FindPlayerID(teamName, nickName,token) == -1 || FindTeamID(teamName, token) == -1)
                {
                    return StatusCode(204);
                }

                team[FindTeamID(teamName,  token)].Players.Remove(team[FindTeamID(teamName,  token)].Players[FindPlayerID(teamName, nickName, token)]);
                return StatusCode(200);
            }
            return StatusCode(401);
        }

        public static int FindTeamID(string teamName,string token)
        {

            if (GetTokenController.CheckToken(token))
            {
                return team.FindIndex(x => x.Name.Equals(teamName));
            }

            return -1;
        }

        public static int FindPlayerID(string teamName, string playerName,string token)
        {
            if (GetTokenController.CheckToken(token))
            {
                return team[FindTeamID(teamName, token)].Players.FindIndex(x => x.NickName.Equals(playerName));
            }
            return -1;
        }

        [HttpPatch]
        public StatusCodeResult Patch(string teamName, string nickName, string newNickname, int newAge, int newWinnings,string token)
        {
            if (GetTokenController.CheckToken(token))
            {
                if (FindPlayerID(teamName, nickName, token) == -1)
                {
                    return StatusCode(204);
                }

                team[FindTeamID(teamName, token)].Players[FindPlayerID(teamName, nickName, token)] = new Player(
                    newNickname,
                    team[FindTeamID(teamName, token)].Players[FindPlayerID(teamName, nickName, token)].TeamJoinDate,
                    newAge,
                    newWinnings);

                return StatusCode(200);
            }

            return StatusCode(401);
           
        }
    }
}
