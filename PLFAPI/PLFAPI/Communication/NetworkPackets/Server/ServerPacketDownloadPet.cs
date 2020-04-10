using System;
using PLFAPI.Object.Packet;
using PLFAPI.Object.Pet;
using System.Collections.Generic;

namespace PLFAPI.Communication.NetworkPackets.Server
{
    [Serializable()]
    public class ServerPacketDownloadPet : Packet
    {

        PLFPet pet;                 //pet list

        public ServerPacketDownloadPet(PLFPet pet) : base(PacketType.SERVERPACKETDOWNLOADPET)
        {
            this.pet = pet;
        }

        public PLFPet Pet { get => pet; set => pet = value; }
    }
}
