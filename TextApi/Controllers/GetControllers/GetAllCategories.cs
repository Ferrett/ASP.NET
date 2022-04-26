using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TextApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAllCategories : Controller
    {
        [HttpGet]
        public string Get()
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection connection = new SqlConnection($@"Data Source = sql5108.site4now.net; User ID = db_a852fc_prikhod3228_admin; Password = 12345qwert; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))
            {
                connection.Open();
                string stringCommand = $"SELECT * FROM [CATEGORY];";
                SqlCommand oCmd = new SqlCommand(stringCommand, connection);
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        categories.Add(new Category
                        {
                            ID = int.Parse(oReader["ID"].ToString()),
                            Name = oReader["NAME"].ToString(),
                        });
                    };
                }

                oCmd.ExecuteNonQuery();

                connection.Close();
            }
            return JsonSerializer.Serialize(categories);
        }
    }
}
