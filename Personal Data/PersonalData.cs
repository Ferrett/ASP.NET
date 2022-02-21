using System;

namespace WebApplication4
{
    public class PersonalData
    {
        public string Login { get; set; }
        public string HashPass { get; set; }
        public DateTime BDay { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        public PersonalData(string login, string hashPass, DateTime bDay, string email, Role role)
        {
            Login = login;
            HashPass = hashPass;
            BDay = bDay;
            Email = email;
            Role = role;
        }
    }
}
