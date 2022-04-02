using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication1;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileDownloadController : ControllerBase
    {
        
        [HttpGet]
        public StatusCodeResult DownloadFile()
        {
            using (SqlConnection connection = new SqlConnection($@"Data Source=tcp:34.88.245.137;Initial Catalog=Logging;User Id=user;Password=mppbl4APe4agoH9P"))
            {
                connection.Open();

                string IP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();

                string stringCommand = @$"INSERT INTO [FileDownload]([IP],[Date]) VALUES" +
                @$"('{IP}','{DateTime.Now} {DateTime.Now.Millisecond}');";

                SqlCommand command = new SqlCommand(stringCommand, connection);
                command.ExecuteNonQuery();


                connection.Close();
            }

            return StatusCode(200);
        }
    }
}
