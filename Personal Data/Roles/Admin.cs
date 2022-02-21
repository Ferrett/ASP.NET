using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class Admin : Role
    {
        public Admin() : base(1, typeof(Admin).Name)
        {

        }
    }
}
