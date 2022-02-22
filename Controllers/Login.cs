using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication4
{
    [ApiController]
    [Route("[controller]")]
    public class Login : ControllerBase
    {
        [HttpPost]
        public StatusCodeResult LogIn(string login, string password)
        {
            List<PersonalData> data = GetUsersData.GetUsers().ToList();

            foreach (var item in data)
            {
                if(item.Login == login && BCrypt.Net.BCrypt.Verify(password, item.HashPass) == true)
                    return StatusCode(200);
            }

            return StatusCode(204);
        }
    }
}
