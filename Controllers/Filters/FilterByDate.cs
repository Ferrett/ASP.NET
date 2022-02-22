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
    public class FilterByDate : ControllerBase
    {
        [HttpGet]
        public IEnumerable<SpendingControl> FilterSpendingsByDate(int date)
        {
            return FilterByCategory.Filter("DATE", date);
        }
    }
}
