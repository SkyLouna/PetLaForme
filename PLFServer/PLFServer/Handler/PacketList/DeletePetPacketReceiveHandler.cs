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
    public class DeletePetPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            //get received packet
            ClientPacketDeletePet clientPacketDeletePet = receivedPacket as ClientPacketDeletePet;

            ConsoleHelper.Write("Receive - ClientPacketDeletePet");

            //read packet infos
            int userID = clientPacketDeletePet.UserID;
            int petID = clientPacketDeletePet.PetID;   

            //insert new profile into DB
            MySqlCommand deletePetCommand = new MySqlCommand();
            deletePetCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            deletePetCommand.CommandText =
                $"DELETE FROM T_Own WHERE T_Own.`fkPetID`='{petID}' AND T_Own.`fkUserID`='{userID}'; DELETE FROM `T_Share` WHERE `fkPetID`='{petID}'; DELETE FROM T_Pet WHERE `petID`= '{petID}'";

            ServerPacketConfirmation serverPacketConfirmation;

            try
            {
                //Execute command
                deletePetCommand.ExecuteNonQuery();
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
