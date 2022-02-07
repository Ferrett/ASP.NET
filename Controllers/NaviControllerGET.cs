using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1;

namespace WebApplication5.ControllersGET
{
    [ApiController]
    [Route("[controller]")]
    public class NaviControllerGET : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Navi> Get()
        {
            return WebApplication5.ControllersSET.NaviControllerSET.navi;
        }
    }
}
