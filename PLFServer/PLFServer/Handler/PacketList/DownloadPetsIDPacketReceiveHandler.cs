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
    public class DownloadPetsIDPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            ClientPacketDownloadPetsID clientPacketDownloadPetsID = receivedPacket as ClientPacketDownloadPetsID;

            ConsoleHelper.Write("Receive - ClientPacketDownloadPetsID");

            int userID = clientPacketDownloadPetsID.UserID;

            List<int> ownPetIdList = SQLHelper.GetIDList($"SELECT `fkPetID` FROM `T_Own` WHERE `fkUserID`='{userID}'", 0);
            List<int> sharePetIdList = SQLHelper.GetIDList($"SELECT `fkPetID` FROM `T_Share` WHERE `fkReceiverID`='{userID}'", 0);

            int[] petID = new int[ownPetIdList.Count];
            int[] sharedPetID = new int[sharePetIdList.Count];

            for (int i = 0; i < ownPetIdList.Count; i++)
                petID[i] = ownPetIdList[i];

            for (int i = 0; i < sharePetIdList.Count; i++)
                sharedPetID[i] = sharePetIdList[i];

            ConsoleHelper.Write("Send - ServerPacketDownloadPetsID");

            return new ServerPacketDownloadPetsID(petID, sharedPetID);

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
