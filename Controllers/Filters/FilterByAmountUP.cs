using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2;

namespace WebApplication2
{
    [ApiController]
    [Route("[controller]")]
    public class FilterByAmountUP : ControllerBase
    {

        [HttpGet]

        public  IEnumerable<SpendingControl> Filter()
        {
            List<SpendingControl> spendings = GetAllSpendings.GetSpendings().ToList();

            return spendings.OrderByDescending(x => x.Amount);
        }

    }
}
