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
    public class DownloadPetsPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            ClientPacketDownloadPets clientPacketDownloadPets = receivedPacket as ClientPacketDownloadPets;

            ConsoleHelper.Write("Receive - ClientPacketDownloadPets");

            int userID = clientPacketDownloadPets.UserID;

            List<int> ownPetIdList = SQLHelper.GetIDList($"SELECT `fkPetID` FROM `T_Own` WHERE `fkUserID`='{userID}'", 0);
            List<int> sharePetIdList = SQLHelper.GetIDList($"SELECT `fkPetID` FROM `T_Share` WHERE `fkReceiverID`='{userID}'", 0);

            Dictionary<int, int> sharedPetPower = SQLHelper.GetPetSharePower(sharePetIdList);

            //download pet
            MySqlCommand downloadPetsCommand = new MySqlCommand();
            downloadPetsCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            downloadPetsCommand.CommandText = $@"SELECT * FROM `T_Pet` WHERE `petID` IN ({SQLHelper.IntListToString(ownPetIdList)})";
            
            //OLD
            //downloadPetsCommand.CommandText =
            //  $"SELECT T_Pet.`petID`, T_Pet.`petType`, T_Pet.`petName`, T_Pet.`petAttributs` FROM `T_Pet`, `T_Own` WHERE T_Own.`fkUserID` = '{userID}'";

            MySqlCommand downloadSharedPetsCommand = new MySqlCommand();
            downloadSharedPetsCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            downloadSharedPetsCommand.CommandText = $@"SELECT * FROM `T_Pet` WHERE `petID` IN ({SQLHelper.IntListToString(sharePetIdList)})";

            //OLD
            //downloadSharedPetsCommand.CommandText =
            //  $"SELECT T_Pet.`petID`, T_Pet.`petType`, T_Pet.`petName`, T_Pet.`petAttributs` FROM `T_Pet`, `T_Share` WHERE T_Share.`fkReceiverID` = '{userID}' ";

            MySqlDataReader mysqlDataReader = null;

            List<PLFPet> petList = new List<PLFPet>();

            try
            {
                //
                //          DOWNLOAD OWN PETS
                //
                if(ownPetIdList.Count > 0)
                {
                    mysqlDataReader = downloadPetsCommand.ExecuteReader();

                    //open reader
                    while (mysqlDataReader.Read())
                    {
                        PLFPet pet = new PLFPet(mysqlDataReader.GetInt32(0), (PetType)mysqlDataReader.GetInt32(1),
                            mysqlDataReader.GetString(2));

                        //JsonConvert.DeserializeObject<List<PetAttribute>>(mysqlDataReader.GetString(3))

                        //scotch fix. TODO: fix it with sql command
                        if (!ListContains(petList, mysqlDataReader.GetInt32(0)))
                            petList.Add(pet);
                    }

                    mysqlDataReader.Close();
                }
             
                //
                //          DOWNLOAD SHARED PETS
                //

                if(sharePetIdList.Count > 0)
                {
                    mysqlDataReader = downloadSharedPetsCommand.ExecuteReader();

                    //open reader and read shared pets
                    while (mysqlDataReader.Read())
                    {
                        PLFPet pet = new PLFPet(mysqlDataReader.GetInt32(0), (PetType)mysqlDataReader.GetInt32(1),
                            mysqlDataReader.GetString(2), sharedPetPower[mysqlDataReader.GetInt32(0)]);

                        //scotch fix. TODO: fix it with sql command
                        if (!ListContains(petList, mysqlDataReader.GetInt32(0)))
                            petList.Add(pet);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();

            //new List<PLFPet>() { new PLFPet(1, PetType.CAT, "Test", new List<PetAttribute>()) }
            ConsoleHelper.Write("Send - ServerPacketDownloadPets");

            return new ServerPacketDownloadPets(petList);

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
