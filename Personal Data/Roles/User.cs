using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class User : Role
    {
        public User() : base(2, typeof(User).Name)
        {

        }
    }
}
