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
    public class UserActivateAccountPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            ClientPacketUserActivateAccount clientPacketUserActivateAccount = receivedPacket as ClientPacketUserActivateAccount;

            ConsoleHelper.Write("Receive - ClientPacketUserActivateAccount");

            PLFUser user = clientPacketUserActivateAccount.User;
            String userKey = clientPacketUserActivateAccount.UserCode.ToSQL();

            //insert new profile into DB
            MySqlCommand checkActivationCodeCommabd = new MySqlCommand();
            checkActivationCodeCommabd.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            checkActivationCodeCommabd.CommandText =
                $"SELECT * FROM `T_RegisterKey` WHERE `regUserMail`='{user.UserEMail}' AND `regKey`='{userKey}'";

            MySqlDataReader mysqlDataReader = null;

            ServerPacketConfirmation serverPacketConfirmation;

            Boolean confirmationAllow = false;

            try
            {
                mysqlDataReader = checkActivationCodeCommabd.ExecuteReader();

                //open reader
                while (mysqlDataReader.Read())
                {
                    confirmationAllow = true;
                }

                if (confirmationAllow)
                {
                    serverPacketConfirmation = new ServerPacketConfirmation(true, NetworkError.NONE);
                    new Thread(() =>
                    {
                        Program.mailManager.SendMail(user.UserEMail, "PET LA FORME - Inscription",
                            $"Bonjour {user.UserName}! Votre compte a été confirmé avec succés ! Bonne journée !");
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

            if(confirmationAllow)
            {
                MySqlCommand activeAccountCommand = new MySqlCommand();
                activeAccountCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
                activeAccountCommand.CommandText =
                    $"UPDATE `T_User` SET `userAccountActive`='1' WHERE `userID`='{user.ID}'";
                activeAccountCommand.ExecuteNonQuery();
            }

            ConsoleHelper.Write("Send - ServerPacketConfirmation");

            return serverPacketConfirmation;

        }
    }
}
