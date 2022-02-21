using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class Role
    {
        public int AccessLevel { get; set; }
        public string AccessName { get; set; }

        public Role GetRole()
        {
            if (AccessLevel == 1)
                return new Admin();
            else
                return new User();
        }

        public Role(int accessLevel, string accessName = "default")
        {
            AccessLevel = accessLevel;
            AccessName = accessName;
        }
    }
}
