using System;
using PLFAPI.Object.Packet;
using PLFAPI.Object.Pet;
using System.Collections.Generic;
using PLFAPI.Object.Pet.Attribute;

namespace PLFAPI.Communication.NetworkPackets.Server
{
    [Serializable()]
    public class ServerPacketDownloadAttributs : Packet
    {

        List<PetAttribute> petAttributes;

        public ServerPacketDownloadAttributs(List<PetAttribute> petAttributes) : base(PacketType.SERVERPACKETDOWNLOADATTRIBUTS)
        {
            this.petAttributes = petAttributes;
        }

        public List<PetAttribute> PetAttributes { get => petAttributes; set => petAttributes = value; }
    }
}
