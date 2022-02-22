using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class ValidateData
    {
        public static bool CheckPassword(string password)
        {
            if (password.Length < 5 || password.Length > 30)
                return false;

            return true;
        }

        public static bool CheckLogin(string login)
        {
            if (login.Length < 5 || login.Length > 30)
                return false;

            return true;
        }
        public static bool CheckBDay(string bDay)
        {
            try
            {
                DateTime.Parse(bDay);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public static bool CheckEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; 
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
