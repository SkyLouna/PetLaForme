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
    public class DeleteAttributPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            //get received packet
            ClientPacketDeleteAttribut clientPacketDeleteAttribut = receivedPacket as ClientPacketDeleteAttribut;

            ConsoleHelper.Write("Receive - DeleteAttributPacketReceiveHandler");

            //read packet infos
            int petID = clientPacketDeleteAttribut.PetID;
            int attributID = clientPacketDeleteAttribut.AttributID;

            //download pet command
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

                //close reader
                mysqlDataReader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Close reader
            if (mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();


            if (petAttributes.Count <= attributID)
            {
                Console.WriteLine("Warn too much pet attributs S: " + petAttributes.Count + " C: " + attributID);
                return new ServerPacketConfirmation(false, NetworkError.GLOBAL_UNKNOWN);
            }

            //Get attribute with id
            PetAttribute attribute = petAttributes[attributID];

            //Remove attribute from the list
            petAttributes.Remove(attribute);

            try
            {
                //update attributes command
                MySqlCommand updatePetAttributeCommand = new MySqlCommand();
                updatePetAttributeCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
                updatePetAttributeCommand.CommandText = $@"UPDATE `T_Pet` SET `petAttributs`='{JsonConvert.SerializeObject(petAttributes).ToSQL()}' WHERE `petID`='{petID}'";
                updatePetAttributeCommand.ExecuteNonQuery();
            }
            catch{}

            ConsoleHelper.Write("Send - ServerPacketConfirmation");

            return new ServerPacketConfirmation(true, NetworkError.NONE);

        }
    }
}
