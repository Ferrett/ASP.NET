﻿using Microsoft.AspNetCore.Http;
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
    public class AddCategoryController : Controller
    {
        [HttpGet]
        public string Get(string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection($@"Data Source = sql5108.site4now.net; User ID = db_a852fc_prikhod3228_admin; Password = 12345qwert; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))
                {
                    connection.Open();
                    string stringCommand = $"INSERT INTO [CATEGORY]([NAME]) VALUES('{name}');";

                    SqlCommand command = new SqlCommand(stringCommand, connection);
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                return "SUCCESS";
            }
            catch (Exception)
            {
                return "ERROR";
            } 
        }
    }
}
