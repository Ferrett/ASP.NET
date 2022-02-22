using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class ValidateData
    {
        public static bool CheckCategoryName(string categoryName)
        {
            if (categoryName.Length < 3 || categoryName.Length > 20)
                return false;

            return true;
        }
        public static bool CheckAmount(int anount)
        {
            if (anount <= 0)
                return false;

            return true;
        }
        public static bool CheckDate(string bDay)
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
        public static bool CheckCategoryID(int categoryID)
        {
            if (categoryID <= 0)
                return false;

            return true;
        }
    }
}
