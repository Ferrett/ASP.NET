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
    public class DeleteUser : ControllerBase
    {
        [HttpDelete]
        public StatusCodeResult DeleteUserData(string login, string password)
        {
            List<PersonalData> data = GetUsersData.GetUsers().ToList();

            foreach (var item in data)
            {
                if (item.Login == login && BCrypt.Net.BCrypt.Verify(password, item.HashPass) == true)
                {
                    using (SqlConnection connection = new SqlConnection($@"Data Source=PRIKHODPC;Password=;User ID=User;Initial Catalog=Personal_Data;Integrated Security=True;"))
                    {
                        connection.Open();

                        string stringCommand = @$" DELETE FROM [DATA] WHERE [LOGIN] = '{login}'";

                        SqlCommand command = new SqlCommand(stringCommand, connection);
                        command.ExecuteNonQuery();

                        connection.Close();
                    }
                    return StatusCode(200);
                }
            }

            return StatusCode(204);
        }
    }
}
