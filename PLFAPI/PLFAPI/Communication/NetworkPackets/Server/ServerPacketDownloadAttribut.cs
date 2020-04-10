using System;
using PLFAPI.Object.Packet;
using PLFAPI.Object.Pet;
using System.Collections.Generic;
using PLFAPI.Object.Pet.Attribute;

namespace PLFAPI.Communication.NetworkPackets.Server
{
    [Serializable()]
    public class ServerPacketDownloadAttribut : Packet
    {

        PetAttribute petAttribut;

        public ServerPacketDownloadAttribut(PetAttribute petAttribut) : base(PacketType.SERVERPACKETDOWNLOADATTRIBUT)
        {
            this.petAttribut = petAttribut;
        }

        public PetAttribute PetAttribut { get => petAttribut; set => petAttribut = value; }
    }
}
