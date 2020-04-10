using PLFAPI.Object.DAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLFAPI.Helper
{
    public static class DAuthHelper
    {
        public static String GetUserCode(byte[] privateKey)
        {
            //create new otp auth with user private key
            GoogleTOTP googleTOTP = new GoogleTOTP(privateKey);

            //get otp auth
            return googleTOTP.GeneratePin();
        }
    }
}
