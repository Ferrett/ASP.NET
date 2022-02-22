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
    public class EditSpending : ControllerBase
    {
        [HttpPatch]
        public StatusCodeResult EditSpendingData(int editSpendingID, bool isSpending, string date,  int amount, int categoryID)
        {
            using (SqlConnection connection = new SqlConnection($@"Data Source=tcp:prikhodpc.database.windows.net,1433;Initial Catalog=SpendingControl;User Id=PRIKHOD@prikhodpc;Password=12345_qwert"))
            {
                connection.Open();

                if (ValidateData.CheckAmount(amount) == false || ValidateData.CheckDate(date) == false ||
                               ValidateData.CheckCategoryID(categoryID) == false)
                {
                    return StatusCode(204);
                }

                
                string stringCommand = @$"UPDATE [SPENDING] 
                SET [IS_SPENDING] = '{isSpending}', [DATE] = '{date}', [AMOUNT] = '{amount}', [CATEGORY_ID] = '{categoryID}'
                WHERE [ID] = '{editSpendingID}'";

                SqlCommand command = new SqlCommand(stringCommand, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }

            return StatusCode(200);
        }
    }
}
