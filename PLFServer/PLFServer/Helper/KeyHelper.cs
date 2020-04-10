using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLFServer.Helper
{
    public class KeyHelper
    {
        public static String CreateRandomKey()
        {
            Random rdm = new Random();
            return rdm.Next(Int16.MaxValue, Int32.MaxValue) + "";
        }
    }
}
