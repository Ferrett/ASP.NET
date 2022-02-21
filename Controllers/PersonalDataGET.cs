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
    public class PersonalDataGET : ControllerBase
    {
        private readonly ILogger<PersonalDataGET> _logger;
        public PersonalDataGET(ILogger<PersonalDataGET> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IEnumerable<PersonalData> GetDataFromDB()
        {
            List<PersonalData> tables = new List<PersonalData>();

            using (SqlConnection connection = new SqlConnection($@"Data Source=PRIKHODPC;Password=;User ID=User;Initial Catalog=Personal_Data;Integrated Security=True;"))
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
