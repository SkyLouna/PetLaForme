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
    public class UserAskResetPasswordPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            ClientPacketUserAskResetPassword clientPacketUserAskResetPassword = receivedPacket as ClientPacketUserAskResetPassword;

            ConsoleHelper.Write("Receive - ClientPacketUserAskResetPassword");

            String userName = clientPacketUserAskResetPassword.UserName;
            String userSecretKey = KeyHelper.CreateRandomKey();

            //insert new profile into DB
            MySqlCommand checkUserIdentityCommand = new MySqlCommand();
            checkUserIdentityCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            checkUserIdentityCommand.CommandText =
                $"SELECT * FROM `T_User` WHERE userNick='{userName}'";

            PLFUser downloadedUser = null;

            MySqlDataReader mysqlDataReader = null;

            ServerPacketConfirmation serverPacketConfirmation;
            
            try
            {
                mysqlDataReader = checkUserIdentityCommand.ExecuteReader();

                //open reader
                while (mysqlDataReader.Read())
                    downloadedUser = new PLFUser(mysqlDataReader.GetInt32(0), mysqlDataReader.GetString(2), mysqlDataReader.GetString(3), mysqlDataReader.GetString(4), mysqlDataReader.GetString(5));

                if (mysqlDataReader != null && !mysqlDataReader.IsClosed)
                    mysqlDataReader.Close();

                if (downloadedUser != null)
                {
                    //insert new profile into DB
                    MySqlCommand registerNewResetPasswordKey = new MySqlCommand();
                    registerNewResetPasswordKey.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
                    registerNewResetPasswordKey.CommandText =
                        $"DELETE FROM `T_PasswordKey` WHERE `pswUserMail`='{downloadedUser.UserEMail}';" +
                        $"INSERT INTO `T_PasswordKey`(`pswUserMail`, `pswUserKey`, `pswKeyDeliver`) VALUES ('{downloadedUser.UserEMail}','{userSecretKey}','{DateTime.Now.Ticks}');";

                    registerNewResetPasswordKey.ExecuteNonQuery();
                    new Thread(() =>
                    {
                        Program.mailManager.SendMail(downloadedUser.UserEMail, "PET LA FORME - Récupération de mot de passe",
                            $"Bonjour {downloadedUser.UserName}! Voici votre code de secours: "
                            + $"{userSecretKey}. Merci de la rentrer dans votre application pour pouvoir définir votre nouveau mot de passe ! Bonne journée !");
                    }
                     ).Start();

                    serverPacketConfirmation = new ServerPacketConfirmation(true, NetworkError.NONE);
                }
                else
                    serverPacketConfirmation = new ServerPacketConfirmation(false, NetworkError.SQL_USER_UNKNOWN);
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Number + " - " + e.Message);
                NetworkError networkError;
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
                serverPacketConfirmation = new ServerPacketConfirmation(false, networkError);
            }
            catch(Exception e)
            {
                serverPacketConfirmation = new ServerPacketConfirmation(false, NetworkError.GLOBAL_UNKNOWN);
                Console.WriteLine(e.Message);
            }

            ConsoleHelper.Write("Send - ServerPacketConfirmation");

            return serverPacketConfirmation;

        }
    }
}
