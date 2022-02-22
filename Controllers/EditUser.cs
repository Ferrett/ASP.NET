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
    public class EditUser : ControllerBase
    {
        [HttpPatch]
        public StatusCodeResult EditUserData(string login, string newLogin, string password, string newPassword, string bDay, string email)
        {
            using (SqlConnection connection = new SqlConnection($@"Data Source=PRIKHODPC;Password=;User ID=User;Initial Catalog=Personal_Data;Integrated Security=True;"))
            {
                connection.Open();

                if (ValidateData.CheckLogin(login) == false || ValidateData.CheckPassword(password) == false ||
                   ValidateData.CheckBDay(bDay) == false || ValidateData.CheckEmail(email) == false)
                {
                    return StatusCode(204);
                }

                string stringCommand = @$"UPDATE [DATA] 
                SET [LOGIN] = '{newLogin}', [HASHPASS] = '{BCrypt.Net.BCrypt.HashPassword(newPassword)}', [BDAY] = '{bDay}', [EMAIL] = '{email}'
                WHERE [LOGIN] = '{login}'";

                SqlCommand command = new SqlCommand(stringCommand, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }

            return StatusCode(200);
        }
    }
}
