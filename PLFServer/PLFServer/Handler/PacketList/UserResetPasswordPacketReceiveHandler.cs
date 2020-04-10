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
    public class UserPasswordResetPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            ClientPacketUserResetPassword clientPacketUserResetPassword = receivedPacket as ClientPacketUserResetPassword;

            ConsoleHelper.Write("Receive - ClientPacketUserActivateAccount");

            String userName = clientPacketUserResetPassword.UserName;
            String userKey = clientPacketUserResetPassword.Code.ToSQL();
            String userNewPassword = clientPacketUserResetPassword.NewPassword.ToSQL();

            PLFUser user = SQLHelper.GetUserProfile(userName);
            if (user == null)
                return new ServerPacketConfirmation(false, NetworkError.SQL_USER_UNKNOWN);

            //insert new profile into DB
            MySqlCommand checkActivationCodeCommabd = new MySqlCommand();
            checkActivationCodeCommabd.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            checkActivationCodeCommabd.CommandText =
                $"SELECT * FROM `T_PasswordKey` WHERE `pswUserMail`='{user.UserEMail}' AND `pswUserKey`='{userKey}';" +
                $"DELETE FROM `T_DoubleAuth` WHERE `daUserID`='{user.ID}'";

            MySqlDataReader mysqlDataReader = null;

            ServerPacketConfirmation serverPacketConfirmation;

            Boolean keyValid = false;

            try
            {
                mysqlDataReader = checkActivationCodeCommabd.ExecuteReader();

                //open reader
                while (mysqlDataReader.Read())
                {
                    keyValid = true;
                }

                if (keyValid)
                {
                    serverPacketConfirmation = new ServerPacketConfirmation(true, NetworkError.NONE);
                    new Thread(() =>
                    {
                        Program.mailManager.SendMail(user.UserEMail, "PET LA FORME - Récupération de mot de passe",
                            $"Bonjour {user.UserName}! Votre mot de passe vient d'etre mis à jour !");
                    }
                ).Start();
                }
                else
                    serverPacketConfirmation = new ServerPacketConfirmation(false, NetworkError.SQL_USER_WRONG_ACCODE);
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Number + " - " + e.Message);
                NetworkError networkError;
                switch (e.Number)
                {
                    case 1062:
                        networkError = NetworkError.SQL_USER_WRONG_ACCODE;
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
            catch (Exception e)
            {
                serverPacketConfirmation = new ServerPacketConfirmation(false, NetworkError.GLOBAL_UNKNOWN);
                Console.WriteLine(e.Message);
            }

            if(mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();

            if(keyValid)
            {
                MySqlCommand changePasswordCommand = new MySqlCommand();
                changePasswordCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
                changePasswordCommand.CommandText =
                     $"UPDATE `T_User` SET `userPassword`='{userNewPassword}' WHERE `userID`='{user.ID}'";
                changePasswordCommand.ExecuteNonQuery();
            }

            ConsoleHelper.Write("Send - ServerPacketConfirmation");

            return serverPacketConfirmation;

        }
    }
}
