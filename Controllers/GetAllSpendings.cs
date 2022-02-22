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
    public class GetAllSpendings : ControllerBase
    {
        private readonly ILogger<GetAllSpendings> _logger;

        public GetAllSpendings(ILogger<GetAllSpendings> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<SpendingControl> GetSpendingsFromDB()
        {
            return GetSpendings();
        }
        public static IEnumerable<SpendingControl> GetSpendings()
        {
            List<SpendingControl> spendings = new List<SpendingControl>();

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

                oString = $"SELECT * FROM [SPENDING];";
                oCmd = new SqlCommand(oString, connection);
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        spendings.Add(new SpendingControl(
                            int.Parse(oReader["ID"].ToString()),
                            bool.Parse(oReader["IS_SPENDING"].ToString()),
                            DateTime.Parse(oReader["DATE"].ToString()),
                            int.Parse(oReader["AMOUNT"].ToString()),
                            categories.Find(x => x.CategoryID == int.Parse(oReader["CATEGORY_ID"].ToString()))
                         ));
                    }
                }
                connection.Close();
            }
            return spendings;
        }
    }
}
