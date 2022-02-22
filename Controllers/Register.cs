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
    public class Register : ControllerBase
    {
        [HttpPost]
        public StatusCodeResult RegisterNewUser(string login, string password, string bDay, string email)
        {

            using (SqlConnection connection = new SqlConnection($@"Data Source=PRIKHODPC;Password=;User ID=User;Initial Catalog=Personal_Data;Integrated Security=True;"))
            {
                connection.Open();

                if (ValidateData.CheckLogin(login) == false || ValidateData.CheckPassword(password) == false ||
                   ValidateData.CheckBDay(bDay) == false || ValidateData.CheckEmail(email) == false)
                {
                    return StatusCode(204);
                }
                
                string stringCommand = @$"INSERT INTO [DATA]([LOGIN],[HASHPASS],[BDAY],[EMAIL],[ROLE_ID]) VALUES" +
                @$"('{login}','{BCrypt.Net.BCrypt.HashPassword(password)}','{bDay}','{email}',2);";

                SqlCommand command = new SqlCommand(stringCommand, connection);
                command.ExecuteNonQuery();


                connection.Close();
            }

            return StatusCode(200);
        }
    }
}
