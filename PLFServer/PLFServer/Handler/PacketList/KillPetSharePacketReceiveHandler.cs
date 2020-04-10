using System;
using PLFAPI.Object.Packet;
using PLFAPI.Communication.NetworkPackets.Client;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFServer.Object.Packet;
using MySql.Data.MySqlClient;
using PLFAPI.Object.User;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Helper;
using PLFAPI.Object.Pet;
using Newtonsoft.Json;

namespace PLFServer.Handler.PacketList
{
    public class KillPetSharePacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {

            ClientPacketKillSharePet clientPacketKillSharePet = receivedPacket as ClientPacketKillSharePet;

            ConsoleHelper.Write("Receive - ClientPacketKillSharePet");

            int userID = clientPacketKillSharePet.ReceiverUserID;
            int petID = clientPacketKillSharePet.PetID;

            //insert new profile into DB
            MySqlCommand killPetShareCommand = new MySqlCommand();
            killPetShareCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            killPetShareCommand.CommandText =
                $"DELETE FROM `T_Share` WHERE `fkPetID`='{petID}' AND `fkReceiverID`='{userID}'";

            ServerPacketConfirmation serverPacketConfirmation;

            try
            {
                killPetShareCommand.ExecuteNonQuery();
                serverPacketConfirmation = new ServerPacketConfirmation(true, NetworkError.NONE);
            }
            catch
            {
                serverPacketConfirmation = new ServerPacketConfirmation(false, NetworkError.GLOBAL_UNKNOWN);
            }

            ConsoleHelper.Write("Send - ServerPacketConfirmation");

            return serverPacketConfirmation;

        }
    }
}
