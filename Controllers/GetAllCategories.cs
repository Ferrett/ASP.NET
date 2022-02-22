using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2;

namespace WebApplication2
{
    [ApiController]
    [Route("[controller]")]
    public class GetAllCategories : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Category> GetDataFromDB()
        {
            return GetCategories();
        }
        public static IEnumerable<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection connection = new SqlConnection($@"Data Source=tcp:prikhodpc.database.windows.net,1433;Initial Catalog=SpendingControl;User Id=PRIKHOD@prikhodpc;Password=12345_qwert"))
            {
                connection.Open();

                string oString = $"SELECT * FROM [CATEGORY];";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        categories.Add(new Category(int.Parse(oReader["ID"].ToString()), oReader["NAME"].ToString()));
                    }
                }

                connection.Close();
            }
            return categories;
        }
    }
}
