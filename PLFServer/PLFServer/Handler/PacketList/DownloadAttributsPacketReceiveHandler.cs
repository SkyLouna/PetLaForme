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
    public class DownloadAttribusPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            //get received packet
            ClientPacketDownloadAttributs clientPacketDownloadAttributs = receivedPacket as ClientPacketDownloadAttributs;

            ConsoleHelper.Write("Receive - ClientPacketDownloadAttributs");

            //read packet infosk
            int petID = clientPacketDownloadAttributs.PetID;

            //download pets command
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

                //close reader
                mysqlDataReader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();

            ConsoleHelper.Write("Send - ServerPacketDownloadAttributs");

            return new ServerPacketDownloadAttributs(petAttributes);

        }
    }
}
