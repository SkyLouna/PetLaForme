using System;
using PLFAPI.Object.Packet;
using PLFAPI.Communication.NetworkPackets.Client;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFServer.Object.Packet;
using MySql.Data.MySqlClient;
using PLFAPI.Object.Ext;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Helper;
using PLFAPI.Object.Pet;
using Newtonsoft.Json;

namespace PLFServer.Handler.PacketList
{
    public class UpdatePetPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {

            ClientPacketUpdatePet clientPacketUpdatePet = receivedPacket as ClientPacketUpdatePet;

            ConsoleHelper.Write("Receive - ClientPacketUpdatePet");

            PLFPet pet = clientPacketUpdatePet.PetProfile;

            //insert new profile into DB
            MySqlCommand updatePetCommand = new MySqlCommand();
            updatePetCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            updatePetCommand.CommandText =
                $"UPDATE `T_Pet` SET `petType`='{(int)pet.PetType}',`petName`='{pet.PetName.ToSQL()}' WHERE `petID`='{pet.PetID}'";

            ServerPacketConfirmation serverPacketConfirmation;

            try
            {
                updatePetCommand.ExecuteNonQuery();

                serverPacketConfirmation = new ServerPacketConfirmation(true, NetworkError.NONE);
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
