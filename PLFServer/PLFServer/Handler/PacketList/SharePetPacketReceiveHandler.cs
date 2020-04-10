using System;
using PLFAPI.Object.Packet;
using PLFAPI.Communication.NetworkPackets.Client;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFServer.Object.Packet;
using MySql.Data.MySqlClient;
using PLFAPI.Object.User;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Helper;
using PLFAPI.Object.Ext;
using Newtonsoft.Json;

namespace PLFServer.Handler.PacketList
{
    public class SharePetPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            ClientPacketSharePet clientPacketSharePet = receivedPacket as ClientPacketSharePet;

            ConsoleHelper.Write("Receive - ClientPacketSharePet");

            int ownerID = clientPacketSharePet.OwnerUserID;
            int petID = clientPacketSharePet.PetID;
            String receiverUserName = clientPacketSharePet.ReceiverUserNick.ToSQL();
            int sharePower = clientPacketSharePet.SharePower;

            int receiverID = SQLHelper.GetUserID(receiverUserName);

            //if incorect user
            if (receiverID == -1)
                return new ServerPacketConfirmation(false, NetworkError.SQL_USER_UNKNOWN);


            //insert new profile into DB
            MySqlCommand sharePetCommand = new MySqlCommand();
            sharePetCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            sharePetCommand.CommandText =
                $"INSERT INTO `T_Share`(`fkOwnerID`, `fkPetID`, `fkReceiverID`, `sharePower`) VALUES ('{ownerID}','{petID}','{receiverID}','{sharePower}')";

            ServerPacketConfirmation serverPacketConfirmation;

            try
            {
                sharePetCommand.ExecuteNonQuery();

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
