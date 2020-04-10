using System;
using PLFAPI.Object.Packet;
using PLFAPI.Communication.NetworkPackets.Client;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFServer.Object.Packet;
using MySql.Data.MySqlClient;
using PLFAPI.Object.User;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Helper;
using System.Collections.Generic;

namespace PLFServer.Handler.PacketList
{
    public class PetShareListPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            ClientPacketSharePetList clientPacketSharePetList = receivedPacket as ClientPacketSharePetList;

            ConsoleHelper.Write("Receive - ClientPacketSharePetList");

            int petID = clientPacketSharePetList.PetID;

            //insert new profile into DB
            MySqlCommand downloadPetShareListCommand = new MySqlCommand();
            downloadPetShareListCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            downloadPetShareListCommand.CommandText =
                $"SELECT * FROM `T_User`, `T_Share` WHERE fkPetID = '{petID}' AND T_Share.fkReceiverID = T_User.userID";

            MySqlDataReader mysqlDataReader = null;

            List<PLFUser> shareUserList = new List<PLFUser>();

            try
            {
                mysqlDataReader = downloadPetShareListCommand.ExecuteReader();

                //open reader
                while (mysqlDataReader.Read())
                    shareUserList.Add(
                        new PLFUser(mysqlDataReader.GetInt32(0), mysqlDataReader.GetString(2), mysqlDataReader.GetString(3), mysqlDataReader.GetString(4), mysqlDataReader.GetString(5))
                        );

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if(mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();

            ConsoleHelper.Write("Send - ServerPacketSharePetList");

            return new ServerPacketSharePetList(shareUserList);

        }
    }
}
