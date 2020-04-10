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
using PLFAPI.Object.Pet.Attribute;
using System.Collections.Generic;

namespace PLFServer.Handler.PacketList
{
    public class GetAmountOfAttributsPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            ClientPacketGetAmountOfAttributs clientPacketGetAmountOfAttributs = receivedPacket as ClientPacketGetAmountOfAttributs;

            ConsoleHelper.Write("Receive - ClientPacketGetAmountOfAttributs");

            int petID = clientPacketGetAmountOfAttributs.PetID;

            //download pet
            MySqlCommand downloadPetsCommand = new MySqlCommand();
            downloadPetsCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            downloadPetsCommand.CommandText = $@"SELECT * FROM `T_Pet` WHERE `petID` IN ({petID})";
            

            MySqlDataReader mysqlDataReader = null;

            List<PetAttribute> petAttributes = new List<PetAttribute>();

            try
            {

                mysqlDataReader = downloadPetsCommand.ExecuteReader();

                //open reader
                while (mysqlDataReader.Read())
                    petAttributes = JsonConvert.DeserializeObject<List<PetAttribute>>(mysqlDataReader.GetString(3));

                mysqlDataReader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();

            ConsoleHelper.Write("Send - ServerPacketGetAmountOfAttributs");

            return new ServerPacketGetAmountOfAttributs(petAttributes.Count);

        }
    }
}
