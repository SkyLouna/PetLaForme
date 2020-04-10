using System;

namespace PLFAPI.Object.User
{
    [Serializable()]
    public class PLFUser
    {
        int userID;                                         //userid
        String userNickName;                                //user nick
        String userName;                                    //user name
        String userSurname;                                 //user surname
        String userEMail;                                   //user email

        public PLFUser(int userID, String userNickName, String userName, String userSurname, String userEMail)
        {
            this.userID = userID;
            this.userNickName = userNickName;
            this.userName = userName;
            this.userSurname = userSurname;
            this.userEMail = userEMail;
        }

        public PLFUser()
        {
            this.userID = -1;
            this.userNickName = "Surnom";
            this.userName = "Nom";
            this.userSurname = "Prénom";
            this.userEMail = "Email";
        }

        public int ID { get => userID; set => userID = value; }
        public string UserNickName { get => userNickName; set => userNickName = value; }
        public string UserName { get => userName; set => userName = value; }
        public string UserEMail { get => userEMail; set => userEMail = value; }
        public string UserSurname { get => userSurname; set => userSurname = value; }
    }
}
