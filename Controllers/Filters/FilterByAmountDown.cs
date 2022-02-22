using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    [ApiController]
    [Route("[controller]")]
    public class FilterByAmountDown : Controller
    {
        [HttpGet]

        public IEnumerable<SpendingControl> Filter()
        {
            List<SpendingControl> spendings = GetAllSpendings.GetSpendings().ToList();

            return spendings.OrderBy(x => x.Amount);
        }
    }
}
