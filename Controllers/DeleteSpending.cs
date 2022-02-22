using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace WebApplication2
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteSpending : ControllerBase
    {
        [HttpDelete]
        public StatusCodeResult DeleteUserData(int deleteSpendingID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection($@"Data Source=tcp:prikhodpc.database.windows.net,1433;Initial Catalog=SpendingControl;User Id=PRIKHOD@prikhodpc;Password=12345_qwert"))
                {
                    connection.Open();

                    string stringCommand = @$" DELETE FROM [SPENDING] WHERE [ID] = '{deleteSpendingID}'";

                    SqlCommand command = new SqlCommand(stringCommand, connection);
                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception)
            {
                return StatusCode(204);
            }
                   
                 
            return StatusCode(200);
        }
    }
}
