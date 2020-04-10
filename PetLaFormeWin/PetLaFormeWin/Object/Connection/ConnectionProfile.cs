using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLaFormeWin.Object.Connection
{
    public class ConnectionProfile
    {
        String userName;
        String userPassword;

        public ConnectionProfile(String userName, String userPassword)
        {
            this.userName = userName;
            this.userPassword = userPassword;
        }

        public string UserName { get => userName; set => userName = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
    }
}
