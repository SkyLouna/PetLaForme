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
    public class AddPetPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            //cast received packet
            ClientPacketAddPet clientPacketAddPet = receivedPacket as ClientPacketAddPet;

            ConsoleHelper.Write("Receive - ClientPacketAddPet");

            //get packet properties
            int userID = clientPacketAddPet.OwnerUserID;
            PLFPet pet = clientPacketAddPet.NewPet;

            //add packet command
            MySqlCommand registerNewPetCommand = new MySqlCommand();
            registerNewPetCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            registerNewPetCommand.CommandText =
                $"INSERT INTO `T_Pet`(`petType`, `petName`, `petAttributs`) VALUES ('{(int)pet.PetType}','{pet.PetName.ToSQL()}', '[]'); SELECT LAST_INSERT_ID();";

            MySqlDataReader mysqlDataReader = null;

            ServerPacketAddPet serverPacketAddPet;

            try
            {
                //execute sql reader
                mysqlDataReader = registerNewPetCommand.ExecuteReader();

                int petID = 0;

                //open reader
                while (mysqlDataReader.Read())
                    petID = mysqlDataReader.GetInt32(0);

                //new server packet
                serverPacketAddPet = new ServerPacketAddPet(true, petID, NetworkError.NONE);
            }
            catch (MySqlException e)
            {
                //write message
                Console.WriteLine(e.Number + " - " + e.Message);

                serverPacketAddPet = new ServerPacketAddPet(false, -1, NetworkError.GLOBAL_UNKNOWN);
            }
            catch (Exception e)
            {
                serverPacketAddPet = new ServerPacketAddPet(false, -1, NetworkError.GLOBAL_UNKNOWN);
                Console.WriteLine(e.Message);
            }

            //close reader
            if (mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();

            //add own relation if success
            if(serverPacketAddPet.RegisterSuccess)
            {
                MySqlCommand registerNewOwnCommand = new MySqlCommand();
                registerNewOwnCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
                registerNewOwnCommand.CommandText =
                    $"INSERT INTO `T_Own`(`fkPetID`, `fkUserID`) VALUES ('{serverPacketAddPet.PetID}','{userID}') ";
                registerNewOwnCommand.ExecuteNonQuery();
            }

            ConsoleHelper.Write("Send - ServerPacketAddPet");

            return serverPacketAddPet;

        }
    }
}
