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
    public class AddCategory : ControllerBase
    {
        [HttpPost]
        public StatusCodeResult AddNewCategory(string categoryName)
        {
            using (SqlConnection connection = new SqlConnection($@"Data Source=tcp:prikhodpc.database.windows.net,1433;Initial Catalog=SpendingControl;User Id=PRIKHOD@prikhodpc;Password=12345_qwert"))
            {
                connection.Open();

                if (ValidateData.CheckCategoryName(categoryName) == false)
                {
                    return StatusCode(204);
                }

                string stringCommand = @$"INSERT INTO [CATEGORY]([NAME]) VALUES" +
                @$"('{categoryName}');";

                SqlCommand command = new SqlCommand(stringCommand, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }

            return StatusCode(200);
        }
    }
}
