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
    public class DAuthEnablePacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            //get received packet
            ClientPacketEnableDAuth clientPacketEnableDAuth = receivedPacket as ClientPacketEnableDAuth;

            ConsoleHelper.Write("Receive - ClientPacketEnableDAuth");

            //read packet infos
            PLFUser user = clientPacketEnableDAuth.PlfUser;
            byte[] userPrivateKey = clientPacketEnableDAuth.UserPrivateKey;
            String userKey = JsonConvert.SerializeObject(userPrivateKey);

            //insert key in db command
            MySqlCommand enableDAuthCommand = new MySqlCommand();
            enableDAuthCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            enableDAuthCommand.CommandText =
                $"INSERT INTO `T_DoubleAuth`(`daUserID`, `daUserKey`) VALUES ('{user.ID}','{userKey}')";

           ServerPacketConfirmation serverPacketConfirmation;
            
            try
            {
                //execute command
                enableDAuthCommand.ExecuteNonQuery();

                serverPacketConfirmation = new ServerPacketConfirmation(true, NetworkError.NONE);

                //run on extern thread
                new Thread(() => 
                {
                    Program.mailManager.SendMail(user.UserEMail, "PET LA FORME - Double Authentification",
                        $"Bonjour {user.UserName}! La double authentification a bien été activée sur votre compte. ");
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
