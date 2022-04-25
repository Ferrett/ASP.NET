using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TextApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetDataByCategoryIDController : Controller
    {
        [HttpGet]
        public string Get(int categoryID)
        {
            string data = string.Empty;
            using (SqlConnection connection = new SqlConnection($@"Data Source = sql5108.site4now.net; User ID = db_a852fc_prikhod3228_admin; Password = 12345qwert; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))
            {
                connection.Open();

                string stringCommand = $"SELECT * FROM [PRODUCT] WHERE [ID] = {categoryID};";
                SqlCommand oCmd = new SqlCommand(stringCommand, connection);
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        data += oReader["NAME"].ToString();
                    }
                }

                SqlCommand command = new SqlCommand(stringCommand, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }
        
       
    }
}
