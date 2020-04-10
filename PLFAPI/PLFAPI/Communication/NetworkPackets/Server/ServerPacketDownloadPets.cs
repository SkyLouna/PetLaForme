using System;
using PLFAPI.Object.Packet;
using PLFAPI.Object.Pet;
using System.Collections.Generic;

namespace PLFAPI.Communication.NetworkPackets.Server
{
    [Serializable()]
    public class ServerPacketDownloadPets : Packet
    {

        List<PLFPet> petList;                   //pet list

        public ServerPacketDownloadPets(List<PLFPet> petList) : base(PacketType.SERVERPACKETDOWNLOADPETS)
        {
            this.petList = petList;
        }

        public List<PLFPet> PetList { get => petList; set => petList = value; }
    }
}
