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
    public class GetUsersData : ControllerBase
    {
        private readonly ILogger<GetUsersData> _logger;
        public GetUsersData(ILogger<GetUsersData> logger)
        {
            _logger = logger;
        }

       
        [HttpGet]
        public IEnumerable<PersonalData> GetDataFromDB()
        {
            return GetUsers();
        }
        public  static IEnumerable<PersonalData> GetUsers()
        {
            List<PersonalData> tables = new List<PersonalData>();

            using (SqlConnection connection = new SqlConnection($@"Data Source=tcp:prikhodpc.database.windows.net,1433;Initial Catalog=User_Data;User Id=PRIKHOD@prikhodpc;Password=12345_qwert"))
            {
                connection.Open();
                string oString = $"SELECT * FROM [DATA];";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Role role = new Role(int.Parse(oReader["ROLE_ID"].ToString()));

                        tables.Add(new PersonalData(
                            oReader["LOGIN"].ToString(),
                            oReader["HASHPASS"].ToString(),
                            DateTime.Parse(oReader["BDAY"].ToString()),
                            oReader["EMAIL"].ToString(),
                            role.GetRole()
                         ));
                    }
                }
                connection.Close();
            }
            return tables;
        }
    }
}
