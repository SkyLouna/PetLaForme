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
    public class DownloadAttributPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            //get received packet
            ClientPacketDownloadAttribut clientPacketDownloadAttribut = receivedPacket as ClientPacketDownloadAttribut;

            ConsoleHelper.Write("Receive - ClientPacketDownloadAttribut");

            //read packet infos
            int petID = clientPacketDownloadAttribut.PetID;
            int attributID = clientPacketDownloadAttribut.AttributID;

            //download pet
            MySqlCommand downloadPetsCommand = new MySqlCommand();
            downloadPetsCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            downloadPetsCommand.CommandText = $@"SELECT * FROM `T_Pet` WHERE `petID` IN ({petID})";
            

            MySqlDataReader mysqlDataReader = null;

            List<PetAttribute> petAttributes = new List<PetAttribute>();

            try
            {
                //execute reader
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

            //close reader
            if (mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();

            ConsoleHelper.Write("Send - ServerPacketDownloadAttribut");

            //if attribut id is bigger than total attributs
            if (petAttributes.Count <= attributID)
            {
                Console.WriteLine("Warn too much pet attributs S: " + petAttributes.Count + " C: " + attributID);
                return new ServerPacketDownloadAttribut(null);
                
            }
                

            return new ServerPacketDownloadAttribut(petAttributes[attributID]);

        }
    }
}
