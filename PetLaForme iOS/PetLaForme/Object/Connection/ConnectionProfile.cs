using System;
namespace PetLaForme.Object.Connection
{
    public class ConnectionProfile
    {
        String userName;                    //user connection name  
        String userPassword;                //user connection password

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PetLaForme.Object.Connection.ConnectionProfile"/> class.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <param name="userPassword">User password.</param>
        public ConnectionProfile(String userName, String userPassword)
        {
            this.userName = userName;
            this.userPassword = userPassword;
        }

        public string UserName { get => userName; set => userName = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
    }
}
