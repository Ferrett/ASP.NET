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
    public class NaviController : ControllerBase
    {
        private static List<string> NickNames = new List<string>()
        {
            "s1mple", "electronic", "Boombl4", "Perfecto", "b1t"
        };

        private static List<string> Positions = new List<string>()
        {
            "awp", "rifle", "captain", "farmer", "rifle"
        };

        private readonly ILogger<NaviController> _logger;

        public NaviController(ILogger<NaviController> logger)
        {
            _logger = logger;
        }

        // Дефолтный состав команды
        private static List<Navi> navi = new List<Navi>()
        {
            new Navi { NickName = NickNames[0],TeamJoinDate = DateTime.Now, Position =Positions[0] },
            new Navi { NickName = NickNames[1],TeamJoinDate = DateTime.Now, Position =Positions[1] },
            new Navi { NickName = NickNames[2],TeamJoinDate = DateTime.Now, Position =Positions[2] },
            new Navi { NickName = NickNames[3],TeamJoinDate = DateTime.Now, Position =Positions[3] },
            new Navi { NickName = NickNames[4],TeamJoinDate = DateTime.Now, Position =Positions[4] },
        };
        

        [HttpGet]
        public IEnumerable<Navi> Get()
        {
            return navi;
        }

        [HttpPost]
        public StatusCodeResult Post(string nickname, string position)
        {
            if (navi.Count < 5)
            {
                navi.Add(new Navi
                {

                    NickName = nickname,
                    TeamJoinDate = DateTime.Now,
                    Position = position
                });
                NickNames.Add(nickname);
                Positions.Add(position);

                return StatusCode(200);
            }
            
            return StatusCode(204);
        }

        [HttpDelete]
        public StatusCodeResult Delete(string nickName)
        {
            if (NickNames.FindIndex(0,NickNames.Count, x => x.Equals(nickName)) == -1)
            {
                return StatusCode(204);
            }

            navi.Remove(navi.Find(x => x.NickName == nickName));

            Positions.Remove(Positions[NickNames.IndexOf(nickName)]);
            NickNames.Remove(nickName);

            return StatusCode(200);
        }

        [HttpPatch]
        public StatusCodeResult Patch(string nickName, string newNickname, string newPosition)
        {
            if (NickNames.FindIndex(0, NickNames.Count, x => x.Equals(nickName)) == -1)
            {
                return StatusCode(204);
            }

            navi[navi.IndexOf(navi.Find(x => x.NickName == nickName))].TeamJoinDate = DateTime.Now;
            navi[navi.IndexOf(navi.Find(x => x.NickName == nickName))].Position = newPosition;
            navi[navi.IndexOf(navi.Find(x => x.NickName == nickName))].NickName = newNickname;

            return StatusCode(200);
        }
    }
}
