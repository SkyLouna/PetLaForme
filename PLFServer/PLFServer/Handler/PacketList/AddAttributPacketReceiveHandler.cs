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
using PLFAPI.Object.Pet.Attribute;
using System.Collections.Generic;

namespace PLFServer.Handler.PacketList
{
    public class AddAttributPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            //get received packet
            ClientPacketAddAttribut clientPacketAddAttribut = receivedPacket as ClientPacketAddAttribut;

            ConsoleHelper.Write("Receive - ClientPacketAddAttribut");

            //read packet infos
            int petID = clientPacketAddAttribut.PetID;
            PetAttribute petAttribute = clientPacketAddAttribut.PetAttribute;

            //download pet
            MySqlCommand downloadPet = new MySqlCommand();
            downloadPet.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            downloadPet.CommandText = $@"SELECT * FROM `T_Pet` WHERE `petID` IN ({petID})";
            

            MySqlDataReader mysqlDataReader = null;

            List<PetAttribute> petAttributes = new List<PetAttribute>();

            try
            {
                //execute reader
                mysqlDataReader = downloadPet.ExecuteReader();

                //open reader
                while (mysqlDataReader.Read())
                    petAttributes = JsonConvert.DeserializeObject<List<PetAttribute>>(mysqlDataReader.GetString(3));

                //close reader
                mysqlDataReader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ServerPacketConfirmation(false, NetworkError.GLOBAL_UNKNOWN);
            }

            //close reader
            if (mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();

            petAttributes.Add(petAttribute);

            try
            {
                //update pet attribut list
                MySqlCommand updatePetAttributeCommand = new MySqlCommand();
                updatePetAttributeCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
                updatePetAttributeCommand.CommandText = $@"UPDATE `T_Pet` SET `petAttributs`='{JsonConvert.SerializeObject(petAttributes).ToSQL()}' WHERE `petID`='{petID}'";
                updatePetAttributeCommand.ExecuteNonQuery();
               
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return new ServerPacketConfirmation(false, NetworkError.GLOBAL_UNKNOWN);
            }

            ConsoleHelper.Write("Send - ServerPacketConfirmation");

            return new ServerPacketConfirmation(true, NetworkError.NONE);

        }
    }
}
