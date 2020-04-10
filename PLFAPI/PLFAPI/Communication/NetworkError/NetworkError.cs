using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLFAPI.Communication.NetworkError
{
    public enum NetworkError
    {
        /*
         * SQL ERROR ENUM 
         */

        SQL_USER_EXIST,
        SQL_USER_UNKNOWN,
        SQL_USER_WRONG_PASSWORD,
        SQL_USER_WRONG_ACCODE,

        /*
         * SERVER ERROR ENUM 
         */
         SERVER_UNAVAILABLE,

        /*
         * GLOBAL ERROR ENUM 
         */
        NONE,
        GLOBAL_UNKNOWN
    }
}
