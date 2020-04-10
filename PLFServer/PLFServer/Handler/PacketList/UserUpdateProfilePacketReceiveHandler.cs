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

namespace PLFServer.Handler.PacketList
{
    public class UserUpdateProfilePacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            ClientPacketUserUpdateProfile clientPacketUserUpdateProfile = receivedPacket as ClientPacketUserUpdateProfile;

            ConsoleHelper.Write("Receive - ClientPacketUserUpdateProfile");

            PLFUser user = clientPacketUserUpdateProfile.User;
            String userPassword = clientPacketUserUpdateProfile.UserPassword.ToSQL();

            //insert new profile into DB
            MySqlCommand updateUserProfileCommand = new MySqlCommand();
            updateUserProfileCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            updateUserProfileCommand.CommandText =
                $"UPDATE `T_User` SET `userPassword`='{userPassword}',`userName`='{user.UserName.ToSQL()}'," +
                $"`userSurname`='{user.UserSurname.ToSQL()}',`userEmail`='{user.UserEMail.ToSQL()}' WHERE `userID`='{user.ID}'";


            ServerPacketConfirmation serverPacketConfirmation;

            try
            {
                updateUserProfileCommand.ExecuteNonQuery();

                serverPacketConfirmation = new ServerPacketConfirmation(true, NetworkError.NONE);
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Number + " - " + e.Message);
                NetworkError networkError;
                switch (e.Number)
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
            catch (Exception e)
            {
                serverPacketConfirmation = new ServerPacketConfirmation(false, NetworkError.GLOBAL_UNKNOWN);
                Console.WriteLine(e.Message);
            }

            ConsoleHelper.Write("Send - ServerPacketConfirmation");

            return serverPacketConfirmation;

        }
    }
}
