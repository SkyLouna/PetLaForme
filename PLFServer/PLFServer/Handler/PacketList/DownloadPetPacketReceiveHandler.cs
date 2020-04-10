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
    public class DownloadPetPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            //get received packet
            ClientPacketDownloadPet clientPacketDownloadPet = receivedPacket as ClientPacketDownloadPet;

            ConsoleHelper.Write("Receive - ClientPacketDownloadPet");

            //read packet infos
            int petID = clientPacketDownloadPet.PetID;

            //get share power
            Dictionary<int, int> sharedPetPower = SQLHelper.GetPetSharePower(new List<int>() { petID });

            //download pet
            MySqlCommand downloadPetsCommand = new MySqlCommand();
            downloadPetsCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            downloadPetsCommand.CommandText = $@"SELECT * FROM `T_Pet` WHERE `petID` IN ({petID})";          

            MySqlDataReader mysqlDataReader = null;

            PLFPet pet = new PLFPet(PetType.OTHER);

            try
            {
               //execute reader
                mysqlDataReader = downloadPetsCommand.ExecuteReader();

                //open reader
                while (mysqlDataReader.Read())
                {
                    //get pet
                    pet = new PLFPet(mysqlDataReader.GetInt32(0), (PetType)mysqlDataReader.GetInt32(1),
                        mysqlDataReader.GetString(2));

                    //if is a shared pet
                    if (clientPacketDownloadPet.Shared)
                        pet.SharePower = sharedPetPower[mysqlDataReader.GetInt32(0)];
                }
                //close reader
                mysqlDataReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //close reader
            if (mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();

            ConsoleHelper.Write("Send - ServerPacketDownloadPet");

            return new ServerPacketDownloadPet(pet);

        }

        //This is a way to fix multiple pets for no reason ?!
        public Boolean ListContains(List<PLFPet> petList, int petID)
        {
            foreach (var pet in petList)
                if (pet.PetID == petID)
                    return true;
            return false;
        }

    }
}
