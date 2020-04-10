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
using Newtonsoft.Json;

namespace PLFServer.Handler.PacketList
{
    public class DAuthDisablePacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            //get received packet
            ClientPacketDisableDAuth clientPacketDisableDAuth = receivedPacket as ClientPacketDisableDAuth;

            ConsoleHelper.Write("Receive - ClientPacketDisableDAuth");

            //read packet infos
            PLFUser user = clientPacketDisableDAuth.PlfUser;

            //insert key in db command
            MySqlCommand disableDAuthCommand = new MySqlCommand();
            disableDAuthCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            disableDAuthCommand.CommandText =
                $"DELETE FROM `T_DoubleAuth` WHERE `daUserID`='{user.ID}'";

           ServerPacketConfirmation serverPacketConfirmation;
            
            try
            {
                //execute command
                disableDAuthCommand.ExecuteNonQuery();

                serverPacketConfirmation = new ServerPacketConfirmation(true, NetworkError.NONE);

                //run on extern thread
                new Thread(() => 
                {
                    Program.mailManager.SendMail(user.UserEMail, "PET LA FORME - Double Authentification",
                        $"Bonjour {user.UserName}! La double authentification a bien été désactivée sur votre compte. ");
                }
                ).Start();
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
