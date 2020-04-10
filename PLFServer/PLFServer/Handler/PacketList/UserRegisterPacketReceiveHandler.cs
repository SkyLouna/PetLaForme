using System;
using PLFAPI.Object.Packet;
using PLFAPI.Communication.NetworkPackets.Client;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFServer.Object.Packet;
using MySql.Data.MySqlClient;
using PLFAPI.Object.User;
using PLFAPI.Object.Ext;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Helper;
using System.Threading;
using PLFServer.Helper;

namespace PLFServer.Handler.PacketList
{
    public class UserRegisterPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            //get packet
            ClientPacketUserRegister clientPacketUserRegister = receivedPacket as ClientPacketUserRegister;

            ConsoleHelper.Write("Receive - ClientPacketUserRegister");

            //read packet infos
            PLFUser newUser = clientPacketUserRegister.User;
            String userPassword = clientPacketUserRegister.UserPassword.ToSQL();
            String userSecretKey = KeyHelper.CreateRandomKey();

            //insert new profile into DB command
            MySqlCommand registerNewUserCommand = new MySqlCommand();
            registerNewUserCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            registerNewUserCommand.CommandText =
                //register profile
                $"INSERT INTO `T_User`(`userPassword`, `userNick`, `userName`, `userSurname`, `userEmail`) VALUES " +
                $"('{userPassword}','{newUser.UserNickName.ToSQL()}','{newUser.UserName.ToSQL()}','{newUser.UserSurname.ToSQL()}','{newUser.UserEMail.ToSQL()}');" +

                //register key
                $"INSERT INTO `T_RegisterKey`(`regUserMail`, `regKey`, `regKeyDeliver`) VALUES ('{newUser.UserEMail}','{userSecretKey}','{DateTime.Now.Ticks}');" +
                
                //get user id
                $"SELECT LAST_INSERT_ID()";
           
            MySqlDataReader mysqlDataReader = null;                 //command reader

            ServerPacketUserRegister serverPacketUserRegister;      //register packet answer
            
            try
            {
                int userID = 0;

                //Execute reader
                mysqlDataReader = registerNewUserCommand.ExecuteReader();


                //open reader and read ID
                while (mysqlDataReader.Read())
                    userID = mysqlDataReader.GetInt32(0);

                //new answer, register success
                serverPacketUserRegister = new ServerPacketUserRegister(true, userID, NetworkError.NONE);

                //send confirmation mail
                MailHelper.SendRegisterConfirmationMail(newUser, userSecretKey);
            }
            catch(MySqlException e)
            {
                //write sql error
                Console.WriteLine(e.Number + " - " + e.Message);


                NetworkError networkError;

                //switch between sql errors
                switch(e.Number)
                {
                    case 1062:
                        networkError = NetworkError.SQL_USER_EXIST;
                        break;
                    case 1064:
                        networkError = NetworkError.GLOBAL_UNKNOWN;
                        break;
                    default:
                        networkError = NetworkError.GLOBAL_UNKNOWN;
                        break;
                }

                //new answer, register fail
                serverPacketUserRegister = new ServerPacketUserRegister(false, -1, networkError);
            }
            catch(Exception e)
            {
                //new answer, register fail
                serverPacketUserRegister = new ServerPacketUserRegister(false, -1, NetworkError.GLOBAL_UNKNOWN);
                Console.WriteLine(e.Message);
            }

            //close reader
            if(mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();

            ConsoleHelper.Write("Send - ServerPacketUserRegister");

            return serverPacketUserRegister;

        }
    }
}
